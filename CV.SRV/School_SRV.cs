using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class School_SRV
{
    protected School_depot_DAL schoolDepotDal;

    public School_SRV()
    {
        schoolDepotDal = new School_depot_DAL();
    }

    public List<School_DTO> GetAll()
    {
        
        var dals = schoolDepotDal.GetAll();
        var dtos = new List<School_DTO>();
        foreach (var dal in dals)
        {
            dtos.Add(CreateDtoByDal(dal));
        }

        return dtos;
    }

    public School_DTO GetByID(School_DTO dto)
    {
        var dal = schoolDepotDal.GetById(dto.Id);
        return CreateDtoByDal(dal);;
    }

    public School_DTO Insert(School_DTO dto)
    {
        var dal = CreateDalBYDto(dto);
        dal = schoolDepotDal.Insert(dal);
        return dto;
    }

    public School_DTO Delete(School_DTO dto)
    {
        var dal = CreateDalBYDto(dto);
        dal = schoolDepotDal.Delete(dal);
        return dto;
    }
    
    public School_DTO CreateDtoByDal(School_DAL dal)
    {
        var dto = new School_DTO()
        {
            Id = dal.Id,
            Name = dal.Name,
            Url = dal.Url,
            City = dal.City,
            Description = dal.Description
        };
        return dto;
    }

    public School_DAL CreateDalBYDto(School_DTO dto)
    {
        var dal = new School_DAL(
            dto.Id,
            dto.City,
            dto.Url,
            dto.Description,
            dto.Name
        );
        return dal;
    }
}