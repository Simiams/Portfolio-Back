namespace CV.DAL;

public class Experience_DAL
{
    public int Id { get; set; }
    public string Job { get; set; }
    public DateTime EndPeriod { get; set; }
    public DateTime StartPeriod { get; set; }
    public string? Description { get; set; }
    public string Url { get; set; }
    public string Company { get; set; }
    public Experience_DAL(int id, string job, DateTime endPeriod, DateTime startPeriod, string url, string company)
        => (Id, Job, EndPeriod, StartPeriod, Url, Company) = (id, job, endPeriod, startPeriod, url, company);
    public Experience_DAL(int id, string job, DateTime endPeriod, DateTime startPeriod, string description, string url, string company)
    :this(id, job, endPeriod, startPeriod, url, company)
        => (Description) = (description);
}