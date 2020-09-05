using System;
using System.ComponentModel.DataAnnotations;

namespace Tracker.Dtos.UProfileDtos
{
    public class UProfileCreateDto
    {
        [Required]
        public int UserId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        
        public string Dob { get; set; }

        public string Sex { get; set; }


        public DateTime getDob()
        {
            return DateTime.Parse(Dob);
        }
    }
}
