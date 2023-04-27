using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class Competence_SRV
{
    protected Competence_depot_DAL CompetenceDepotDal;

    public Competence_SRV()
    {
        CompetenceDepotDal = new Competence_depot_DAL();
    }

    public List<Competence_DTO> GetAll()
    {
        var dals = CompetenceDepotDal.GetAll();
        var dtos = new List<Competence_DTO>();
        foreach (var dal in dals)
        {
            dtos.Add(CreateDtoByDal(dal));
        }

        return dtos;
    }

    public Competence_DTO GetByID(Competence_DTO dto)
    {
        var dal = CompetenceDepotDal.GetById(dto.Id);
        return CreateDtoByDal(dal);;
    }

    public Competence_DTO Insert(Competence_DTO dto)
    {
        var dal = CreateDalBYDto(dto);
        dal = CompetenceDepotDal.Insert(dal);
        return dto;
    }

    public Competence_DTO Delete(Competence_DTO dto)
    {
        var dal = CreateDalBYDto(dto);
        dal = CompetenceDepotDal.Delete(dal);
        return dto;
    }

    public Competence_DTO CreateDtoByDal(Competence_DAL dal)
    {
        var dto = new Competence_DTO();
        dto.Id = dal.Id;
        dto.Name = dal.Name;
        dto.Description = dal.Description;
        dto.Icon = dal.Icon;
        dto.startPractice = dal.startPractice;
        dto.url = dal.url;
        return dto;
    }

    public Competence_DAL CreateDalBYDto(Competence_DTO dto)
    {
        var dal = new Competence_DAL(
            dto.Id,
            dto.Name,
            dto.Description,
            dto.Icon,
            dto.startPractice,
            dto.url);
        return dal;

    }
}

