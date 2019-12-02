using System.Collections.ObjectModel;
using System.Linq;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class AddressModel
    {
        public AddressModel(Address address)
        {
            AddressId = address.AddressId;
            OrganisationName = address.OrganisationName;
            BuildingName = address.BuildingName;
            BuildingNumber = address.BuildingNumber;
            Street = address.Street;
            Village = address.Village;
            Town = address.Town;
            Postcode = address.Postcode;
            County = address.County;
            Country = address.Country;
            PoBox = address.PoBox;
        }

        public int AddressId { get; set; }

        public string BuildingName { get; set; }

        public string BuildingNumber { get; set; }

        public string Country { get; set; }

        public string County { get; set; }

        public string GoogleMapsSearchString
        {
            get
            {
                var parts = new Collection<string>
                {
                    OrganisationName,
                    BuildingName,
                    BuildingNumber,
                    Street,
                    Village,
                    Town,
                    Postcode
                };

                return "https://www.google.co.uk/maps/search/" + string.Join(",+",
                           parts.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Replace(" ", "+")));
            }
        }

        public string OrganisationName { get; set; }

        public string PoBox { get; set; }

        public string Postcode { get; set; }

        public string Street { get; set; }

        public string Town { get; set; }

        public string Village { get; set; }
    }
}