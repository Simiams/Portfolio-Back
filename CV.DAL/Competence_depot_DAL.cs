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