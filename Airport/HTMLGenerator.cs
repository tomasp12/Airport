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
        public string FormatHTML(List<Report> reportRows, bool fromEU)
        {
            string tableRow = "<tr{6}><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>";
            string tableLineColor;
            string tableName;
            if (fromEU)
            {
                tableLineColor = " style ='background-color:rgb(153,204,255);'";
                tableName = "Aircrafts from Europe";
            }
            else 
            {                
                tableLineColor = " style='background-color:rgb(255,204,255);'";
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
            foreach (Report reportRow in reportRows)
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
            
            return String.Format(@"<div><h1>{0}</h1><table border='1'>{1}</table></div>", tableName,builder.ToString() );
        }

    }



}


