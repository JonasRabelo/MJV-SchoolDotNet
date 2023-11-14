using Aula13_11.Dal;
using Aula13_11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aula13_11.Controllers
{

    public class HomeController : Controller
    {
        private readonly BancoContext _banco;

        public HomeController()
        {
            _banco = new BancoContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarUsuario()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioModel usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_banco.InserirUsuario(usuarioModel)) TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    else TempData["MensagemErro"] = "Ops, Usuário não cadastrado, tente novamente!";

                    return RedirectToAction("Index");
                }
                return View(usuarioModel);
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "Ops, Usuário não cadastrado, tente novamente!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ListarUsuario()
        {
            try
            {
                return View(_banco.ListarUsuarios());
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            try
            {
                UsuarioModel usuario = _banco.BuscarUsuarioPorId(id);
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (_banco.EditarUsuario(usuario)) TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                else TempData["MensagemErro"] = "Usuário não editado, tente novamente!";

                return RedirectToAction("ListarUsuario");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro: {ex.Message}";
                return RedirectToAction("ListarUsuario");
            }
        }

        public IActionResult ApagarUsuario(int id)
        {
            try
            {
                return View(_banco.BuscarUsuarioPorId(id));
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                if (_banco.ApagarUsuario(id)) TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                else TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário";
                return RedirectToAction("ListarUsuario");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro: {ex.Message}";
                return RedirectToAction("ListarUsuario");
            }



        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}