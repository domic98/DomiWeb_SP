using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DomiWeb.Models
{
    public class ApplicationUser : IdentityUser 
    {


        [Required]
       public int Ime { get; set; }

       public string? Adresa { get; set; }
       public string? Grad {  get; set; }
       public string? PostanskiBroj { get; set; }

      public string Role {  get; set; }

    }
}
