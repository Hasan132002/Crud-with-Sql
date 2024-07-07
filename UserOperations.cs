using MySql.Data.MySqlClient;
using System;
public class UserOperations{
    private Database database;
    public UserOperations(Database db){
        database = db;
    }
    public void CreateUser(string firstName,string lastName, string email, int age){
        string query = "INSERT INTO Users(firstName,lastname,email,age) VALUES (@firstName,@lastName,@email,@age)";
        MySqlCommand cmd = new MySqlCommand(query, database.GetConnection());
        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Age", age);
        database.OpenConnection();
        cmd.ExecuteNonQuery();
        database.CloseConnection();
    }
    public void ReadUsers(){
        string query ="Select * from Users";
        MySqlCommand cmd = new MySqlCommand(query, database.GetConnection());
        database.OpenConnection();
        MySqlDataReader reader=cmd.ExecuteReader();
        while(reader.Read()){
            Console.WriteLine(reader["id"] + "\t" + reader["firstName"] + "\t" + reader["lastName"] + "\t" + reader["email"] + "\t" + reader["age"]);
        }
        database.CloseConnection();
    }
    public void UpdateUser(int id, string firstName,string lastName,string email,int age){
        string query = "UPDATE Users SET firstName=@FirstName, lastName=@LastName, email=@Email, age=@Age WHERE id=@id";
        MySqlCommand cmd = new MySqlCommand(query, database.GetConnection());
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.Parameters.AddWithValue("@Email", email);
        cmd.Parameters.AddWithValue("@Age", age);
        database.OpenConnection();
        cmd.ExecuteNonQuery();
        database.CloseConnection();
    }
    public void DeleteUser(int id){
        string query = "DELETE FROM Users WHERE id=@id";
        MySqlCommand cmd = new MySqlCommand(query, database.GetConnection());
        cmd.Parameters.AddWithValue("@id", id);
        database.OpenConnection();
        cmd.ExecuteNonQuery();
        database.CloseConnection();

    }
}