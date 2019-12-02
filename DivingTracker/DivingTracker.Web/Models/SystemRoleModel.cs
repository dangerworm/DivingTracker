using System.ComponentModel;
using DivingTracker.ServiceLayer;

namespace DivingTracker.Web.Models
{
    public class SystemRoleModel
    {
        public string Description { get; set; }

        [DisplayName("Role")]
        public int SystemRoleId { get; set; }

        public SystemRoleModel()
        {
        }

        public SystemRoleModel(SystemRole systemRole)
        {
            Description = systemRole.Description;
            SystemRoleId = systemRole.SystemRoleId;
        }
    }
}