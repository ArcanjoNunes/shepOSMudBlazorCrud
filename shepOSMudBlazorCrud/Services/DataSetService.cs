using System.Data;

namespace shepOSMudBlazorCrud.Services
{
    public class DataSetService
    {
        // Report
        public string ReportPath { get; private set; } = default!;
        public string ReportTitle { get; set; } = default!;
        public string ReportFilename { get; set; } = default!;
        public string ReportDSSchema { get; set; } = "shepOS";
        public DataSet ReportDataSet { get; set; } = new DataSet();

        // Language
        public int resLanguageId => shepOS.shepOSLibrary.GetLanguageID();
        
        // User
        public string userId { get; set; } = default!;
        public string userName { get; set; } = default!;

        public DataSetService()
        {
            SetReportsFolder();
        }

        public void ClearDataSet()
        {
            ReportDataSet.Tables.Clear();
        }

        private void SetReportsFolder() => ReportPath = FindReportsFolder(Environment.CurrentDirectory);

        private string FindReportsFolder(string startDir)
        {
            string directory = Path.Combine(startDir, "Reports");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }
    }
}
