using System.ComponentModel.DataAnnotations;

namespace RestApi_Demo.Models
{
    public class Command{
       [Key]
       public int Id { get; set; }

       [Required]
       [StringLength(256)]
       public string HowTo { get; set; }

       [Required]
       public string Line { get; set; }

       [Required]
       public string Platform { get; set; }
    }
}