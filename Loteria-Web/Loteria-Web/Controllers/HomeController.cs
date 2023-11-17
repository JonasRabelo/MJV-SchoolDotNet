using Data.Repository.IRepository;
using Loteria_Web.Enums;
using Loteria_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Loteria_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioRepository<UsuarioModel> _usuarioRepository;
        private readonly IJogoRepository<JogoModel> _jogoRepository;
        public HomeController(IUsuarioRepository<UsuarioModel> usuario, IJogoRepository<JogoModel> jogo)
        {
            _usuarioRepository = usuario;
            _jogoRepository = jogo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerificarNome(string nome)
        {
            UsuarioModel usuario = _usuarioRepository.Get(nome);
            if (usuario.Saldo != 0)
                return RedirectToAction("Principal", "Home", new { id = usuario.Id });
            usuario = _usuarioRepository.CreateByName(nome);
            return RedirectToAction("SolicitarSaldo", "Home", new { id = usuario.Id });
        }

        public IActionResult SolicitarSaldo(int id)
        {
            UsuarioModel usuarioModel = _usuarioRepository.GetById(id);
            return View(usuarioModel);
        }

        [HttpPost]
        public IActionResult AdicionarSaldo(int id, double saldo)
        {
            UsuarioModel usuarioModel = _usuarioRepository.GetById(id);
            usuarioModel.Saldo += saldo;
            _usuarioRepository.Update(usuarioModel);
            return RedirectToAction("Principal", "Home", new { id = usuarioModel.Id });
        }


        public IActionResult Principal(int id)
        {
            return View(_usuarioRepository.GetById(id));
        }

        public IActionResult Criar(int id)
        {
            ViewBag.Id = id.ToString();
            return View();
        }

        public IActionResult CriarJogo(int usuarioId, JogosEnums NomeDoJogo)
        {
            JogoModel jogoModel = new JogoModel();
            LotericaSorteador.Loterica loterica = new LotericaSorteador.Loterica();
            switch (NomeDoJogo)
            {
                case JogosEnums.MegaSena:
                    jogoModel.Game = loterica.JogoEmString(loterica.JogarMegaSena());
                    jogoModel.NomeDoJogo = "MegaSena";
                    jogoModel.ValorDoJogo = 5.0;
                    break;
                case JogosEnums.LotoFacil:
                    jogoModel.Game = loterica.JogoEmString(loterica.JogarLotofacil());
                    jogoModel.NomeDoJogo = "Lotofacil";
                    jogoModel.ValorDoJogo = 3.0;
                    break;
                case JogosEnums.LotoMania:
                    jogoModel.Game = loterica.JogoEmString(loterica.JogarLotomania());
                    jogoModel.NomeDoJogo = "Lotomania";
                    jogoModel.ValorDoJogo = 3.0;
                    break;
                case JogosEnums.Quina:
                    jogoModel.Game = loterica.JogoEmString(loterica.JogarQuina());
                    jogoModel.NomeDoJogo = "Quina";
                    jogoModel.ValorDoJogo = 2.5;
                    break;
            }
            jogoModel.UsuarioId = usuarioId;
            UsuarioModel usuario = _usuarioRepository.GetById(usuarioId);
            if (usuario.Saldo >= jogoModel.ValorDoJogo)
            {
                if (_jogoRepository.Create(jogoModel))
                {
                    usuario.Saldo -= jogoModel.ValorDoJogo;
                    _usuarioRepository.Update(usuario);
                    TempData["MensagemSucesso"] = "Jogo feito com sucesso";
                }
            }
            else
            {
                TempData["MensagemErro"] = "Ops, Saldo Insuficiente, adiciona mais fundos.";
            }
            return RedirectToAction("ListarJogos", "Home", new { id = usuarioId });
        }

        public IActionResult ListarJogos(int id)
        {
            ViewBag.Id = id.ToString();
            List<JogoModel> jogos = _jogoRepository.GetAll(id);
            return View(jogos);
        }

        public IActionResult DeletarJogo(int id, int usuarioId)
        {
            double valorJogo = _jogoRepository.GetValorDoJogoById(id);

            if (_jogoRepository.Delete(id))
            {
                TempData["MensagemSucesso"] = "Jogo apagado com sucesso";
                UsuarioModel usuario = _usuarioRepository.GetById(usuarioId);
                usuario.Saldo += valorJogo;
                _usuarioRepository.Update(usuario);
            }
            else TempData["MensagemErro"] = "Ops, não foi possível apagar o jogo";

            return RedirectToAction("ListarJogos", "Home", new { id = usuarioId });
        }

        public IActionResult Sair()
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
