using System.ComponentModel;

namespace DivingTracker.ServiceLayer.Enums
{
    public enum ConceptResourceType
    {
        [Description("Manual Entry")]
        ManualEntry = 0,

        [Description("Wikipedia")]
        Wikipedia = 1,

        [Description("Wiktionary")]
        Wiktionary = 2
    }
}
