using CMP.Models;
using CMP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class clientmsaController : ControllerBase
    {

        private readonly IClientMSARepository _clientMSARepository;

        public clientmsaController(ClientMSARepository clientMSARepository)
        {
            _clientMSARepository = clientMSARepository;
        }
        // GET: api/<ClientMSAController>
        [HttpGet]
        public IActionResult Get()
        {
            var clientMSAs = _clientMSARepository.GetClientMSAs();
            return new OkObjectResult(clientMSAs);
        }

        // GET api/<ClientMSAController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var clientMSA =  _clientMSARepository.GetClientMSAByID(id);
            return new OkObjectResult(clientMSA);
        }

        // POST api/<ClientMSAController>
        [HttpPost]
        public IActionResult Post([FromBody] ClientMSA  clientMSA)
        {
            using (var scope =new  TransactionScope())
            {
                _clientMSARepository.InsertClientMSA(clientMSA);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = clientMSA.ClientMSAId } , clientMSA);
            }

        }

        // PUT api/<ClientMSAController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientMSA clientMSA)
        {
            if(clientMSA != null)
            {
                using( var scope = new TransactionScope())
                {
                    _clientMSARepository.UpdateClientMSA(clientMSA);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<ClientMSAController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientMSARepository.DeleteClientMSA(id);
            return new OkResult();
        }
    }
}
