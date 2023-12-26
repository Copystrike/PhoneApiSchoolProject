using AutoMapper;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public class InMemoryOsService : IOsService
    {
        private readonly IMapper _mapper;

        private static readonly List<OsModel> OsModels = new List<OsModel>
        {
            new(Guid.Parse("cd8fd36a-b3f8-414d-bb7e-b7e2ff28ca47"), "Android", "v11", "Google",
                new DateTime(2008, 9, 23), true),
            new(Guid.Parse("ff1c7f14-eb7b-4826-b385-6b1c1051232e"), "iOS", "v14", "Apple", new DateTime(2007, 6, 29),
                false),
            new(Guid.Parse("51c1c30c-b4e6-4fec-8821-c1623b1100ca"), "Windows", "v10", "Microsoft",
                new DateTime(2000, 1, 1), false),
            new(Guid.Parse("41f75c18-c009-4db7-a0d8-95c89a29e646"), "Linux", "v5.10", "Linux Foundation",
                new DateTime(1991, 8, 25), true),
        };

        public InMemoryOsService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<OsModel> GetAllOs()
        {
            return OsModels;
        }

        public OsModel? GetOsById(Guid id)
        {
            return OsModels.FirstOrDefault(os => os.Id == id);
        }

        public List<OsModel> GetByOpenSource(bool isOpenSource)
        {
            return OsModels.Where(os => os.IsOpenSource == isOpenSource).ToList();
        }

        public OsModel CreateOs(CreateOsView os)
        {
            var osModel = _mapper.Map<OsModel>(os);

            OsModels.Add(osModel);
            return osModel;
        }

        public OsModel? UpdateOs(UpdateOsView osModel)
        {
            var existingOs = OsModels.FirstOrDefault(os => os.Id == osModel.Id);

            if (existingOs == null)
            {
                return null;
            }

            _mapper.Map(osModel, existingOs);
            return existingOs;
        }

        public void DeleteOs(Guid id)
        {
            var existingOs = OsModels.FirstOrDefault(os => os.Id == id);

            if (existingOs != null)
            {
                OsModels.Remove(existingOs);
            }
        }

        public List<OsModel> SearchOs(string search)
        {
            return OsModels
                .Where(os => os.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}