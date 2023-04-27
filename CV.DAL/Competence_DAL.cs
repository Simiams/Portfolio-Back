namespace CV.DAL;

public class Competence_DAL
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public DateTime startPractice { get; set; }
    public string url { get; set; }
    
    public Competence_DAL(int id, string name, string description, string icon, DateTime startPractice, string url) 
        => (Id, Name, Description, Icon, this.startPractice, this.url) = (id, name, description, icon, startPractice, url);
}