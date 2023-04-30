using CV.DTO;
using CV.SRV;
using Microsoft.AspNetCore.Mvc;
namespace CV.API.Controllers;


[ApiController]
[Route("[controller]")]
public class Profil_API
{
    private Profil_SRV Service;
    public Profil_API(Profil_SRV service)
    {
        Service = service;
    }
    // [HttpGet]
    // [Route("/{id:int}")]
    // public Profil_DTO GetById(int id)
    // {
    //     var dto = new Profil_DTO();
    //     dto.Id = id;
    //     return Service.GetByID(dto);
    // }
    
    [HttpGet]
    [Route("{uri}")]
    public Profil_DTO GetByUri(string uri)
    {
        return Service.GetByUri(uri);
    }
    
    [HttpGet]
    public List<Profil_DTO> GetAll()
    {
        return Service.GetAll();
    }
}