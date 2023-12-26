using AutoMapper;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.View;

namespace PhoneApiSchoolProject.Services;

public class DbAppsService : IAppsService
{
    private readonly PhoneContext _context;
    private readonly IMapper _mapper;

    public DbAppsService(IMapper mapper, PhoneContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<AppsModel> GetAllApps()
    {
        return _context.PhoneApps.ToList();
    }

    public AppsModel? GetAppById(Guid id)
    {
        return _context.PhoneApps.FirstOrDefault(a => a.Id == id);
    }

    public List<AppsModel> GetAppsByIsPaid(bool isPaid)
    {
        return _context.PhoneApps.Where(a => a.Price > 0).ToList();
    }

    public AppsModel CreateApp(CreateAppView app)
    {
        var mappedApp = _mapper.Map<AppsModel>(app);
        _context.PhoneApps.Add(mappedApp);
        _context.SaveChanges();
        return mappedApp;
    }

    public AppsModel? UpdateApp(UpdateAppView app)
    {
        var existingApp = _context.PhoneApps.FirstOrDefault(a => a.Id == app.Id);

        if (existingApp == null)
        {
            return null;
        }

        _mapper.Map(app, existingApp);

        return existingApp;
    }

    public void DeleteApp(Guid id)
    {
        var appToDelete = _context.PhoneApps.FirstOrDefault(a => a.Id == id);

        if (appToDelete == null) return;

        _context.PhoneApps.Remove(appToDelete);
        _context.SaveChanges();
    }

    public List<AppsModel> SearchApps(string name)
    {

        name = name.ToLower();
        
        return _context.PhoneApps
            .Where(a => a.Name.ToLower().Contains(name))
            .ToList();
    }

    public List<AppsModel> GetAppsByOsId(Guid osId)
    {
        return _context.PhoneApps.Where(appsModel => appsModel.Id == osId).ToList();
    }
}