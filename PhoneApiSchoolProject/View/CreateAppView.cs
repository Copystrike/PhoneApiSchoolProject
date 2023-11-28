using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View;

public class CreateAppView
{
    [Required(ErrorMessage = "Vul de naam in")]
    [StringLength(100, ErrorMessage = "De naam mag niet langer zijn dan 100 tekens")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Vul de versie in")]
    [StringLength(20, ErrorMessage = "De versie mag niet langer zijn dan 20 tekens")]
    public string Version { get; set; }

    [Required(ErrorMessage = "Vul de ontwikkelaar in")]
    [StringLength(100, ErrorMessage = "De ontwikkelaar mag niet langer zijn dan 100 tekens")]
    public string Developer { get; set; }

    [Required(ErrorMessage = "Vul de beschrijving in")]
    [StringLength(500, ErrorMessage = "De beschrijving mag niet langer zijn dan 500 tekens")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Vul de prijs in")]
    [Range(0, double.MaxValue, ErrorMessage = "De prijs moet groter zijn dan 0")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Vul de releasedatum in")]
    [DataType(DataType.Date, ErrorMessage = "Voer een geldige releasedatum in")]
    public DateTime ReleaseDate { get; set; }
}