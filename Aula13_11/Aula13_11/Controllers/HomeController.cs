using Aula13_11.Dal;
using Aula13_11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula13_11.Controllers
{

    public class HomeController : Controller
    {
        private int Id = 0;
        private readonly BancoContext _banco;

        public HomeController()
        {
            _banco = new BancoContext();
        }

        public IActionResult Index()
        {
            BancoContext sqlDal = new BancoContext();
            return View();
        }

        public IActionResult CadastrarUsuario()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioModel usuarioModel)
        {
            usuarioModel.Id = Id;
            if (_banco.InserirUsuario(usuarioModel)) TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
            else TempData["MensagemErro"] = "Usuário não cadastrado, tente novamente!";

            return View("Index");
        }

        public IActionResult ListarUsuario()
        {
            return View(_banco.ListarUsuarios());
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _banco.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            if (_banco.EditarUsuario(usuario)) TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
            else TempData["MensagemErro"] = "Usuário não editado, tente novamente!";
            return RedirectToAction("ListarUsuario");
        }

        public IActionResult ApagarUsuario(int id)
        {
            return View(_banco.BuscarUsuarioPorId(id));
        }

        public IActionResult Apagar(int id)
        {
            if (_banco.ApagarUsuario(id)) TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
            else TempData["MensagemErro"] = "Usuário não apagado, tente novamente!";

            return RedirectToAction("ListarUsuario");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}