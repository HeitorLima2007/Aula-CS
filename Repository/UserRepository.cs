using System.Net;
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


    public async Task InsertUser(User user, IFormFile arquivo){


        string caminhoArquivo = await Upload(arquivo, "img");

        using (var connection = _dbConnection.GetConnection()){

            using (var command = connection.CreateCommand()){

                command.CommandText = "INSERT INTO  usuario(nome, login, email, senha, foto) values (@nome,@senha,@email,@foto)";

                var nomeParam = command.CreateParameter();
                nomeParam.ParameterName = "@nome";
                nomeParam.Value = user.Nome;
                command.Parameters.Add(nomeParam);

                var emailParam = command.CreateParameter();
                emailParam.ParameterName = "@email";
                emailParam.Value = user.Email;
                command.Parameters.Add(emailParam);

                var senhaParam = command.CreateParameter();
                senhaParam.ParameterName = "@senha";
                senhaParam.Value = user.Senha;
                command.Parameters.Add(senhaParam);

                var fotoParam = command.CreateParameter();
                fotoParam.ParameterName = "@foto";
                fotoParam.Value = user.Foto;
                command.Parameters.Add(fotoParam);

                command.ExecuteNonQuery();

            }
        }
    }

    public async Task<string> Upload(IFormFile arquivo, string pasta){

        if(arquivo == null || arquivo.Length == 0){

            return "";
        }

        string caminhoPasta = Path.Combine(_webHostEnviroment.WebRootPath,pasta);

        if(!Directory.Exists(caminhoPasta))
            Directory.CreateDirectory(caminhoPasta);

        string nomeArquivo = Guid.NewGuid().ToString()+Path.GetExtension(arquivo.FileName);
        string caminhoCompleto = Path.Combine(caminhoPasta,nomeArquivo);

        using(var stream = new FileStream(caminhoCompleto,FileMode.Create)){

            await arquivo.CopyToAsync(stream);
        }

        return $"/{pasta}/{nomeArquivo}";
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