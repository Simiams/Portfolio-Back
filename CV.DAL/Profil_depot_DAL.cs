using System.ComponentModel.DataAnnotations;

namespace CV.DAL;

public class Profil_depot_DAL : Depot_DAL<Profil_DAL>
{
    public override List<Profil_DAL> GetAll()
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Profil";
        var reader = Command.ExecuteReader();
        var dals = new List<Profil_DAL>();
        if (!reader.HasRows)
            return null;
        while (reader.Read())
        {
            dals.Add(new Profil_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["lastName"],
                (string)reader["pdp"],
                (DateTime)reader["ddn"],
                (string)reader["mail"],
                (string)reader["phone"],
                (string)reader["city"],
                (string)reader["job"],
                reader["currentSchool"]!= DBNull.Value ? (int)reader["currentSchool"] : null,
                (string)reader["description"],
                reader["lookingFor"]!= DBNull.Value ? (string)reader["currentSchool"] : null
            ));
        }
        CloseAndDisposeConnection();
        return dals;
    }

    public override Profil_DAL GetById(int id)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "SELECT * FROM Profil WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", id);
        var reader = Command.ExecuteReader();
        Profil_DAL dal = null;
        if (reader.Read())
        {
            dal = new Profil_DAL(
                (int)reader["id"],
                (string)reader["name"],
                (string)reader["lastName"],
                (string)reader["pdp"],
                (DateTime)reader["ddn"],
                (string)reader["mail"],
                (string)reader["phone"],
                (string)reader["city"],
                (string)reader["job"],
                reader["currentSchool"] != DBNull.Value ? (int)reader["currentSchool"] : null,
                (string)reader["description"],
                reader["lookingFor"]!= DBNull.Value ? (string)reader["currentSchool"] : null
            );
        }
        CloseAndDisposeConnection();
        return dal;
    }

    public override Profil_DAL Insert(Profil_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = @"INSERT INTO Profil (name, lastName, pdp, ddn, mail, phone, city, job, currentSchool, description)
                                VALUES (@name, @lastName, @pdp, @ddn, @mail, @phone, @city, @job, @currentSchool, @description)";
        Command.Parameters.AddWithValue("@name", dal.Name);
        Command.Parameters.AddWithValue("@lastName", dal.LastName);
        Command.Parameters.AddWithValue("@pdp", dal.Pdp);
        Command.Parameters.AddWithValue("@ddn", dal.Ddn);
        Command.Parameters.AddWithValue("@mail", dal.Mail);
        Command.Parameters.AddWithValue("@phone", dal.Phone);
        Command.Parameters.AddWithValue("@city", dal.City);
        Command.Parameters.AddWithValue("@job", dal.Job);
        Command.Parameters.AddWithValue("@currentSchool", dal.CurrentSchool);
        Command.Parameters.AddWithValue("@description", dal.Description);
        dal.Id = Convert.ToInt32(Command.ExecuteScalar());
        CloseAndDisposeConnection();
        return dal; 
    }

    public override void Update(Profil_DAL dal)
    {
        throw new NotImplementedException();
    }

    public override Profil_DAL Delete(Profil_DAL dal)
    {
        InitialConnectionAndCommand();
        Command.CommandText = "DELETE FROM Profil WHERE Id = @id";
        Command.Parameters.AddWithValue("@id", dal.Id);
        Command.ExecuteNonQuery();
        CloseAndDisposeConnection();
        return dal;
    }
}