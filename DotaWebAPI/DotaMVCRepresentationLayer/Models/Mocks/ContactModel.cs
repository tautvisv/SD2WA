using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotaMVCRepresentationLayer.Models.Interfaces;

namespace DotaMVCRepresentationLayer.Models.Mocks
{
    public class ContactModel : IContactModel
    {
        public ContactModel()
        {
            SupportMail = "nepadesiu@webapi.com";
            MarkettingMail = "isparduota@webapi.com";
            PhoneNumber = "+370 6 99 58876";
            Address = "Kaunas, Tauro g. 13";
            Group = "IFF - 2";
            Name = "Tautvydas Vaitiekūnas";
            MainMail = "tautvisv@gmail.com";
        }
        public string SupportMail { get; set; }
        public string MarkettingMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string MainMail { get; set; }
    }
}