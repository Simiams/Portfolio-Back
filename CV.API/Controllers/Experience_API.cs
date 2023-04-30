using CV.DTO;
using CV.SRV;
using Microsoft.AspNetCore.Mvc;
namespace CV.API.Controllers;

[ApiController]
[Route("[controller]")]
public class Experience_API
{
    private Experience_SRV Service;
    public Experience_API(Experience_SRV service)
    {
        Service = service;
    }
    [HttpGet]
    [Route("/{id:int}")]
    public Experience_DTO GetById(int id)
    {
        var dto = new Experience_DTO();
        dto.Id = id;
        return Service.GetByID(dto);
    }
    [HttpGet]
    public List<Experience_DTO> GetAll()
    {
        return Service.GetAll();
    }
}