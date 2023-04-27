using System.Data.SqlClient;

namespace CV.DAL;

public abstract class Depot_DAL<Type_DAL> where Type_DAL : class
{
    public string ConnectionString { get; set; }
    protected SqlConnection Connection { get; set; }
    protected SqlCommand Command { get; set; }
    
    public Depot_DAL()
    {
        ConnectionString = "Data Source=localhost;Initial Catalog=CV;Persist Security Info=True;User ID=CV;Password=Pour1foisquetuessobre...";
    }
    
    protected void InitialConnectionAndCommand()
    {
        Connection = new SqlConnection(ConnectionString);
        Command = Connection.CreateCommand();
        Connection.Open();
    }
    
    protected void CloseAndDisposeConnection()
    {
        if (Connection! != null)
        {
            Connection.Close();
            Connection.Dispose();
        }

        if (Command!=null)
        {
            Command.Dispose();
        }  
    }
    
    public abstract List<Type_DAL> GetAll();
    public abstract Type_DAL GetById(int id);
    public abstract Type_DAL Insert(Type_DAL dal);
    public abstract void Update(Type_DAL dal);
    public abstract Type_DAL Delete(Type_DAL dal);
}