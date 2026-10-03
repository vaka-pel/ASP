using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AcademyCW.Models
{
	public class Discipline
	{
		[Key]
		[Column(TypeName = "SMALLINT")]
		public int discipline_Id { get; set; }
		[Required]
		public string discipline_Name { get; set; }
		[Required]
		[Column(TypeName = "TINYINT")]
		public int number_of_lessons { get; set; }
	}
}
