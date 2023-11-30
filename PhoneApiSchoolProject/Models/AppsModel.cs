namespace PhoneApiSchoolProject.Models
{
    public class AppsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Developer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CompatibleOsId { get; set; }


        public AppsModel()
        {
        }

        public AppsModel(Guid id, string name, string version, string developer, string description, decimal price,
            DateTime releaseDate, Guid compatibleOs)
        {
            Id = id;
            Name = name;
            Version = version;
            Developer = developer;
            Description = description;
            Price = price;
            ReleaseDate = releaseDate;
            CompatibleOsId = compatibleOs;
        }
    }
}