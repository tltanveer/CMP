using Microsoft.AspNetCore.Mvc;
using CMP.Repository;
using CMP.Models;
using Microsoft.OpenApi.Writers;
using System.Transactions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientndaController : ControllerBase
    {

        private IClientNDARepository _clientNDARepository;

        public clientndaController(IClientNDARepository clientNDARepository)
        {
            _clientNDARepository = clientNDARepository;
        }
        // GET: api/<ClientNDAController>
        [HttpGet]
        public IActionResult Get()
        {
            //var clientNDAs = _clientNDARepository.GetClientNDAs();
            return new OkObjectResult(_clientNDARepository.GetClientNDAs()); ;
        }

        // GET api/<ClientNDAController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var clientNDA = _clientNDARepository.GetClientNDAByID(id);
           return new OkObjectResult(clientNDA); 
        }

        // POST api/<ClientNDAController>
        [HttpPost]
        public IActionResult Post([FromBody] ClientNDA clientNDA)
        {
            using (var Scope = new TransactionScope())
            {
                _clientNDARepository.InsertClientNDA(clientNDA);
                Scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = clientNDA.ClientNDAId }, clientNDA);

            }
          
        }

        // PUT api/<ClientNDAController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientNDA clientNDA)
        {
            if(clientNDA != null)
            {
                using( var scope = new TransactionScope())
                {
                    _clientNDARepository.UpdateClientNDA(clientNDA);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<ClientNDAController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientNDARepository.DeleteClientNDA(id);
            return new OkResult();
        }
    }
}
