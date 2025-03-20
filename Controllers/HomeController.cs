using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaniasAtelie.Models;
using Npgsql;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Data;
using TaniasAtelie.Repository;


namespace TaniasAtelie.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DatabaseConnection _dbConnection;

    private UserRepository _userRepository;

    public HomeController (ILogger<HomeController> logger, DatabaseConnection databaseConnection, UserRepository userRepository)
    {
        _logger = logger;
        _dbConnection = databaseConnection;
        _userRepository = userRepository;
    }

    [HttpPost]
    
    public async Task<IActionResult> Register(User user, IFormFile Foto){

        if(ModelState.IsValid){
            await _userRepository.InsertUser(user, Foto);
            return RedirectToAction("Index");
        
        }
        return View(user);
    }

    public IActionResult ListUser(){
        
        var users = _userRepository.ListUser();
        return View(users);
    }

    public IActionResult Index()
    {   

        using var conn = _dbConnection.GetConnection();
        using var cmd = new NpgsqlCommand("SELECT a.nome, a.email from usuario a", conn);
        using var reader = cmd.ExecuteReader();

        int cont = 0;
        var nomes = new List<string>();
        var emails = new List<string>();

        while(reader.Read()){

            nomes.Add(reader.GetString(0));
            emails.Add(reader.GetString(1));
            cont++;
        
        }

        ViewData["nomes"] = nomes;
        ViewData["emails"] = emails;
        ViewData["cont"] = cont;
        return View();

    }

    public IActionResult Loja()
    {
        return View();
    }
    public IActionResult Atelie()
    {
        return View();
    }
    public IActionResult Contatos()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Carinho()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
