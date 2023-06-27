using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
	public class SignUpModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string? Fullname { get; set; }

		[Required] 
		public string? Email { get;}
		
		[Required] 
		public string? Password { get;}

		[Required]		 
		public DateTime RegDate { get; set; }
 
	}
}
