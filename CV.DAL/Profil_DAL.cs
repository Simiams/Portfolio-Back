namespace CV.DAL;

public class Profil_DAL
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

    public Profil_DAL(int id, string name, string lastName, string pdp, DateTime ddn, string mail, string phone,
        string city, string job, int? currentSchool, string description, string? lookingFor) =>
        (Id, Name, LastName, Pdp, Ddn, Mail, Phone, City, Job, CurrentSchool, Description, LookingFor) = (id, name, lastName, pdp,
            ddn, mail, phone, city, job, currentSchool, description, lookingFor);
}