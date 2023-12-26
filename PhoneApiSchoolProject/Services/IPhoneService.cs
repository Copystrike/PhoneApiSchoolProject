using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public interface IPhoneService
    {
        List<PhoneModel> GetAllPhones();
        PhoneModel? GetPhoneById(Guid id);
        List<PhoneModel> GetPhonesByBrand(string brand);
        PhoneModel CreatePhone(CreatePhoneView createPhoneView);
        PhoneModel? UpdatePhone(UpdatePhoneView updatePhoneView);
        void DeletePhone(Guid id);
        List<PhoneModel> SearchPhones(string search);
    }
}