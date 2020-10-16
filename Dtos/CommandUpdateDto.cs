using System.ComponentModel.DataAnnotations;

namespace RestApi_Demo.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [StringLength(256)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required] 
        public string Platform { get; set; }
    }
}