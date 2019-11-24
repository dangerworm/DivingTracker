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
    public enum CriterionStatuses : int
    {
        /// <summary>
        /// Unknown (0)
        /// </summary>
		[Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Not Started (1)
        /// </summary>
		[Description("Not Started")]
        NotStarted = 1,

        /// <summary>
        /// Needs Consolidation (2)
        /// </summary>
		[Description("Needs Consolidation")]
        NeedsConsolidation = 2,

        /// <summary>
        /// Complete (3)
        /// </summary>
		[Description("Complete")]
        Complete = 3
	}

    /// <summary>
    /// QualificationTypes auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum QualificationTypes : int
    {
        /// <summary>
        /// Diving (1)
        /// </summary>
		[Description("Diving")]
        Diving = 1,

        /// <summary>
        /// Instructor (2)
        /// </summary>
		[Description("Instructor")]
        Instructor = 2
	}

    /// <summary>
    /// SystemRoles auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum SystemRoles : int
    {
        /// <summary>
        /// Unknown (0)
        /// </summary>
		[Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Student (1)
        /// </summary>
		[Description("Student")]
        Student = 1,

        /// <summary>
        /// Instructor (2)
        /// </summary>
		[Description("Instructor")]
        Instructor = 2,

        /// <summary>
        /// Admin (3)
        /// </summary>
		[Description("Admin")]
        Admin = 3
	}

}
