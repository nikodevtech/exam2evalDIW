using Microsoft.AspNetCore.Mvc;
using nalvata.Models;
using nalvata.Servicios;
using System.Diagnostics;

namespace nalvata.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVajillaService _vajillaService;
        private readonly IMenuService _menuService;
        private readonly IPrestamoService _prestamoService;

        public HomeController(ILogger<HomeController> logger, IMenuService menuService, IVajillaService vajillaService, IPrestamoService prestamoService)
        {
            _logger = logger;
            _menuService = menuService;
            _vajillaService = vajillaService;
            _prestamoService = prestamoService;
        }

        public IActionResult Index()
        {

            int opcion;
            bool cerrarMenu = false;

            do
            {
                try
                {
                    opcion = _menuService.CargarMenu();
                    switch (opcion)
                    {
                        case 1:
                            _vajillaService.save();
                            break;
                        case 2:
                            _vajillaService.findAll();
                            break;
                        case 3:
                            _prestamoService.RealizarPrestamo();
                            break;
                        case 0:
                            cerrarMenu = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida, presione una tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Error] Ocurrió un error no esperado: {e.Message}");
                }

            } while (!cerrarMenu);

            Console.WriteLine("Programa finalizado, pulse una tecla para continuar...");
            Console.ReadKey(true);


            return View();


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
