using PhoneApiSchoolProject.Models;

namespace PhoneApiSchoolProject.Services
{
    public class AppsService : IAppsService
    {
        private static readonly List<AppsModel> Apps = new List<AppsModel>
        {
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Slack", "v1.0", "Slack Technologies", "Business",
                0, new DateTime(2009, 8, 1), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e"), "Zoom", "v1.0", "Zoom Video Communications",
                "Business", 0, new DateTime(2011, 4, 21), Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca"), "Google Meet", "v1.0", "Google", "Business", 0,
                new DateTime(2017, 3, 1), Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"), "Microsoft Teams", "v1.0", "Microsoft", "Business",
                0, new DateTime(2016, 11, 2), Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646")),
            new(Guid.Parse("e0f676f2-5a6a-4ea3-9d0e-d0b2f226029a"), "Trello", "v1.0", "Atlassian", "Business", 0,
                new DateTime(2011, 9, 13), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("2ef34f95-b344-4ca4-97e3-3438b5fbe3db"), "ChatGPT", "v1.0", "OpenAI", "Social Media", 0,
                new DateTime(2015, 12, 11), Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("6651115a-d51b-443e-b0db-fe385216a669"), "Signal", "v1.0", "Signal Foundation",
                "Social Media", 0, new DateTime(2014, 7, 29), Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("6cb78e8f-c0c2-45c1-aa07-257a589a8b7e"), "Telegram", "v1.0", "Telegram FZ-LLC",
                "Social Media", 0, new DateTime(2013, 8, 14), Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646")),
            new(Guid.Parse("0eae0368-af5f-4f62-86da-bf2fa1657981"), "Discord", "v1.0", "Discord Inc.", "Social Media",
                0, new DateTime(2015, 5, 13), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("596e0c09-4567-46fe-9f97-fb919197f2dc"), "Minecraft", "v1.0", "Mojang Studios", "Games", 10,
                new DateTime(2009, 5, 17), Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("0ab48281-ece6-4be7-91dc-f74eee15150b"), "Among Us", "v1.0", "InnerSloth", "Games", 5,
                new DateTime(2018, 6, 15), Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("e268ef12-24cd-4a42-812e-6f315825f5c1"), "GTA V", "v1.0", "Rockstar Games", "Games", 20,
                new DateTime(2013, 9, 17), Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646")),
            new(Guid.Parse("86009346-bdb9-4ee8-a166-9a6b3a399ac4"), "Cyberpunk 2077", "v1.0", "CD Projekt", "Games", 60,
                new DateTime(2020, 12, 10), Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"))
        };


        // Read methods
        public List<AppsModel> GetAllApps()
        {
            return Apps;
        }

        public AppsModel? GetAppById(Guid id)
        {
            return Apps.FirstOrDefault(app => app.Id == id);
        }

        public List<AppsModel> GetAppsByIsPaid(bool isPaid)
        {
            return Apps.Where(app => app.Price > 0).ToList();
        }

        public AppsModel CreateApp(AppsModel app)
        {
            Apps.Add(app);
            return app;
        }

        public AppsModel UpdateApp(AppsModel app)
        {
            var index = Apps.FindIndex(existingApp => existingApp.Id == app.Id);
            Apps[index] = app;
            return app;
        }

        public void DeleteApp(Guid id)
        {
            var index = Apps.FindIndex(existingApp => existingApp.Id == id);
            Apps.RemoveAt(index);
        }

        public List<AppsModel> SearchApps(string search)
        {
            return Apps.Where(app => app.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<AppsModel> GetAppsByOsId(Guid osId)
        {
            return Apps.Where(app => app.CompatibleOsId == osId).ToList();
        }
    }
}