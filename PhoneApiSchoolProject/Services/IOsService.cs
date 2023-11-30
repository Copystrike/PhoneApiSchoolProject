using PhoneApiSchoolProject.Models;

namespace PhoneApiSchoolProject.Services
{
    public interface IOsService
    {
        List<OsModel> GetAllOs();
        OsModel? GetOsById(Guid id);
        List<OsModel> GetByOpenSource(bool isOpenSource);
        OsModel CreateOs(OsModel os);
        OsModel? UpdateOs(OsModel osModel);
        void DeleteOs(Guid id);
        List<OsModel> SearchOs(string search);
    }
}
