using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ICatgeoriesService _catgeoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ApplicationDbContext context, ICatgeoriesService categoriesService 
            , IDevicesService devicesService, IGamesService gamesService)
        {
            _context = context;
            _catgeoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel ViewModel = new()
            {
                Categories = _catgeoriesService.GetSelectList(),
                Devices = _devicesService.GetSelectList()
            };
          return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _catgeoriesService.GetSelectList();

                model.Devices = _devicesService.GetSelectList();

                return View(model);
            }
            //save game to DB
            //Save caver to server
            await _gamesService.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
