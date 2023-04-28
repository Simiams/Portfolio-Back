namespace CV.DAL;

public class School_DAL
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    
    public School_DAL(int id, string city, string url, string description, string name)
        => (Id, City, Url, Description, Name) = (id, city, url, description, name);
}