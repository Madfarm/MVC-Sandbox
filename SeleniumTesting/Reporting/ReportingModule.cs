using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTests.Reporting
{
    public class ReportingModule
    {
        private string BrowserType;
        private string url;
        private DateTime date;
        private FileStream fs;
        private StringBuilder reportcsv;
        private string filePath;
        private string fileName;
        public ReportingModule(string BrowserType, string url)
        {
            BrowserType = BrowserType;
            url = url;
            date = DateTime.Now;
            fileName = date.Date.Date.ToShortDateString() + date.TimeOfDay.Hours.ToString() + date.TimeOfDay.Minutes.ToString();
            reportcsv = new StringBuilder();
            filePath = @"D:\VisualStudio\repos\MVC Sandbox\SeleniumTesting\Reporting" + fileName + ".csv";
            createCsvFile();
        }
        private void createCsvFile()
        {
            reportcsv.Append("StepDescription,");
            reportcsv.Append("Pass/Fail,");
            reportcsv.Append("Exception");
            File.AppendAllText(filePath, reportcsv.ToString());
        }
        public void addLine(string description, string result, string exception)
        {
            reportcsv.Append(Environment.NewLine);
            reportcsv.Append(description + ",");
            reportcsv.Append(result + ",");
            reportcsv.Append(exception + ",");
            reportcsv.Append(Environment.NewLine);
            File.WriteAllText(filePath, reportcsv.ToString());
        }
    }
}
