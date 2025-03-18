using Microsoft.AspNetCore.Hosting;
using Npgsql;
using TaniasAtelie.Models;


namespace TaniasAtelie.Repository;
public class UserRepository{
    

    private readonly DatabaseConnection _dbConnection;

    private readonly IWebHostEnvironment _webHostEnviroment;

 

    public UserRepository(DatabaseConnection databaseConnection, IWebHostEnvironment webHostEnviroment)
    {

        _dbConnection = databaseConnection;
        _webHostEnviroment = webHostEnviroment;

    }

    public List<User> ListUser(){

        var users = new List<User>();

        using (var connection = _dbConnection.GetConnection()){

            using(var command = new NpgsqlCommand("Select id_usuario, nome, email, senha, foto from usuario", (NpgsqlConnection)connection)){
                
                using(var reader = command.ExecuteReader()){

                    while (reader.Read()){

                        users.Add(new User{

                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Email = reader.GetString(2),
                            Senha = reader.GetString(3),
                            Foto = reader.IsDBNull(4) ? null: reader.GetString(4),

                        });
                    }
                }
            }
        }

        return users;
    }







}