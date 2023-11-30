using System.ComponentModel.DataAnnotations;

namespace PhoneApiSchoolProject.View
{
    public class CreateOsView
    {
        [Required(ErrorMessage = "Een naam is vereist")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Een versie is vereist")]
        public string Version { get; set; }
        
        [Required(ErrorMessage = "Een fabrikant is vereist")]
        public string Manufacturer { get; set; }
        
        [Required(ErrorMessage = "Een releasedatum is vereist")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Een open source status is vereist")]
        public bool IsOpenSource { get; set; }
    }
}