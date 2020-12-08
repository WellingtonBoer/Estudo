using EstudoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EstudoWeb.Controllers
{
    public class MultiplasClassesController : Controller
    {
        private readonly Func<string, IService> _serviceAcessor;
        public MultiplasClassesController(Func<string, IService> serviceAcessor)
        {
            _serviceAcessor = serviceAcessor;
        }

        public string Index()
        {
            return _serviceAcessor("B").Retorno();
        }
    }
}
