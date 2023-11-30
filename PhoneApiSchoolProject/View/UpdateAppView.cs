using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View;

public class UpdateAppView
{
    
    [Required(ErrorMessage = "Een id is verplicht")]
    public Guid Id { get; set; }
    
    [StringLength(100, ErrorMessage = "De naam mag niet langer zijn dan 100 tekens")]
    public string? Name { get; set; }

    [StringLength(20, ErrorMessage = "De versie mag niet langer zijn dan 20 tekens")]
    public string? Version { get; set; }

    [StringLength(100, ErrorMessage = "De ontwikkelaar mag niet langer zijn dan 100 tekens")]
    public string? Developer { get; set; }

    [StringLength(500, ErrorMessage = "De beschrijving mag niet langer zijn dan 500 tekens")]
    public string? Description { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "De prijs moet groter zijn dan 0")]
    public decimal? Price { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Voer een geldige releasedatum in")]
    public DateTime? ReleaseDate { get; set; }
    
    [Required(ErrorMessage = "Vul het besturingssysteem in")]
    public Guid? CompatibleOsId { get; set; }
}