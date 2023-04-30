using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class Experience_SRV
{
    protected Experience_depot_DAL experienceDepotDal;
    protected Competence_SRV competenceSrv;
    protected Profil_SRV profilSrv;

    public Experience_SRV()
    {
        experienceDepotDal = new Experience_depot_DAL();
    }

    public List<Experience_DTO> GetAll()
    {
        competenceSrv = new Competence_SRV();
        var dals = experienceDepotDal.GetAll();
        var dtos = new List<Experience_DTO>();
        foreach (var dal in dals)
        {
            var dto = CreateDtoByDal(dal);
            dto.Competences = competenceSrv.GetAllByExperienceId(dto.Id);
            dtos.Add(dto);
        }

        return dtos;
    }

    public Experience_DTO GetByID(Experience_DTO dto)
    {
        var dal = experienceDepotDal.GetById(dto.Id);
        return CreateDtoByDal(dal);
    }

    public Experience_DTO GetExperienceByUriAndUriPorfil(string uriProfil, string uriExperience)
    {
        profilSrv = new Profil_SRV();
        int idProfil = profilSrv.GetByUri(uriProfil).Id;
        var dal = experienceDepotDal.GetExperienceByUriAndIdPorfil(idProfil, uriExperience);
        return CreateDtoByDal(dal);
    }
    public List<Experience_DTO> GetAllShortByProfilId(int id)
    {
        competenceSrv = new Competence_SRV();
        var dals = experienceDepotDal.GetAllShortByProfilId(id);
        var dtos = new List<Experience_DTO>();
        foreach (var dal in dals)
        {
            var dto = CreateDtoByDal(dal);
            dto.Competences = competenceSrv.GetAllByExperienceId(dto.Id);
            dtos.Add(dto);
        }
        return dtos;
    }
    public Experience_DTO Insert(Experience_DTO dto)
    {
        var dal = CreateDalByDto(dto);
        dal = experienceDepotDal.Insert(dal);
        return dto;
    }

    public Experience_DTO Delete(Experience_DTO dto)
    {
        var dal = CreateDalByDto(dto);
        dal = experienceDepotDal.Delete(dal);
        return dto;
    }

    public Experience_DTO CreateDtoByDal(Experience_DAL dal)
    {
        var dto = new Experience_DTO()
        {
            Id = dal.Id,
            Job = dal.Job,
            EndPeriod = dal.EndPeriod,
            StartPeriod = dal.StartPeriod,
            Url = dal.Url,
            Description = dal.Description,
            Company = dal.Company   
        };
        return dto;
    }

    public Experience_DAL CreateDalByDto(Experience_DTO dto)
    {
        var dal = new Experience_DAL(
            dto.Id,
            dto.Job,
            dto.EndPeriod,
            dto.StartPeriod,
            dto.Description,
            dto.Url,
            dto.Company
        );
        return dal;
    }
}