using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public interface IOsService
    {
        List<OsModel> GetAllOs();
        OsModel? GetOsById(Guid id);
        List<OsModel> GetByOpenSource(bool isOpenSource);
        OsModel CreateOs(CreateOsView os);
        OsModel? UpdateOs(UpdateOsView osModel);
        void DeleteOs(Guid id);
        List<OsModel> SearchOs(string search);
    }
}
