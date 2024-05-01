using AutoMapper;
using BlazorServerApp.Shared.Domain.Repositories;
using BlazorServerApp.Shared.Domain.Entities;
using BlazorServerApp.Shared.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CameraController : ControllerBase
{
    protected ApiResponse _response;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CameraController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _response = new ApiResponse();
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Camera>>> GetAll()
    {
        var result = await _unitOfWork.CameraRepository.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Camera>> GetById(int id)
    {
        var result = await _unitOfWork.CameraRepository.Get(x => x.Id == id);

        if (result == null)
        {
            return NotFound("User not found.");
        }

        return Ok(result);
    }

    [HttpGet("temporal/{id}")]
    public async Task<ActionResult<Camera>> GetByIdTemporal(int id)
    {
        var result = await _unitOfWork.CameraRepository.GetTemporal(id);

        if (result == null)
        {
            return NotFound("User not found.");
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Camera>> AddCamera(Camera camera)
    {
        var result = await _unitOfWork.CameraRepository.Add(camera);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<List<Camera>>> UpdateCamera(Camera camera)
    {
        var result = await _unitOfWork.CameraRepository.Update(camera);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteCamera(int id)
    {
        var result = await _unitOfWork.CameraRepository.Delete(id);
        return Ok(result);
    }
}
