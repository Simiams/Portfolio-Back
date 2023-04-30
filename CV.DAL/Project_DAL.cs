namespace CV.DAL;

public class Project_DAL
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Uri { get; set; }
    public string Icon { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? PageHTML { get; set; }
    public string? PageMarkDown { get; set; }
    public int IdProfil { get; set; }


    public Project_DAL(int id, string name, string uri, string icon, DateTime date, int idProfil)
        => (Id, Name, Uri, Icon, Date, IdProfil) = (id, name, uri, icon, date, idProfil);
    public Project_DAL(int id, string name, string uri, string icon, DateTime date, string description, string pageHtml, string pageMarkDown, int idProfil)
    :this(id, name, uri, icon, date, idProfil)
        =>(Description, PageHTML, PageMarkDown) = (description, pageHtml, pageMarkDown);
}