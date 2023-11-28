using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View
{
    public class CreateOsView
    {
        [Required(ErrorMessage = "Een id is vereist")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vul de naam in")]
        [StringLength(100, ErrorMessage = "De naam mag niet langer dan 100 tekens zijn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vul de versie in")]
        [StringLength(20, ErrorMessage = "De versie mag niet langer dan 20 tekens zijn")]
        public string Version { get; set; }

        [Required(ErrorMessage = "Vul de ontwikkelaar in")]
        [StringLength(100, ErrorMessage = "De ontwikkelaar mag niet langer dan 100 tekens zijn")]
        public string Developer { get; set; }

        [Required(ErrorMessage = "Vul de beschrijving in")]
        [StringLength(500, ErrorMessage = "De beschrijving mag niet langer dan 500 tekens zijn")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vul de prijs in")]
        [Range(0, double.MaxValue, ErrorMessage = "De prijs moet groter dan 0 zijn")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vul de releasedatum in")]
        [DataType(DataType.Date, ErrorMessage = "Voer alstublieft een geldige releasedatum in")]
        public DateTime ReleaseDate { get; set; }
    }
}