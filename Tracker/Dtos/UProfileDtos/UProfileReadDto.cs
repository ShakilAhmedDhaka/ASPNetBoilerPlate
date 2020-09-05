using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Dtos.UProfileDtos
{
	public class UProfileReadDto
	{
		public string Name { get; set; }

		[Required, DisplayName("User Name")]
		public string UserName { get; set; }
		
		[Required]
		public string Email { get; set; }

		public string Age { get; set; }

		public string Sex { get; set; }

	}
}