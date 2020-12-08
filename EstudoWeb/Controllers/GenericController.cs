using EstudoWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstudoWeb.Controllers
{
    public class GenericController : Controller
    {
        private readonly IGenericRepository<Cliente> _genericRepository;

        public GenericController(IGenericRepository<Cliente> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public void Index()
        {
            _genericRepository.Adicionar(new Cliente());
        }
    }

    public class Cliente
    {
    }
}
