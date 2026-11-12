using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
        private static CompanyInfo _companyInfoInstance = null;

        private CompanyInfo(string vat, string cvr, string name, int discount)
        {
            
        }
    

        public static CompanyInfo GetInstance
        {
            get { 
                if (_companyInfoInstance == null)
                {
                    _companyInfoInstance = new CompanyInfo("avca","123123","Big mamas pizzaria", 15);
                }
                return _companyInfoInstance;
            }
        }


        public string Vat { get; set; }
        public string Cvr { get; set; }
        public string Name { get; set; }
        public int ClubDiscount { get; set; }
    }
}
