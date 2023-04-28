using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class Profil_SRV
{
    protected Profil_depot_DAL ProfilDepotDal;

    public Profil_SRV()
    {
        ProfilDepotDal = new Profil_depot_DAL();
    }

    public List<Profil_DTO> GetAll()
    {
        var dals = ProfilDepotDal.GetAll();
        var dtos = new List<Profil_DTO>();
        foreach (var dal in dals)
        {
            dtos.Add(CreateDtoByDal(dal));
        }

        return dtos;
    }

    public Profil_DTO GetByID(Profil_DTO dto)
    {
        var dal = ProfilDepotDal.GetById(dto.Id);
        return CreateDtoByDal(dal);;
    }

    public Profil_DTO Insert(Profil_DTO dto)
    {
        var dal = CreateDalBYDto(dto);
        dal = ProfilDepotDal.Insert(dal);
        return dto;
    }

    public Profil_DTO Delete(Profil_DTO dto)
    {
        var dal = CreateDalBYDto(dto);
        dal = ProfilDepotDal.Delete(dal);
        return dto;
    }
    
    public Profil_DTO CreateDtoByDal(Profil_DAL dal)
    {
        var dto = new Profil_DTO()
        {
            Id = dal.Id,
            Name = dal.Name,
            LastName = dal.LastName,
            Pdp = dal.Pdp,
            Ddn = dal.Ddn,
            Mail = dal.Mail,
            Phone = dal.Phone,
            City = dal.City,
            Job = dal.Job,
            CurrentSchool = dal.CurrentSchool,
            Description = dal.Description
        };
        return dto;
    }

    public Profil_DAL CreateDalBYDto(Profil_DTO dto)
    {
        var dal = new Profil_DAL(
            dto.Id,
            dto.Name,
            dto.LastName,
            dto.Pdp,
            dto.Ddn,
            dto.Mail,
            dto.Phone,
            dto.City,
            dto.Job,
            dto.CurrentSchool,
            dto.Description
        );
        return dal;
    }
}