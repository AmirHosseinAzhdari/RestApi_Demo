using System;
using System.ComponentModel.DataAnnotations;

namespace RestApi_Demo.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        [StringLength(256)]
        public string HowTo { get; set; }

        [Required]
        public String Line { get; set; }

        [Required] 
        public string Platform { get; set; }
    }
}
