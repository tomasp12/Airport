using Airport.DB;
using Airport.Repositories;
using Airport.Models;
using Airport;

//Creating DB
//need Microsoft.Data.Sqlite is a lightweight ADO.NET provider for SQLite.
var database = new CreateDB();

// Generate Report list from DB
var reportGenerator = new ReportGenerator();
var listfromEU = reportGenerator.GenerateReportForAircraft(true);
var listfromNotEU = reportGenerator.GenerateReportForAircraft(false);

// Generate Html string from Report list 
HTMLGenerator htmlGenerator = new HTMLGenerator();
var htmlReportAirplainFromEu = htmlGenerator.FormatHTML(listfromEU, true);
var htmlReportAirplainNotFromEu = htmlGenerator.FormatHTML(listfromNotEU, false);

//Sending report emails
EmailSender emailSender = new EmailSender();
emailSender.EmailSend(htmlReportAirplainFromEu);
emailSender.EmailSend(htmlReportAirplainNotFromEu);
