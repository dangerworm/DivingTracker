// This is a generated file. Do not attempt to modify it as your changes would be overwritten.
// Connection String Used: Data Source=FERMI;Initial Catalog=DivingTracker;Integrated Security=True
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace DivingTracker.ServiceLayer.Enums
{
    /// <summary>
    /// CriterionStatuses auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum CriterionStatuses : byte
    {
        /// <summary>
        /// Unknown (0)
        /// </summary>
		[Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Module Started (1)
        /// </summary>
		[Description("Module Started")]
        ModuleStarted = 1,

        /// <summary>
        /// Needs Consolidation (2)
        /// </summary>
		[Description("Needs Consolidation")]
        NeedsConsolidation = 2,

        /// <summary>
        /// Achieved (3)
        /// </summary>
		[Description("Achieved")]
        Achieved = 3
	}
}
