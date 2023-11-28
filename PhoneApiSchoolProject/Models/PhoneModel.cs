namespace PhoneApiSchoolProject.Models
{
    public class PhoneModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int Storage { get; set; }
        public int Memory { get; set; }
        public Guid OsId { get; set; }

        public PhoneModel(Guid id, string brand, string color, int storage, int memory, Guid osId)
        {
            Id = id;
            Brand = brand;
            Color = color;
            Storage = storage;
            Memory = memory;
            OsId = osId;
        }
    }

}
