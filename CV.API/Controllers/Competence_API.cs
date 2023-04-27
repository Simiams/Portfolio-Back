using CV.DAL;
using CV.DTO;
using CV.SRV;
using Microsoft.AspNetCore.Mvc;
namespace CV.API.Controllers;


[ApiController]
[Route("[controller]")]
public class Competence_API
{
    private Competence_SRV Service;
    
    public Competence_API(Competence_SRV service)
    {
        Service = service;
    }
    [HttpGet]
    [Route("/{id:int}")]
    public Competence_DTO GetById(int id)
    {
        var dto = new Competence_DTO();
        dto.Id = id;
        return Service.GetByID(dto);
    }
    [HttpGet]
    public List<Competence_DTO> GetAll()
    {
        return Service.GetAll();
    }
}