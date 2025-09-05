using MinimalApi.Infraestrutura.Db;
using MinimalApi.Dominio.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;



namespace MinimalApi.Dominio.Entidades;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste() 
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        var builder = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }
    
    [TestMethod]
    public void TestarSalvarAdministrador()
    {
        //arange (variaveis)
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");


        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
       
        var administradorServico = new AdministradorServico(context);
        // act (acoes)
        administradorServico.Incluir(adm);
        //assert (validacao)
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
       
    }
}