using PhoneApiSchoolProject.Models;

namespace PhoneApiSchoolProject.Services
{
    public interface IPhoneService
    {
        List<PhoneModel> GetAllPhones();
        PhoneModel? GetPhoneById(Guid id);
        List<PhoneModel> GetPhonesByBrand(string brand);
        PhoneModel CreatePhone(PhoneModel phoneModel);
        PhoneModel? UpdatePhone(PhoneModel phoneView);
        void DeletePhone(Guid id);
        List<PhoneModel> SearchPhones(string search);
    }
}