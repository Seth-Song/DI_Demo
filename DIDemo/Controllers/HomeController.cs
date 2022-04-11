
using DIDemo.Models;
using DIDemo.Services.Interface;
using DIDemo.Services.Interface.IMultipleServiceOneInterface;
using DIDemo.Services.Service.MultipleServiceOneInterface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DIDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMethodA _methodA;
        private readonly IService _Service1;
        private readonly IService _Service2;
        private readonly IServiceProvider _serviceProvider;

        private IServiceA _serviceA;

        public HomeController(ILogger<HomeController> logger, IServiceA serviceA , IMethodA methodA, Func<Type, IService> func, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceA = serviceA;
            _methodA = methodA;
            _Service1 = func(typeof(Service1));
            _Service2 = func(typeof(Service2));
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            try
            {

                //Multiple Service implementations for one interface
                //var s1 = _Service1.Service();
                //var s2 = _Service2.Service();

                //Multiple constructors
                //_methodA.A();

                //ServiceLocator.Instance.GetService<IMethodA>().A();

                _serviceA.A();

                _serviceProvider.GetService<IMethodA>().A();
                var services = _serviceProvider.GetServices<IMethodA>();
            }
            catch (Exception)
            {

                throw;
            }

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