namespace CV.DAL;

public class Experience_depot_DAL : Depot_DAL<Experience_DAL>
{
    public override List<Experience_DAL> GetAll()
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Experience";
        var reader = Command.ExecuteReader();
        var dals = new List<Experience_DAL>();
        if (!reader.HasRows)
            return null;
        while (reader.Read())
        {
            dals.Add(new Experience_DAL(
                (int)reader["id"],
                (string)reader["job"],
                (DateTime)reader["endPeriod"],
                (DateTime)reader["startPeriod"],
                (string)reader["description"],
                (string)reader["url"],
                (string)reader["company"]
            ));
        }

        CloseAndDisposeConnection();
        return dals;
    }

    public override Experience_DAL GetById(int id)  
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Experience WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        Experience_DAL dal = null;
        if (reader.Read())
        {
            dal = new Experience_DAL(
                (int)reader["id"],
                (string)reader["job"],
                (DateTime)reader["endPeriod"],
                (DateTime)reader["startPeriod"],
                (string)reader["description"],
                (string)reader["url"],
                (string)reader["company"]
            );
        }

        CloseAndDisposeConnection();
        return dal;
    }
    

    public List<Experience_DAL> GetAllShortByProfilId(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"SELECT e.[id], e.[job], e.[endPeriod], e.[startPeriod], e.[url], e.[company]
                                FROM profil_experience pe
                                INNER JOIN experience e ON pe.id_experience = e.id
                                WHERE pe.id_profil = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        var dals = new List<Experience_DAL>();
        if (!reader.HasRows)
            return null;
        while (reader.Read())
        {
            dals.Add(new Experience_DAL(
                (int)reader["id"],
                (string)reader["job"],
                (DateTime)reader["endPeriod"],
                (DateTime)reader["startPeriod"],
                (string)reader["url"],
                (string)reader["company"]
            ));
        }
        CloseAndDisposeConnection();
        return dals;
    }

    public override Experience_DAL Insert(Experience_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"INSERT INTO Experience (job, endPeriod, startPeriod, description, url, company)
                            VALUES (@job, @endPeriod, @startPeriod, @description, @url, @company)";
        Command.Parameters.AddWithValue("@job", dal.Job);
        Command.Parameters.AddWithValue("@startPeriod", dal.StartPeriod);
        Command.Parameters.AddWithValue("@endPeriod", dal.EndPeriod);
        Command.Parameters.AddWithValue("@description", dal.Description);
        Command.Parameters.AddWithValue("@url", dal.Url);
        Command.Parameters.AddWithValue("@company", dal.Company);
        dal.Id = Convert.ToInt32(Command.ExecuteScalar());
        CloseAndDisposeConnection();
        return dal;
    }

    public override void Update(Experience_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"UPDATE Experience 
                            SET job = @job, endPeriod = @endPeriod, startPeriod = @startPeriod, description = @description, url = @url , company = @company
                            WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", dal.Id);
        Command.Parameters.AddWithValue("@job", dal.Job);
        Command.Parameters.AddWithValue("@startPeriod", dal.StartPeriod);
        Command.Parameters.AddWithValue("@endPeriod", dal.EndPeriod);
        Command.Parameters.AddWithValue("@description", dal.Description);
        Command.Parameters.AddWithValue("@url", dal.Url);
        Command.Parameters.AddWithValue("@company", dal.Company);
        Command.ExecuteNonQuery();
        CloseAndDisposeConnection();
    }

    public override Experience_DAL Delete(Experience_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "DELETE FROM Experience WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", dal.Id);
        Command.ExecuteNonQuery();
        CloseAndDisposeConnection();
        return dal;
    }
}