﻿namespace PhoneApiSchoolProject.Models
{
    public class OsModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsOpenSource { get; set; }

        public OsModel(Guid id, string name, string version, string manufacturer, DateTime releaseDate, bool isOpenSource)
        {
            Id = id;
            Name = name;
            Version = version;
            Manufacturer = manufacturer;
            ReleaseDate = releaseDate;
            IsOpenSource = isOpenSource;
        }
    }
}
