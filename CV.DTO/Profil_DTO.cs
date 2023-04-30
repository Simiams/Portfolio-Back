namespace CV.DTO;

public class Profil_DTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Pdp { get; set; }
    public DateTime Ddn { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string Job { get; set; }
    public int? CurrentSchool { get; set; }
    public string Description { get; set; }
    public string? LookingFor { get; set; }
    public string Uri { get; set; }
    public List<Competence_DTO>? Competences { get; set; }
    public List<Experience_DTO>? Experiences { get; set; }
    public List<Project_DTO>? Projects { get; set; }

}