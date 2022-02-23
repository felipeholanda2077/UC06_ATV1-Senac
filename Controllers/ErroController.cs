using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Diagnostics;

namespace projetohotsite.Controllers
{
    public class ErroController : Controller
    {
         private readonly ILogger<ErroController> _logger;

        public ErroController(ILogger<ErroController> logger)
        {
            _logger = logger;
        }
        // O erro 500 é a falha que impede que sites sejam carregados pelo usuário
        [Route("/erro/500")]
        public IActionResult Erro500()
        {
            
            var errosOcorridos = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string erro = @"¯\_(ツ)_/¯";
            if (errosOcorridos != null)
            {
                
                string mensagemErro = errosOcorridos.Error.Message;

                string urlErro = errosOcorridos.Path;
                erro = $"Falha: {mensagemErro} acessando {urlErro} ";
                _logger.LogError(erro);
            }
            return View("Erro", erro);
        }
        // Erro de rota 404 bastante conhecido quando não é localizada uma pagina
        [Route("/erro/404")]
        public IActionResult Erro404()
        {
            
            var errosOcorridos = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            string erro = "Erro 404";
            if (errosOcorridos != null)
            {
                
                string mensagemErro = errosOcorridos.Error.Message;

                string urlErro = errosOcorridos.Path;
                erro = $"Falha: {mensagemErro} acessando {urlErro} ";
                _logger.LogError(erro);
            }
            //Mesagem de Erro retorna
            return View("Erro", erro);
        }
    }
}