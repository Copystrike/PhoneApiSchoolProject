using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View;

public class UpdateOsView
{
    [Required(ErrorMessage = "Een id is vereist")]
    public Guid Id { get; set; }

    [StringLength(100, ErrorMessage = "De naam is te lang")]
    public string? Name { get; set; }

    [StringLength(100, ErrorMessage = "De versie is te lang")]
    public string? Version { get; set; }

    [StringLength(100, ErrorMessage = "De fabrikant is te lang")]
    public string? Manufacturer { get; set; }

    [DataType(DataType.Date)] public DateTime? ReleaseDate { get; set; }

    public bool? IsOpenSource { get; set; }
}