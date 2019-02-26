using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MusicListSearcher
{
    /// <summary>
    /// 
    /// https://msdn.microsoft.com/es-es/library/office/hh180830(v=office.14).aspx#odc_Office14_ta_GenerateExcelWorkbookswithOpenXMLSDK20_Introduction
    /// 
    /// </summary>
    public class SlExcelReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellReference"></param>
        /// <returns></returns>
        private string GetColumnName(string cellReference)
        {
            var regex = new Regex("[A-Za-z]+");
            var match = regex.Match(cellReference);

            return match.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private int ConvertColumnNameToNumber(string columnName)
        {
            var alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            var convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64; // ASCII 'A' = 65
                convertedValue += current * (int)Math.Pow(26, i);
            }

            return convertedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);

                int currentColumnIndex = ConvertColumnNameToNumber(columnName);

                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    var emptycell = new Cell() { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }

                yield return cell;
                currentCount++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="workbookPart"></param>
        /// <returns></returns>
        private string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            var cellValue = cell.CellValue;
            var text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(
                        Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }

            //quitar caractes ocultos \u0081..... 
            return Regex.Replace((text ?? string.Empty).Trim(), @"\p{C}+", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <param name="path"></param>
        /// <returns></returns>
        public SlExcelData ReadExcel(string path)
        {
            var data = new SlExcelData();

            // Open the excel document
            SpreadsheetDocument document = null;
            List<Row> rows = new List<Row>();
            try
            {
                rows = OpenExcel(path, data, out document);
            }
            catch (IOException)
            {
                throw new Exception("El archivo está abiero. Por favor ciérrelo.");
            }


            if (rows.Count <= 1 || document == null) return data;

            foreach (var row in rows)
            {
                var dataRow = new List<string>();

                var cellEnumerator = GetExcelCellEnumerator(row);
                bool hayDatos = false;
                while (cellEnumerator.MoveNext())
                {
                    var cell = cellEnumerator.Current;
                    var text = ReadExcelCell(cell, document.WorkbookPart).Trim();
                    dataRow.Add(text);
                    if (!hayDatos & !string.IsNullOrEmpty(text))
                    {
                        hayDatos = true;
                    }
                }
                if (hayDatos)
                {
                    data.DataRows.Add(dataRow);
                }
            }
            document.Close();
            return data;
        }

        private static List<Row> OpenExcel(string path, SlExcelData data, out SpreadsheetDocument document)
        {
            List<Row> rows;
            document = SpreadsheetDocument.Open(path, false);
            var workbookPart = document.WorkbookPart;

            var sheets = workbookPart.Workbook.Descendants<Sheet>();
            var sheet = sheets.First();
            data.SheetName = sheet.Name;

            Worksheet workSheet = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet;

            var columns = workSheet.Descendants<Columns>().FirstOrDefault();
            data.ColumnConfigurations = columns;

            var sheetData = workSheet.Elements<SheetData>().First();
            rows = sheetData.Elements<Row>().ToList();

            return rows;
        }

        private static Uri FixUri(string brokenUri)
        {
            return new Uri("http://broken-link/");
        }
    }

    public static class UriFixer
    {
        public static void FixInvalidUri(Stream fs, Func<string, Uri> invalidUriHandler)
        {
            XNamespace relNs = "http://schemas.openxmlformats.org/package/2006/relationships";
            using (ZipArchive za = new ZipArchive(fs, ZipArchiveMode.Update))
            {
                foreach (var entry in za.Entries.ToList())
                {
                    if (!entry.Name.EndsWith(".rels"))
                        continue;
                    bool replaceEntry = false;
                    XDocument entryXDoc = null;
                    using (var entryStream = entry.Open())
                    {
                        try
                        {
                            entryXDoc = XDocument.Load(entryStream);
                            if (entryXDoc.Root != null && entryXDoc.Root.Name.Namespace == relNs)
                            {
                                var urisToCheck = entryXDoc
                                    .Descendants(relNs + "Relationship")
                                    .Where(r => r.Attribute("TargetMode") != null && (string)r.Attribute("TargetMode") == "External");
                                foreach (var rel in urisToCheck)
                                {
                                    var target = (string)rel.Attribute("Target");
                                    if (target != null)
                                    {
                                        try
                                        {
                                            Uri uri = new Uri(target);
                                        }
                                        catch (UriFormatException)
                                        {
                                            Uri newUri = invalidUriHandler(target);
                                            rel.Attribute($"Target").Value = newUri.ToString();
                                            replaceEntry = true;
                                        }
                                    }
                                }
                            }
                        }
                        catch (XmlException)
                        {
                            continue;
                        }
                    }
                    if (replaceEntry)
                    {
                        var fullName = entry.FullName;
                        entry.Delete();
                        var newEntry = za.CreateEntry(fullName);
                        using (StreamWriter writer = new StreamWriter(newEntry.Open()))
                        using (XmlWriter xmlWriter = XmlWriter.Create(writer))
                        {
                            entryXDoc.WriteTo(xmlWriter);
                        }
                    }
                }
            }
        }
    }
}