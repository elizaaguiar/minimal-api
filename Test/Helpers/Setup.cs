namespace Test.Helpers;

public class Setup
{
    public const string PORT = "5001";
    public static TestContext testContext = default!;
    public static WebApplicationFactory<Startup> http = default!;
    public static HttpClient client = default!;

    // public static async Task ExecuaComandoSqlAsync(string sql)
    // {
    //     await new DbContexto().Database.ExecutaSqlRawAsync(sql);
    // }
    // public static async Task<int> ExecutaEntityCountAsync(int id, string nome)
    // {
    //     return await new DbContexto().Clientes.Where(c => c.Id == id && c.Nome == nome);
    // }
    // public static async Task FakeClienteAsync()
    // {
    //     await new DbContexto().Database.ExecuteSqlRawAsync("""insert clientes(Nome, Telefone, Email, DataCriacao)values('Danilo', '(11)11111-1111', 'email@teste.com', '2022-12-15' 06:09:00)""");
    // }

    public static void ClassInt(TestContext testContext)
    {
        Setup.testContext = testContext;
        Setup.http = new WebApplicationFactory<Startup>();

        Setup.http = Setup.http.WithWebHostBuilder(builder =>
        {
            builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IAdministradorServico, AdministradorServicoMock>();
            });
        });
    }

}