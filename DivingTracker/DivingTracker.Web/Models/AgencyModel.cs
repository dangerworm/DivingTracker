using System.Collections.Generic;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class AgencyModel
    {
        public int AgencyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public string ContactMobile { get; set; }

        public string ContactLandLine { get; set; }

        public AddressModel Address { get; set; }

        public IEnumerable<QualificationModel> Qualifications { get; set; }

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
    }
}