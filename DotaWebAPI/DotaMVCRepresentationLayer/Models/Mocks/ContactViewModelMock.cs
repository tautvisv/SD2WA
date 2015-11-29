using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using DotaMVCRepresentationLayer.Models.Interfaces;

namespace DotaMVCRepresentationLayer.Models.Mocks
{
    public class ContactViewModelMock:IContactViewModel
    {
        public ContactViewModelMock()
        {
            SiteTitle = "DoTa 2 Web API";
            Title = "Information:";
            Message = "Saitynai T120B165";
            Support = "Alvydas Muliuolis";
            ContactData = new ContactModel();
        }
        public IContactModel ContactData { get; set; }
        public string SiteTitle { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Support { get; set; }
    }
}