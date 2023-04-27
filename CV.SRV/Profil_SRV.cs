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
            dtos.Add(new Profil_DTO()
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
            });
        }

        return dtos;
    }

    public Profil_DTO GetByID(Profil_DTO dto)
    {
        var dal = ProfilDepotDal.GetById(dto.Id);
        dto.Id = dal.Id;
        dto.Name = dal.Name;
        dto.LastName = dal.LastName;
        dto.Pdp = dal.Pdp;
        dto.Ddn = dal.Ddn;
        dto.Mail = dal.Mail;
        dto.Phone = dal.Phone;
        dto.City = dal.City;
        dto.Job = dal.Job;
        dto.CurrentSchool = dal.CurrentSchool;
        dto.Description = dal.Description;
        return dto;
    }

    public Profil_DTO Insert(Profil_DTO dto)
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
        dal = ProfilDepotDal.Insert(dal);
        return dto;
    }

    public Profil_DTO Delete(Profil_DTO dto)
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
        dal = ProfilDepotDal.Delete(dal);
        return dto;
    }
}