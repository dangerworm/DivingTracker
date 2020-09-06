using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class AgencyModel
    {
        public AgencyModel(Agency agency)
        {
            AgencyId = agency.AgencyId;
            Name = agency.Name;
            Description = agency.Description;
            ContactEmail = agency.ContactEmail;
            ContactMobile = agency.ContactMobile;
            ContactLandLine = agency.ContactLandLine;

            Address = new AddressModel(agency.Address);
            Qualifications = agency.Qualifications.Select(x => new QualificationModel(x));
        }

        public AddressModel Address { get; set; }
        
        [DisplayName ("Agency ID")]
        public int AgencyId { get; set; }

        [DisplayName ("Contact Email")]
        public string ContactEmail { get; set; }

        [DisplayName ("Contact Landline")]
        public string ContactLandLine { get; set; }

        [DisplayName ("Contact Mobile")]
        public string ContactMobile { get; set; }

        public string Description { get; set; }

        [DisplayName ("Agency Name")]
        public string Name { get; set; }

        public IEnumerable<QualificationModel> Qualifications { get; set; }
    }
}