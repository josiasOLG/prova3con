using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalRSApi.Data;
using PortalRSApi.Models;
using Model.Neg;
using Model.Entity;
using Model.Dao;
namespace PortalRSApi.Controllers
{   
   
    [Route("api/[controller]")]
    public class CustomersController :Controller
    {
       protected readonly ApplicationDbContext _db;

        ClienteNeg objClienteNeg;

        public CustomersController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            objClienteNeg = new ClienteNeg();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok( _db.Customers.OrderBy(c => c.Name).ToList());
                
        }
        [HttpGet]

        public IActionResult Get(int id)
        {
            var customer = _db.Customers.Find(id);
            return Ok(customer);
        }
        [HttpPost]
        public ActionResult Post([FromBody]Cliente customers)
        {
            this.mensagemInicioRegistrar();
            objClienteNeg.create(customers);
            this.MensagemErroRegistrar(customers);

            //_db.Customers.Add(customers);
            //_db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody]Cliente customers)
        {
            //_db.Entry(customers).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_db.SaveChanges();

            this.mensagemInicioRegistrar();
            Cliente objCliente = new Cliente(customers.Id);
            objClienteNeg.update(customers);
            this.MensagemErroRegistrar(customers);
            return Ok();
        }

        //mensagem de erro
        public void MensagemErroRegistrar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
                case 1://campo id vazio
                    ViewBag.MensagemErro = "Erro id";
                    break;

                case 20:
                    ViewBag.MensagemErro = "Insira Nome do Cliente";
                    break;

                case 2:
                    ViewBag.MensagemErro = "3Con nao pode ser usado como nome";
                    break;

                case 8:
                    ViewBag.MensagemErro = "Cliente [" + objCliente.Id + "] já está registrado no sistema";
                    break;

                case 99:
                    ViewBag.MensagemExito = "Cliente [" + objCliente.Name + " " + "] foi inserido no sistema";
                    break;
                case 100://campo id vazio
                    ViewBag.MensagemErro = "Erro";
                    break;

            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Cliente e clique em salvar";
        }


    }
}
