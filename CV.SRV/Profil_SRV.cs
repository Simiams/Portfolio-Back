using CV.DAL;
using CV.DTO;

namespace CV.SRV;

public class Profil_SRV
{
    protected Profil_depot_DAL ProfilDepotDal;
    protected Competence_SRV CompetenceSrv;
    protected Experience_SRV ExperienceSrv;
    protected Project_SRV projectSrv;

    public Profil_SRV()
    {
        ProfilDepotDal = new Profil_depot_DAL();
        CompetenceSrv = new Competence_SRV();
        ExperienceSrv = new Experience_SRV();
        projectSrv = new Project_SRV();
    }

    public List<Profil_DTO> GetAll()
    {
        var dals = ProfilDepotDal.GetAll();
        var dtos = new List<Profil_DTO>();
        foreach (var dal in dals)
        {
            Console.WriteLine(1);
            var dto = CreateDtoByDal(dal);
            dtos.Add(dto);
            Console.WriteLine(2);
        }
        return dtos;
    }

    public Profil_DTO GetByID(Profil_DTO dto)
    {
        var dal = ProfilDepotDal.GetById(dto.Id);
        return CreateDtoByDal(dal);;
    }

    public Profil_DTO GetByUri(string uri)
    {
        var dal = ProfilDepotDal.GetByUri(uri);
        return CreateDtoByDal(dal);
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
            Description = dal.Description,
            Uri = dal.Uri,
            Competences = CompetenceSrv.GettAllByProfilId(dal.Id),
            Experiences = ExperienceSrv.GetAllShortByProfilId(dal.Id),
            Projects = projectSrv.GetAllShortByIdProfil(dal.Id)
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
            dto.Description,
            dto.LookingFor,
            dto.Uri
        );
        return dal;
    }
}