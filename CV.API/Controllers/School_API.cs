using CV.DTO;
using CV.SRV;
using Microsoft.AspNetCore.Mvc;
namespace CV.API.Controllers;

[ApiController]
[Route("[controller]")]
public class School_API
{
    private School_SRV Service;
    public School_API(School_SRV service)
    {
        Service = service;
    }
    [HttpGet]
    [Route("/{id:int}")]
    public School_DTO GetById(int id)
    {
        var dto = new School_DTO();
        dto.Id = id;
        return Service.GetByID(dto);
    }
    [HttpGet]
    public List<School_DTO> GetAll()
    {
        return Service.GetAll();
    }
}