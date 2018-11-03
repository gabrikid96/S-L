using System;

namespace MusicListSearcher
{
    [Serializable()]
    public class Paths
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelFile"></param>
        /// <param name="musicFolder"></param>
        /// <param name="outputFolder"></param>
        public Paths(string excelFile, string musicFolder, string outputFolder)
        {
            ExcelFile = excelFile;
            MusicFolder = musicFolder;
            OutputFolder = outputFolder;
        }

        public Paths()
        {
            ExcelFile = "";
            MusicFolder = "";
            OutputFolder = "";
        }

        /// <summary>
        /// 
        /// </summary>
        public string ExcelFile { get; }

        /// <summary>
        /// 
        /// </summary>
        public string MusicFolder { get; }

        /// <summary>
        /// 
        /// </summary>
        public string OutputFolder { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Paths) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (ExcelFile != null ? ExcelFile.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MusicFolder != null ? MusicFolder.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OutputFolder != null ? OutputFolder.GetHashCode() : 0);
                return hashCode;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        protected bool Equals(Paths paths)
        {
            return string.Equals(ExcelFile, paths.ExcelFile) && string.Equals(MusicFolder, paths.MusicFolder) && string.Equals(OutputFolder, paths.OutputFolder);
        }
    }
}
