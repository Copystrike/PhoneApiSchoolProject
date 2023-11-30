using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View;

public class CreateAppView
{

    [Required(ErrorMessage = "Vul de naam in")]
    [StringLength(100, ErrorMessage = "De naam mag niet langer zijn dan 100 tekens")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Vul de versie in")]
    [StringLength(100, ErrorMessage = "De versie mag niet langer zijn dan 100 tekens")]
    public string Version { get; set; }
    
    [Required(ErrorMessage = "Vul de ontwikkelaar in")]
    [StringLength(100, ErrorMessage = "De ontwikkelaar mag niet langer zijn dan 100 tekens")]
    public string Developer { get; set; }
    
    [Required(ErrorMessage = "Vul de beschrijving in")]
    [StringLength(100, ErrorMessage = "De beschrijving mag niet langer zijn dan 100 tekens")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Vul de prijs in")]
    [Range(0, 1000, ErrorMessage = "De prijs moet tussen de 0 en 1000 liggen")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Vul de releasedatum in")]
    public DateTime ReleaseDate { get; set; }
    
    [Required(ErrorMessage = "Vul het besturingssysteem in")]
    public Guid CompatibleOsId { get; set; }
}