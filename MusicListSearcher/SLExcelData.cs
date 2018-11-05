using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MusicListSearcher
{
    /// <summary>
    /// 
    /// </summary>
    public class SlExcelStatus
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool Success
        {
            get { return string.IsNullOrWhiteSpace(Message); }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SlExcelData
    {
        /// <summary>
        /// 
        /// </summary>
        public SlExcelStatus Status { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Columns ColumnConfigurations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Headers { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public List<List<string>> DataRows { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<List<string>> DataRowsErrors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<List<SlExcelStatus>> ErrorsMessages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SheetName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SlExcelData()
        {
            Status = new SlExcelStatus();
            Headers = new List<string>();
            DataRows = new List<List<string>>();
            DataRowsErrors = new List<List<string>>();
            ErrorsMessages = new List<List<SlExcelStatus>>();
        }
    }
}