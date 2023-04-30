using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class Experience_SRV
{
    protected Experience_depot_DAL experienceDepotDal;

    public Experience_SRV()
    {
        experienceDepotDal = new Experience_depot_DAL();
    }

    public List<Experience_DTO> GetAll()
    {
        var dals = experienceDepotDal.GetAll();
        var dtos = new List<Experience_DTO>();
        foreach (var dal in dals)
        {
            dtos.Add(CreateDtoByDal(dal));
        }

        return dtos;
    }

    public Experience_DTO GetByID(Experience_DTO dto)
    {
        var dal = experienceDepotDal.GetById(dto.Id);
        return CreateDtoByDal(dal);
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