using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
	public class UProfile
	{
		[Key]
		public int UserId { get; set; }

		[MaxLength(250)]
		public string Name { get; set; }

		[DataType(DataType.DateTime)]
		[DisplayName("Date of Birth")]
		public DateTime Dob { get; set; }
		public string Sex { get; set; }

		public virtual UCredential Ucredential { get; set; }


		public string getAge()
		{
			var today = DateTime.Now;
			var age = today.Year - Dob.Year;
			if (Dob.Date > today.AddYears(-age)) age--;

			return age.ToString();
		}
	}
}