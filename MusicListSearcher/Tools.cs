using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MusicListSearcher;
using Excel = Microsoft.Office.Interop.Excel;

namespace MusicListSearcher
{
    class Tools
    {

        public const int ThresholdDistance = 2;

        public static List<string> GetMusicNames(string excelPath)
        {
            List<string> names = new List<string>();
            SlExcelReader slExcel = new SlExcelReader();
            SlExcelData slExcelData = slExcel.ReadExcel(excelPath);
            names = slExcelData.DataRows.SelectMany(l => l).Distinct().ToList();
            names.AddRange(slExcelData.Headers);
            return names;
        }
        public static void CopyMusic(List<string> dances, string inputFolder, string outputFolder, MainForm form)
        {
            var files = Directory.GetFiles(inputFolder, "*.*", SearchOption.AllDirectories).
                Select(f => new { path = f, filename = RenameDance(Path.GetFileName(f).Split('-')[0])}).ToList();
            var processed = 0;

            foreach (string dance in dances)
            {
                var matches = files.Where(f => f.filename.Equals(RenameDance(dance))).ToList();

                if (matches.Count > 1)
                    form.Log($"{dance.ToUpper()} -> {matches.Count} canciones");
                else if (matches.Count == 1)
                    form.Log($"{dance.ToUpper()} -> {matches.Count} canción");
                else
                {
                    var bestMatch = BestCoincidence(dance, files.Select(f => f.filename).ToList());
                    form.Log(dance.ToUpper() +
                        (!string.IsNullOrEmpty(bestMatch)
                                 ? $" -> Quisiste decir: {bestMatch.ToUpper()}"
                                 : " -> No se han encontrado canciones"), 
                        MainForm.LogOptions.Warning);
                }

                foreach (string matchPath in matches.Select(f => f.path))
                {
                    string originalPath = matchPath;
                    string match = Path.GetFileName(matchPath);
                    match = $"{processed + 1:00}" + " - " + match;
                    File.Copy(originalPath, Path.Combine(outputFolder, match), true);
                }                
                processed++;
                form.UpdateProgressBar(processed * 100 / dances.Count);
            }
        }

        public static string RenameDance(string dance)
        {
            string renamed = dance.ToLower();
            return renamed.Trim();
        }

        public static string BestCoincidence(string input, List<string> possibleCoincidences)
        {
            foreach (var possibleCoincidence in possibleCoincidences)
            {
                if (Algorithms.LevenshteinDistance(RenameDance(input), possibleCoincidence) <= ThresholdDistance)
                    return possibleCoincidence;
            }
            return null;
        }


    }
}
