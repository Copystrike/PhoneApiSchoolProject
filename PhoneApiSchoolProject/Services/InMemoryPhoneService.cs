﻿using AutoMapper;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public class InMemoryPhoneService : IPhoneService
    {
        private readonly IMapper _mapper;

        private static readonly List<PhoneModel> PhoneModels = new List<PhoneModel>
        {
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Apple", "GOLD", 8, 256,
                Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("6a742018-c647-4a82-b216-3a3465788823"), "Apple", "BLACK", 16, 512,
                Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e")),
            new(Guid.Parse("69c1f411-c766-4911-aae7-a434acbef698"), "OnePlus", "AQUA", 16, 256,
                Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("7c307e4e-5271-4ffb-bf04-10422e6ef539"), "Nothing", "BLACK", 16, 512,
                Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47")),
            new(Guid.Parse("1a0cf907-3880-4d6f-9219-7f7318a2cc3b"), "Windows", "BLACK", 16, 512,
                Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca")),
            new(Guid.Parse("d6478374-c67e-42a4-a319-c46eca5146f7"), "Linux", "BLACK", 16, 512,
                Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"))
        };

        public InMemoryPhoneService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<PhoneModel> GetAllPhones()
        {
            return PhoneModels;
        }

        public PhoneModel? GetPhoneById(Guid id)
        {
            return PhoneModels.FirstOrDefault(phone => phone.Id == id);
        }

        public List<PhoneModel> GetPhonesByBrand(string brand)
        {
            return PhoneModels.Where(phone => phone.Brand.ToLower().Equals(brand.ToLower())).ToList();
        }

        public PhoneModel CreatePhone(CreatePhoneView createPhoneView)
        {
            var mappedPhoneModel = _mapper.Map<PhoneModel>(createPhoneView);
            PhoneModels.Add(mappedPhoneModel);
            return mappedPhoneModel;
        }

        public PhoneModel? UpdatePhone(UpdatePhoneView updatePhoneView)
        {
            var existingPhone = PhoneModels.FirstOrDefault(existingPhone => existingPhone.Id == updatePhoneView.Id);

            if (existingPhone == null)
            {
                return null;
            }

            _mapper.Map(updatePhoneView, existingPhone);
            return existingPhone;
        }

        public void DeletePhone(Guid id)
        {
            PhoneModels.RemoveAll(existingPhone => existingPhone.Id == id);
        }

        public List<PhoneModel> SearchPhones(string search)
        {
            return _mapper.Map<List<PhoneModel>>(
                PhoneModels.Where(phone => phone.Brand.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}