using EstudoWeb.Models;
using EstudoWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EstudoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public OperacaoService OperacaoService1 { get; set; }
        public OperacaoService OperacaoService2 { get; set; }

        public HomeController(ILogger<HomeController> logger, OperacaoService operacaoService1, OperacaoService operacaoService2)
        {
            _logger = logger;
            OperacaoService1 = operacaoService1;
            OperacaoService2 = operacaoService2;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string DependencyInjection()
        {
            return $@"
                      Primeira instância - 
                        Transient: {OperacaoService1.Transient.OperacaoId};
                        Scoped: {OperacaoService1.Scoped.OperacaoId};
                        Singleton: {OperacaoService1.Singleton.OperacaoId};
                        SingletonInstance: {OperacaoService1.SingletonInstance.OperacaoId};

                      
                      Segunda instância - 
                        Transient: {OperacaoService2.Transient.OperacaoId};
                        Scoped: {OperacaoService2.Scoped.OperacaoId};
                        Singleton: {OperacaoService2.Singleton.OperacaoId};
                        SingletonInstance: {OperacaoService2.SingletonInstance.OperacaoId};


OBSERVE QUE EM AMBAS INSTÂNCIAS, O SingletonInstance É O MESMO E SEMPRE ZERADO.
POIS QUANDO EU INSTANCIO, EU PASSO O GUID DEFINIDO O MESMO SE APLICA PARA O SINGLETON, QUE GERA UM GUID QUANDO A APLICAÇÃO É EXECUTADA.

O SCOPED GERA O MESMO GUID PARA AMBAS AS INSTÂNCIAS, MAS UM POR REQUEST, POR ISSO ELE MUDA A CADA REFRESH, MAS É O MESMO PARA AMBOS.

O TRANSIENT É DIFERENTE. OBSERVE QUE ELE GERA UM POR INSTÂNCIA A CADA REFRESH, E POR QUE? PORQUE ELE GERA UMA INSTÂNCIA NA INJEÇÃO DE DEPENDÊNCIA PARA CADA INSTÂNCIA DE SERVICE.
NÃO SEI SE FICOU MEIO CONFUSA A FRASE ACIMA, MAS NO TRANSIENT ELE GERA UMA POR 'USO' (INSTÂNCIA) DA SERVICE)";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
