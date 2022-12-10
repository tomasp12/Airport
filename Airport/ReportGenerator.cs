using Airport.Models;
using Airport.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class ReportGenerator
    {
        private AircraftRepository aircraftRepository;
        private AircraftModelRepository aircraftModelRepository;
        private CountryRepository countryRepository;
        private CompanyRepository companyRepository;
        public ReportGenerator() 
        {
            aircraftRepository = new AircraftRepository();
            aircraftModelRepository = new AircraftModelRepository();
            companyRepository = new CompanyRepository();
            countryRepository = new CountryRepository();
        }

        public List<ReportField> GenerateReportAircraftInEurope()
        {
            List<Aircraft> aircraftList =  aircraftRepository.Retrieve();
            List<ReportField> reportFieldList = new List<ReportField>();

            foreach (var aircraft in aircraftList)
            {
                
                Company company = companyRepository.Retrieve(aircraft.CompanyId);                
                Country country = countryRepository.Retrieve(company.CountryId);

                
                if (country.EUCountry == true)
                {
                    AircraftModel aircraftModel = aircraftModelRepository.Retrieve(aircraft.ModelId);
                    ReportField reportField = new ReportField();
                    reportField.AircraftTailNumber = aircraft.SerialNumber;
                    reportField.ModelNumber = aircraftModel.Number;
                    reportField.ModelDescription = aircraftModel.Description;
                    reportField.OwnerCompanyName = company.Name;
                    reportField.CompanyCountryCode = country.Code;
                    reportField.CompanyCountryName = country.Name;
                    reportFieldList.Add(reportField);

                }
            }

            return reportFieldList;
        }
        public List<ReportField> GenerateReportAircraftNotInEurope()
        {
            List<Aircraft> aircraftList = aircraftRepository.Retrieve();
            List<ReportField> reportFieldList = new List<ReportField>();

            foreach (var aircraft in aircraftList)
            {

                Company company = companyRepository.Retrieve(aircraft.CompanyId);
                Country country = countryRepository.Retrieve(company.CountryId);


                if (country.EUCountry == false)
                {
                    AircraftModel aircraftModel = aircraftModelRepository.Retrieve(aircraft.ModelId);
                    ReportField reportField = new ReportField();
                    reportField.AircraftTailNumber = aircraft.SerialNumber;
                    reportField.ModelNumber = aircraftModel.Number;
                    reportField.ModelDescription = aircraftModel.Description;
                    reportField.OwnerCompanyName = company.Name;
                    reportField.CompanyCountryCode = country.Code;
                    reportField.CompanyCountryName = country.Name;
                    reportFieldList.Add(reportField);

                }
            }

            return reportFieldList;
        }
    }
}
