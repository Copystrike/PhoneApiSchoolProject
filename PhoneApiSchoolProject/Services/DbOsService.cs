using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneApiSchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services
{
    public class DbOsService : IOsService
    {
        private readonly PhoneContext _context;
        private readonly IMapper _mapper;

        public DbOsService(PhoneContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OsModel> GetAllOs()
        {
            return _context.PhoneOs.ToList();
        }

        public OsModel? GetOsById(Guid id)
        {
            return _context.PhoneOs.FirstOrDefault(o => o.Id == id);
        }

        public List<OsModel> GetByOpenSource(bool isOpenSource)
        {
            return _context.PhoneOs.Where(o => o.IsOpenSource == isOpenSource).ToList();
        }

        public OsModel CreateOs(CreateOsView os)
        {
            var osModel = _mapper.Map<OsModel>(os);

            _context.PhoneOs.Add(osModel);
            _context.SaveChanges();
            return osModel;
        }

        public OsModel? UpdateOs(UpdateOsView osModel)
        {
            var existingOs = _context.PhoneOs.FirstOrDefault(o => o.Id == osModel.Id);

            if (existingOs == null) return existingOs;
            
            _mapper.Map(osModel, existingOs);
            _context.SaveChanges();
            return existingOs;
        }

        public void DeleteOs(Guid id)
        {
            var osToDelete = _context.PhoneOs.FirstOrDefault(o => o.Id == id);

            if (osToDelete == null) return;
            
            _context.PhoneOs.Remove(osToDelete);
            _context.SaveChanges();
        }

        public List<OsModel> SearchOs(string search)
        {
            
            search = search.ToLower();
            
            return _context.PhoneOs
                .Where(o => o.Name.ToLower().Contains(search))
                .ToList();
        }
    }
}