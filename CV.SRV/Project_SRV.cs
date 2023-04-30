using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class Project_SRV
{
    protected Project_depot_DAL projectDepotDal;
    protected Competence_SRV CompetenceSrv;
    protected Profil_SRV profilSrv;
    
    public Project_SRV()
    {
        projectDepotDal = new Project_depot_DAL();
    }
    
    public List<Project_DTO> GetAll()
    {
        var dals = projectDepotDal.GetAll();
        var dtos = new List<Project_DTO>();
        foreach (var dal in dals)
        {
            dtos.Add(CreateDtoByDal(dal));
        }
        
        return dtos;
    }

    public Project_DTO GetByUri(string Uri)
    {
        var dal = projectDepotDal.GetByUri(Uri);
        return CreateDtoByDal(dal);
    }

    public Project_DTO GetProjectByUriProjectAndUriProfil(string uriProfil, string uriProject)
    {
        profilSrv = new Profil_SRV();
        int idProfil = profilSrv.GetByUri(uriProfil).Id;
        var dal = projectDepotDal.GetProjectByUriProjectAndIdProfil(uriProject, idProfil);
        return CreateDtoByDal(dal);
    }

    public List<Project_DTO> GetAllShortByIdProfil(int idProfil)
    {
        var dals = projectDepotDal.GetAllShortByIdProfil(idProfil);
        var dtos = new List<Project_DTO>();
        foreach (var dal in dals)
        {
            dtos.Add(CreateDtoByDal(dal));
        }
        Console.WriteLine(6);

        return dtos;
    }

    public Project_DTO CreateDtoByDal(Project_DAL dal)
    {
        CompetenceSrv = new Competence_SRV();
        var dto = new Project_DTO()
        {
            Id = dal.Id,
            Name = dal.Name,
            Uri = dal.Uri,
            Icon = dal.Icon,
            Date = dal.Date,
            Description = dal.Description,
            PageHTML = dal.PageHTML,
            PageMarkDown = dal.PageMarkDown,
            IdProfil = dal.IdProfil,
            Competences = CompetenceSrv.GetAllByProjectId(dal.Id)
        };
        return dto;
    }

    public Project_DAL CreateDalBYDto(Project_DTO dto)
    {
        var dal = new Project_DAL(
            dto.Id,
            dto.Name,
            dto.Uri,
            dto.Icon,
            dto.Date,
            dto.Description,
            dto.PageHTML,
            dto.PageMarkDown,
            dto.IdProfil
        );
        return dal;
    }
}