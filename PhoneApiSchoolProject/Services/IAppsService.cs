using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public interface IAppsService
    {
        List<AppsModel> GetAllApps();
        AppsModel? GetAppById(Guid id);
        List<AppsModel> GetAppsByIsPaid(bool isPaid);
        AppsModel CreateApp(AppsModel app);
        AppsModel UpdateApp(AppsModel app);
        void DeleteApp(Guid id);
        List<AppsModel> SearchApps(string name);
        List<AppsModel> GetAppsByOsId(Guid osId);
    }
}