using CV.DTO;
using CV.SRV;
using Microsoft.AspNetCore.Mvc;
namespace CV.API.Controllers;


[ApiController]
[Route("[controller]")]
public class Project_API
{
    private Project_SRV Service;
    public Project_API(Project_SRV service)
    {
        Service = service;
    }
    
    [HttpGet]
    public List<Project_DTO> GetAll()
    {
        return Service.GetAll();
    }
    
    [HttpGet]
    [Route("{uri}")]
    
    public Project_DTO GetByUri(string uri)
    {
        return Service.GetByUri(uri);
    }
    
    // [HttpPost]
    // [Route("caca")]
    // public Project_DTO GetProjectByUriProjectAndUriPorfil(Project_DTO dto)
    // {
    //     return Service.GetProjectByUriProjectAndUriProfil(dto);
    // }
}