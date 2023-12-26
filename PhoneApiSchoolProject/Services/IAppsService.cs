using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public interface IAppsService
    {
        List<AppsModel> GetAllApps();
        AppsModel? GetAppById(Guid id);
        List<AppsModel> GetAppsByIsPaid(bool isPaid);
        AppsModel CreateApp(CreateAppView app);
        AppsModel? UpdateApp(UpdateAppView app);
        void DeleteApp(Guid id);
        List<AppsModel> SearchApps(string name);
        List<AppsModel> GetAppsByOsId(Guid osId);
    }
}