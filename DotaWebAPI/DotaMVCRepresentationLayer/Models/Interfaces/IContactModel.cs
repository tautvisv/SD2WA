using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotaMVCRepresentationLayer.Models.Interfaces
{
    public interface IContactModel
    {
        string SupportMail { get; set; }
        string MarkettingMail { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Name { get; set; }
        string Group { get; set; }
        string MainMail { get; set; }
    }
}