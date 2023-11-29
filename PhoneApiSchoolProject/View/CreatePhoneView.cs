using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View
{
   public class CreatePhoneView
   {
        [Required(ErrorMessage = "Merk is nodig")]
        [StringLength(100, ErrorMessage = "Merk is te lang")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Kleur is nodig")]
        [StringLength(50, ErrorMessage = "Kleur is te lang")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Opslag is nodig")]
        [Range(1, 1000, ErrorMessage = "Opslag moet tussen 1 en 1000 liggen")]
        public int Storage { get; set; }

        [Required(ErrorMessage = "Geheugen is nodig")]
        [Range(1, 100, ErrorMessage = "Geheugen moet tussen 1 en 100 liggen")]
        public int Memory { get; set; }

        [Required(ErrorMessage = "OsId is nodig")]
        public Guid OsId { get; set; }
    }
}
