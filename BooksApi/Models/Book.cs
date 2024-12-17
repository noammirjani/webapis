using System.ComponentModel.DataAnnotations;

namespace BookApi.Models;

public class Book
{   
    [Required]
    public int Id {get; set;}
    [Required]
    [StringLength(50)]
    public string Title {get; set;} = string.Empty;
    [Required]
    [StringLength(50)]
    public string Author {get; set;} = string.Empty;
    [Range(1500, 3000)]
    public int Year {get; set;}

}