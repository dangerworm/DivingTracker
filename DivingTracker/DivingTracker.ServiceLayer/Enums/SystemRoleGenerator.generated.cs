// This is a generated file. Do not attempt to modify it as your changes would be overwritten.
// Connection String Used: Data Source=FERMI;Initial Catalog=DivingTracker;Integrated Security=True
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace DivingTracker.ServiceLayer.Enums
{
    /// <summary>
    /// SystemRoles auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public enum SystemRoles : byte
    {
        /// <summary>
        /// Admin (1)
        /// </summary>
		[Description("Admin")]
        Admin = 1,

        /// <summary>
        /// Lead Instructor (2)
        /// </summary>
		[Description("Lead Instructor")]
        LeadInstructor = 2,

        /// <summary>
        /// Instructor (3)
        /// </summary>
		[Description("Instructor")]
        Instructor = 3,

        /// <summary>
        /// Student (4)
        /// </summary>
		[Description("Student")]
        Student = 4
	}
}
