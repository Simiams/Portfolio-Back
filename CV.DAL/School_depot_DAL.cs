namespace CV.DAL;

public class School_depot_DAL : Depot_DAL<School_DAL>
{
    public override List<School_DAL> GetAll()
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM School";
        var reader = Command.ExecuteReader();
        var dals = new List<School_DAL>();
        if (!reader.HasRows)
            return null;
        while (reader.Read())
        {
            dals.Add(new School_DAL(
                (int)reader["id"],
                (string)reader["city"],
                (string)reader["url"],
                (string)reader["description"],
                (string)reader["name"]
            ));
        }
        
        CloseAndDisposeConnection();
        return dals;
    }

    public override School_DAL GetById(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM School WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        School_DAL dal = null;
        if (reader.Read())
        {
            dal = new School_DAL(
                (int)reader["id"],
                (string)reader["city"],
                (string)reader["url"],
                (string)reader["description"],
                (string)reader["name"]
            );
        }
        CloseAndDisposeConnection();
        return dal;
    }

    public override School_DAL Insert(School_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"INSERT INTO School (city, url, description, name) 
                                VALUES (@city, @url, @description, @name)";
        Command.Parameters.AddWithValue("@city", dal.City);
        Command.Parameters.AddWithValue("@url", dal.Url);
        Command.Parameters.AddWithValue("@description", dal.Description);
        Command.Parameters.AddWithValue("@name", dal.Name);
        dal.Id = Convert.ToInt32(Command.ExecuteScalar());
        CloseAndDisposeConnection();
        return dal; 
    }

    public override void Update(School_DAL dal)
    {
        throw new NotImplementedException();
    }

    public override School_DAL Delete(School_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "DELETE FROM School WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", dal.Id);
        Command.ExecuteNonQuery();
        CloseAndDisposeConnection();
        return dal;
    }
}