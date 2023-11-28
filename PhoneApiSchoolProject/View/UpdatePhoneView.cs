using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View
{
    public class UpdatePhoneView
    {
        [Required(ErrorMessage = "Id is nodig")]
        public Guid Id { get; set; }

        [StringLength(100, ErrorMessage = "Merk is te lang")]
        public string? Brand { get; set; }

        [StringLength(50, ErrorMessage = "Kleur is te lang")]
        public string? Color { get; set; }

        [Range(1, 1000, ErrorMessage = "Opslag moet tussen 1 en 1000 liggen")]
        public int? Storage { get; set; }

        [Range(1, 100, ErrorMessage = "Geheugen moet tussen 1 en 100 liggen")]
        public int? Memory { get; set; }

        public int? OsId { get; set; }
    }
}