using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View;

public class UpdateOsView
{
    [Required(ErrorMessage = "Een id is vereist")]
    public Guid Id { get; set; }
    
    [StringLength(100, ErrorMessage = "De naam mag niet langer dan 100 tekens zijn")]
    public string? Name { get; set; }

    [StringLength(20, ErrorMessage = "De versie mag niet langer dan 20 tekens zijn")]
    public string? Version { get; set; }

    [StringLength(100, ErrorMessage = "De ontwikkelaar mag niet langer dan 100 tekens zijn")]
    public string? Developer { get; set; }

    [StringLength(500, ErrorMessage = "De beschrijving mag niet langer dan 500 tekens zijn")]
    public string? Description { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "De prijs moet groter dan 0 zijn")]
    public decimal? Price { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Voer alstublieft een geldige releasedatum in")]
    public DateTime? ReleaseDate { get; set; }
}