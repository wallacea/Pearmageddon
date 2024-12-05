using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pearmageddon.ExtensionMethods;
using Pearmageddon.Models;
using Pearmageddon.Objects;
using Pearmageddon.Repositories;

namespace Pearmageddon.Controllers
{
    [Route("api/PearTypes")]
    [ApiController]
    public class PearTypeAPIController : ControllerBase
    {

        private readonly IPearTypeRepository _PearTypeRepository;

        public PearTypeAPIController(IPearTypeRepository pearTypeRepository)
        {
            _PearTypeRepository = pearTypeRepository;
        }

        [HttpGet]
        public IEnumerable<PearType> Get()
        {
            return _PearTypeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public PearType Get(int id)
        {
            return _PearTypeRepository.Get(id);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] PearTypeModel pearTypeModel)
        {
            if (ModelState.IsValid)
            {
                _PearTypeRepository.Save(pearTypeModel.ToDataObject());
                return Created();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] PearType pearType)
        {
            if (ModelState.IsValid)
            {
                _PearTypeRepository.Save(pearType);
                return Ok();
            }
            return BadRequest();
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _PearTypeRepository.Delete(id);
        //    return Ok();
        //}
    }
}
