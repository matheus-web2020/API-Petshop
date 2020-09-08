using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_PetShop.Domains;
using API_PetShop.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        RacaRepository repos = new RacaRepository();

        // GET: api/<TipoDePetController>
        [HttpGet]
        public List<Raca> Get()
        {
            return repos.LerTudo();
        }

        // GET api/<TipoDePetController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repos.BuscarPorId(id);
        }

        // POST api/<TipoDePetController>
        [HttpPost]
        public Raca Post([FromBody] Raca r)
        {
            return repos.Cadastrar(r);
        }

        // PUT api/<TipoDePetController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca r)
        {
            return repos.Alterar(id, r);
        }

        // DELETE api/<TipoDePetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.Excluir(id);
        }
    }
}
