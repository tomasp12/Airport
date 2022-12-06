using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Aircraft
    {
    
        public Aircraft(int id, int modelId , int companyId,string serialNumber) 
        {
            Id = id;
            ModelId = modelId;
            CompanyId = companyId;
            SerialNumber = serialNumber;
                
        }

        public int Id { get; set; }
        public int ModelId { get; set; }
        public int CompanyId { get; set; }
        public string SerialNumber{ get; set;}
    }
}
