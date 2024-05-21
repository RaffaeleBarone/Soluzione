using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Progetto1;
using Progetto1.Extensions;
using Progetto1.Manager;
using Progetto1.Models;


class Program
{
    private static IConfigurationRoot _config;
    private static IServiceProvider _serviceProvider;
    static async Task Main(string[] args)
    {
        InizializeConfiguration();
        InizializeServices();
       var studenteManager = _serviceProvider.GetRequiredService<IStudenteManager>();
       var esameManager = _serviceProvider.GetRequiredService<IEsameManager>();
        var Nome = "Raffaele";
        //var idStudente = await studenteManager.AddStudente(Nome, "Barone");
        
        //var NomeEsame = "Programmazione 1";
        //var VotoEsame = 22;
       
        //var idEsame = await esameManager.AddEsame(NomeEsame, VotoEsame, idStudente);
        //if(Nome == "Raffaele")
        //{

        //}
        await esameManager.RemoveEsame(1);
       
        

    }

    private static void InizializeServices()
    {
        _serviceProvider = new ServiceCollection()
            .AddDbContextServices(_config)
            .BuildServiceProvider();
           

  
    }

    private static void InizializeConfiguration()
    {
        _config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false)
          .Build();
    }
}
