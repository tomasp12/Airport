using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models;

namespace Airport
{
    public class HTMLGenerator
    {   
        public string FormatHTML(List<ReportField> reportRows, bool fromEU)
        {
            string tableRow = "<tr{6}><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>";
            string tableLineColor;
            string tableName;
            if (fromEU)
            {
                tableLineColor = " style =\"background-color:99ccff;\"";
                tableName = "Aircrafts from Europe";
            }
            else 
            {
                tableLineColor = " style=\"background-color:ffccff;\"";
                tableName = "Aircrafts from Not Europe";
            }
            
            
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(String.Format(tableRow, "Aircraft tail number", 
                                                        "Model number", 
                                                        "Model description",
                                                        "Owner company name", 
                                                        "Company country code", 
                                                        "Company country name", 
                                                        ""
                                               )
                                );
            foreach (ReportField reportRow in reportRows)
            {
                builder.AppendLine(String.Format(tableRow, reportRow.AircraftTailNumber,
                                                           reportRow.ModelNumber,
                                                           reportRow.ModelDescription,
                                                           reportRow.OwnerCompanyName,
                                                           reportRow.CompanyCountryCode,
                                                           reportRow.CompanyCountryName,
                                                           tableLineColor
                                                )
                                   );
            }
            string htmlDocumnt = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
            return htmlDocumnt + String.Format("<html><head><meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\"></head>"+
                                 "<body><h1>{0}</h1><table border=\"1\">{1}</table></body></html>", tableName,builder.ToString() );
        }

    }



}


