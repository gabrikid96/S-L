using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MusicListSearcher;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    class Tools
    {

        public static List<string> GetMusicNames(string excelPath, int num)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            List<string> names = new List<string>(num);
            for (int i = 1; i <= num+1; i++)
            {
                for (int j = 1; j <= 1; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                        string dance = xlRange.Cells[i, j].Value2.ToString();

                        names.Add(RenameDance(dance));
                    }

                    //add useful things here!   
                }
            }
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);
            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return names;

        }

        public static void CopyMusic(List<string> dances, string inputFolder, string outputFolder, MainForm form)
        {
            string[] files = Directory.GetFiles(inputFolder);
            int procesados = 0;

            foreach (string dance in dances)
            {
                List<string> matches = files.Where(f => RenameDance(Path.GetFileName(f).Split('-')[0]).Equals(dance)).ToList();

                if (matches.Count > 1)
                    form.Log($"{dance.ToUpper()} -> {matches.Count} canciones");
                else if (matches.Count == 1)
                    form.Log($"{dance.ToUpper()} -> {matches.Count} canción");
                else
                    form.Log($"{dance.ToUpper()} -> No se han encontrado canciones", MainForm.LogOptions.Error);

                foreach (string matchPath in matches)
                {
                    string originalPath = matchPath;
                    string match = Path.GetFileName(matchPath);
                    match = string.Format("{0:00}", procesados + 1) + " - " + match;
                    File.Copy(originalPath, Path.Combine(outputFolder, match), true);
                }                
                procesados++;
                form.UpdateProgressBar(procesados * 100 / dances.Count);
            }
        }

        public static string RenameDance(string dance)
        {
            string renamed = dance.ToLower();
            return renamed.Trim();
        }
    }
}
