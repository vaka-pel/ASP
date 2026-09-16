using System.ComponentModel.DataAnnotations;
namespace AcademyCW.Models
{
	public class Student
	{
		[Key]
		public int stud_id { get; set; }
		[Required]
		public int group {  get; set; }

	}
}
