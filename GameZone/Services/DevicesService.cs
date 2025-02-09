
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly ApplicationDbContext _context;

        public DevicesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Devices
                    .Select(D => new SelectListItem { Value = D.Id.ToString(), Text = D.Name })
                    .OrderBy(D => D.Text)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
