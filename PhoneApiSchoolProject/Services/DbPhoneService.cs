using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneApiSchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public class DbPhoneService : IPhoneService
    {
        private readonly PhoneContext _context;
        private readonly IMapper _mapper;

        public DbPhoneService(PhoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PhoneModel> GetAllPhones()
        {
            return _context.Phones.ToList();
        }

        public PhoneModel? GetPhoneById(Guid id)
        {
            return _context.Phones.FirstOrDefault(p => p.Id == id);
        }

        public List<PhoneModel> GetPhonesByBrand(string brand)
        {
            brand = brand.ToLower();
            return _context.Phones.Where(p => p.Brand.ToLower() == brand).ToList();
        }

        public PhoneModel CreatePhone(CreatePhoneView createPhoneView)
        {
            var phoneModel = _mapper.Map<PhoneModel>(createPhoneView);
            
            _context.Phones.Add(phoneModel);
            _context.SaveChanges();
            return phoneModel;
        }

        public PhoneModel? UpdatePhone(UpdatePhoneView updatePhoneView)
        {
            var existingPhone = _context.Phones.FirstOrDefault(p => p.Id == updatePhoneView.Id);
            
            if (existingPhone != null)
            {
                _mapper.Map(updatePhoneView, existingPhone);
                _context.SaveChanges();
            }
            
            return existingPhone;
        }

        public void DeletePhone(Guid id)
        {
            var phoneToDelete = _context.Phones.FirstOrDefault(p => p.Id == id);

            if (phoneToDelete == null) return;
            
            _context.Phones.Remove(phoneToDelete);
            _context.SaveChanges();
        }

        public List<PhoneModel> SearchPhones(string search)
        {
            
            search = search.ToLower();
            
            return _context.Phones
                .Where(p => p.Brand.ToLower().Contains(search)).ToList();
        }
    }
}