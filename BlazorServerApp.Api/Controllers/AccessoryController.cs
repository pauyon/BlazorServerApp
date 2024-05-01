using AutoMapper;
using BlazorServerApp.Shared.Domain.Repositories;
using BlazorServerApp.Shared.Domain.Entities;
using BlazorServerApp.Shared.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        protected ApiResponse _response;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccessoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _response = new ApiResponse();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessory>>> GetAll()
        {
            var result = await _unitOfWork.AccessoryRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accessory>> GetById(int id)
        {
            var result = await _unitOfWork.AccessoryRepository.Get(x => x.Id == id);

            if (result == null)
            {
                return NotFound("Accessory not found.");
            }

            return Ok(result);
        }

        [HttpGet("temporal/{id}")]
        public async Task<ActionResult<Accessory>> GetByIdTemporal(int id)
        {
            var result = await _unitOfWork.AccessoryRepository.GetTemporal(id);

            if (result == null)
            {
                return NotFound("User not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Accessory>> AddAccessory(Accessory accessory)
        {
            var result = await _unitOfWork.AccessoryRepository.Add(accessory);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Accessory>>> UpdateAccessory(Accessory accessory)
        {
            var result = await _unitOfWork.AccessoryRepository.Update(accessory);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAccessory(int id)
        {
            var result = await _unitOfWork.AccessoryRepository.Delete(id);
            return Ok(result);
        }
    }
}
