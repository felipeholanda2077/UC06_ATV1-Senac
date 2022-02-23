using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;
using MySql.Data.MySqlClient;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //Retorno da index
        {
            return View();
        }

        [HttpPost] //Cadastrar Formulario
        public IActionResult Cadastrar(Interesse cad)
        {
            DatabaseService dbs = new DatabaseService();
            try
            {
                dbs.CadastraInteresse(cad);
                ModelState.Clear();
                ViewData["Mensagem"] = "Cadastrado confirmado";


            } catch(MySqlException e) {
              _logger.LogError(e.Message);
              return View("Erro", e.Message);
            } 
            catch (Exception e)
            {
                _logger.LogError("Erro ao cadastrar o item: " + e.Message);
                return View("Erro", "Erro ao cadastrar o item: " + e.Message);
            }

           return View("Index");
        }

    }
}
