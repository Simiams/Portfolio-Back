namespace CV.DAL;

public class Project_depot_DAL : Depot_DAL<Project_DAL>
{
    public override List<Project_DAL> GetAll()
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Project";
        var reader = Command.ExecuteReader();
        Console.WriteLine("caca");

        var dals = new List<Project_DAL>();
        if (!reader.HasRows)
            return null;
        

        while (reader.Read())
        {
            dals.Add(new Project_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["uri"],
                (string)reader["icon"],
                (DateTime)reader["date"],
                (string)reader["description"],
                (string)reader["pageHTML"],
                (string)reader["pageMarkDown"],
                (int)reader["id_profil"]
            ));
        }
        CloseAndDisposeConnection();
        return dals;
    }

    public List<Project_DAL> GetAllShortByIdProfil(int idProfil)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT id, name, uri, icon, date, id_profil FROM Project WHERE id_profil = @idProfil";
        Command.Parameters.AddWithValue("@idProfil", idProfil);
        var reader = Command.ExecuteReader();
        var dals = new List<Project_DAL>();
        if (!reader.HasRows)
            return null;
        while (reader.Read())
        {
            dals.Add(new Project_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["uri"],
                (string)reader["icon"],
                (DateTime)reader["date"],
                (int)reader["id_profil"]
            ));
        }
        CloseAndDisposeConnection();
        return dals;
    }

    public override Project_DAL GetById(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Project WHERE id = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        if (!reader.HasRows)
            return null;
        Project_DAL dal = null;
        if (reader.Read())
        {
            dal = new Project_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["uri"],
                (string)reader["icon"],
                (DateTime)reader["date"],
                (string)reader["description"],
                (string)reader["pageHTML"],
                (string)reader["pageMarkDown"],
                (int)reader["id_profil"]
                );
        }
        CloseAndDisposeConnection();
        return dal;
    }

    public Project_DAL GetProjectByUriProjectAndIdProfil(string uriProject, int idProfil)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Project WHERE uri = @uri AND id_profil = @idProfil";
        Command.Parameters.AddWithValue("@uri", uriProject);
        Command.Parameters.AddWithValue("@idProfil", idProfil);
        var reader = Command.ExecuteReader();
        if (!reader.HasRows)
            return null;
        Project_DAL dal = null;
        if (reader.Read())
        {
            dal = new Project_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["uri"],
                (string)reader["icon"],
                (DateTime)reader["date"],
                (string)reader["description"],
                (string)reader["pageHTML"],
                (string)reader["pageMarkDown"],
                (int)reader["id_profil"]
            );
        }
        CloseAndDisposeConnection();
        return dal;
    }

    public Project_DAL GetByUri(string Uri)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Project WHERE uri = @uri";
        Command.Parameters.AddWithValue("@uri", Uri);
        var reader = Command.ExecuteReader();
        if (!reader.HasRows)
            return null;
        Project_DAL dal = null;
        if (reader.Read())
        {
            dal = new Project_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["uri"],
                (string)reader["icon"],
                (DateTime)reader["date"],
                (string)reader["description"],
                (string)reader["pageHTML"],
                (string)reader["pageMarkDown"],
                (int)reader["id_profil"]
            );
        }
        CloseAndDisposeConnection();
        return dal;
        
    }
    public override Project_DAL Insert(Project_DAL dal)
    {
        throw new NotImplementedException();
    }

    public override void Update(Project_DAL dal)
    {
        throw new NotImplementedException();
    }

    public override Project_DAL Delete(Project_DAL dal)
    {
        throw new NotImplementedException();
    }
}
