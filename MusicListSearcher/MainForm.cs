using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MusicListSearcher
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _excelFileDialog;
        private CommonOpenFileDialog _musicFolderDialog;
        private CommonOpenFileDialog _outputFolderDialog;
        private Paths _paths;
        public static readonly string FileName = Path.GetTempPath() + "SavedPaths.bin";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _excelFileDialog = new OpenFileDialog();
            _musicFolderDialog = new CommonOpenFileDialog {IsFolderPicker = true, RestoreDirectory = true};
            _outputFolderDialog = new CommonOpenFileDialog {IsFolderPicker = true, RestoreDirectory = true};
            _paths = LoadPaths();
            WritePaths(_paths);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _excelFileDialog.RestoreDirectory = true;

            // Show the dialog and get result.
            DialogResult result = _excelFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                this.excelFileInput.Text = _excelFileDialog.FileName;
            }

            Console.WriteLine(result); // <-- For debugging use.
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (_musicFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.musicFolderInput.Text = _musicFolderDialog.FileName;
            }
        }

        private void folderOutputButton_Click(object sender, EventArgs e)
        {
            if (_outputFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                this.outputFolderInput.Text = _outputFolderDialog.FileName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidateForm()) return;
            try
            {
                progressBar1.Value = 0;
                Log("Leyendo Excel...");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                
                //List<string> names = Tools.GetMusicNames(excelFileInput.Text, (int) this.numBailes.Value);
                List<string> names = Tools.GetMusicNames(excelFileInput.Text);

                Log($"Se han detectado {names.Count} bailes");

                Tools.CopyMusic(names, this.musicFolderInput.Text, this.outputFolderInput.Text, this);
                watch.Stop();
                Log($"Completado en: {watch.ElapsedMilliseconds} ms");

            }
            catch (Exception ex)
            {
                Log(ex.Message, LogOptions.Error);
            }
            finally
            {
                Log("\n", LogOptions.NewLine);
                SavePaths();
            }
        }

        #region PathsOptions

        private void WritePaths(Paths paths)
        {
            this.excelFileInput.Text = paths.ExcelFile;
            this.musicFolderInput.Text = paths.MusicFolder;
            this.outputFolderInput.Text = paths.OutputFolder;
        }

        private Paths LoadPaths()
        {
            Paths paths = new Paths();
            if (File.Exists(FileName))
            {
                Stream openFileStream = File.OpenRead(FileName);
                paths = (Paths) new BinaryFormatter().Deserialize(openFileStream);
                openFileStream.Close();
            }

            return paths;
        }

        private void SavePaths()
        {
            Paths actualPaths = new Paths(this.excelFileInput.Text, this.musicFolderInput.Text,
                this.outputFolderInput.Text);
            if (_paths.Equals(actualPaths)) return;
            _paths = actualPaths;
            Stream saveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(saveFileStream, actualPaths);
            saveFileStream.Close();
        }

        #endregion

        public bool ValidateForm()
        {
            if (string.IsNullOrEmpty(excelFileInput.Text)) Log("Falta introducir fichero Excel.", LogOptions.Error);
            if (string.IsNullOrEmpty(musicFolderInput.Text)) Log("Falta introducir la carpeta contenedora de la música.", LogOptions.Error);
            if (string.IsNullOrEmpty(outputFolderInput.Text)) Log("Falta introducir la carpeta de destino.", LogOptions.Error);

            return string.IsNullOrEmpty(excelFileInput.Text) ||
                   string.IsNullOrEmpty(musicFolderInput.Text) ||
                   string.IsNullOrEmpty(outputFolderInput.Text);
        }

        public void Log(string str, LogOptions option = LogOptions.Verbose)
        {
            if (option == LogOptions.NewLine)
            {
                this.resultBox.AppendText(Environment.NewLine);
                return;
            }

            switch (option)
            {
                case LogOptions.Error:
                    resultBox.SelectionColor = Color.Red;
                    break;
                case LogOptions.Warning:
                    resultBox.SelectionColor = Color.DarkOrange;
                    break;
                case LogOptions.Verbose:
                    resultBox.SelectionColor = Color.Black;
                    break;
                default:
                    break;
            }

            this.resultBox.AppendText("[" +
                                      DateTime.Now.ToString("dd/MM - HH:mm:ss") +
                                      (option == LogOptions.Error ? " - ERROR " : string.Empty) + "]: " +
                                      str +
                                      Environment.NewLine);
            this.resultBox.ScrollToCaret();
        }

        public void UpdateProgressBar(int i)
        {
            progressBar1.Value = i;
        }

        public enum LogOptions
        {
            Verbose,
            Error,
            Warning,
            NewLine
        }

    }

}
