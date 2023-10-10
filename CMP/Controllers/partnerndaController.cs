using Microsoft.AspNetCore.Mvc;
using CMP.Repository;
using CMP.Models;
using System.Transactions;
using Microsoft.OpenApi.Writers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class partnerndaController : ControllerBase
    {
        private IPartnerNDARepository _partnerNDARepository;
        public partnerndaController(IPartnerNDARepository partnerNDARepository)
        {
            _partnerNDARepository = partnerNDARepository;
        }
        // GET: api/<partnerndaController>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_partnerNDARepository.GetPartnerNDAs());
        }

        // GET api/<partnerndaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_partnerNDARepository.GetPartnerNDAByID(id));
        }

        // POST api/<partnerndaController>
        [HttpPost]
        public IActionResult Post([FromBody] PartnerNDA partnerNDA)
        {
            using( var Scope = new TransactionScope())
            {
                _partnerNDARepository.InsertPartnerNDA(partnerNDA);
                Scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = partnerNDA.PartnerNDAId }, partnerNDA);
            }
        }

        // PUT api/<partnerndaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PartnerNDA partnerNDA)
        {
            if(partnerNDA != null)
            {
                using ( var Scope = new TransactionScope())
                {
                    _partnerNDARepository.UpdatePartnerNDA(partnerNDA);
                    Scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<partnerndaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _partnerNDARepository.DeletePartnerNDA(id);
            return new OkResult();
        }
    }
}
