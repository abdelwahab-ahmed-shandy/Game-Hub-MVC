namespace GameZone.Services;

public class CatgeoriesService : ICatgeoriesService
{
    private readonly ApplicationDbContext _context;

    public CatgeoriesService(ApplicationDbContext context)
    {
          _context = context;
    }
    public IEnumerable<SelectListItem> GetSelectList()
    {
            
          return _context.Categories
	           .Select(C => new SelectListItem { Value = C.Id.ToString(), Text = C.Name })
	           .OrderBy(C => C.Text)
	           .ToList();
    }
}

      