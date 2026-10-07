
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
	public class OfficeAssignment
	{
		public int InstructorID { get; set; }

		[StringLength(50)]
		[DisplayName("Расположение офиса")]
		public string Location { get; set; }

		// Navigation Properties:
		public Instructor Instructor { get; set; }
	}
}
