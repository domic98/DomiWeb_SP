using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace DomiWeb.Models
{
    [Table("Artikli")]
    public class Artikl
    {
        [Key]
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        //[MaxLength(50)]
        public string Naziv { get; set; }

        [Required]
       // [MaxLength(50)]
        public string Kategorija { get; set; }

        [Required]
        //[Range(1,100)]
        public decimal Cijena { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        public int Ocjena { get; set; }

        
        

    }
}
