namespace CV.DAL;

public class Competence_depot_DAL : Depot_DAL<Competence_DAL>
{
    public override List<Competence_DAL> GetAll()
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Competence";
        var reader = Command.ExecuteReader();
        var dals = new List<Competence_DAL>();
        if (!reader.HasRows)
            return null;
        while (reader.Read())
        {
            dals.Add(new Competence_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["description"],
                (string)reader["icon"],
                (DateTime)reader["startPractice"],
                (string)reader["url"]
            ));
        }

        CloseAndDisposeConnection();
        return dals;
    }

    public override Competence_DAL GetById(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Competence WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        Competence_DAL dal = null;
        if (reader.Read())
        {
            dal = new Competence_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["description"],
                (string)reader["icon"],
                (DateTime)reader["startPractice"],
                (string)reader["url"]
            );
        }

        CloseAndDisposeConnection();
        return dal;
    }

    public List<Competence_DAL> GetAllByExperienceId(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"SELECT c.[id], c.[name], c.[icon], c.[description], c.[startPractice], c.[url]
                                FROM competence_experience ec
                                INNER JOIN competence c ON ec.id_competence = c.id
                                WHERE ec.id_experience = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        List<Competence_DAL> dals = new List<Competence_DAL>();
        if (reader.Read())
        {
            
            dals.Add(new Competence_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["description"],
                (string)reader["icon"],
                (DateTime)reader["startPractice"],
                (string)reader["url"])
            );
            Console.WriteLine(dals[0].Name);
        }

        CloseAndDisposeConnection();
        return dals;
        
    }

    public List<Competence_DAL> GetAllByProfilId(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"SELECT c.[id], c.[name], c.[icon], c.[description], c.[startPractice], c.[url]
                                FROM profil_competence pc
                                INNER JOIN competence c ON pc.id_competence = c.id
                                WHERE pc.id_profil = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        List<Competence_DAL> dals = new List<Competence_DAL>();
        if (reader.Read())
        {
            
            dals.Add(new Competence_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["description"],
                (string)reader["icon"],
                (DateTime)reader["startPractice"],
                (string)reader["url"])
            );
            Console.WriteLine(dals[0].Name);
        }

        CloseAndDisposeConnection();
        return dals;
    }
    
    public List<Competence_DAL> GetAllByProjectId(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"SELECT c.[id], c.[name], c.[icon], c.[description], c.[startPractice], c.[url]
                                FROM competence_project cp
                                INNER JOIN competence c ON cp.id_competence = c.id
                                WHERE cp.id_project = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        List<Competence_DAL> dals = new List<Competence_DAL>();
        if (reader.Read())
        {
            dals.Add(new Competence_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["description"],
                (string)reader["icon"],
                (DateTime)reader["startPractice"],
                (string)reader["url"])
            );
            Console.WriteLine(dals[0].Name);
        }

        CloseAndDisposeConnection();
        return dals;
    }

    public override Competence_DAL Insert(Competence_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"INSERT INTO Competence (name, description, icon, startPractice, url) 
                                OUTPUT INSERTED.Id
                                VALUES (@name, @description, @icon, @startPractice, @url)
                                Select SCOPE_IDENTITY()";
        dal.Id = Convert.ToInt32(Command.ExecuteScalar());
        CloseAndDisposeConnection();
        return dal;
    }

    public override void Update(Competence_DAL dal)
    {
        throw new NotImplementedException();
    }

    public override Competence_DAL Delete(Competence_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "DELETE FROM Competence WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", dal.Id);
        Command.ExecuteNonQuery();
        CloseAndDisposeConnection();
        return dal;
    }
}