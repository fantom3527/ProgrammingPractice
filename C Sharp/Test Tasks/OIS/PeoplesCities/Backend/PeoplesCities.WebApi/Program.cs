using PeoplesCities.Persistence;


namespace PeoplesCities.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<PeoplesCitiesDbContext>();
                    //WeatherStub.ConfigureStub();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    //TODO: поправить, что-то с кодировками.
                    Console.WriteLine("������ ��� ������������� ���� ������: " + exception);
                    Console.WriteLine("����������� �� ������: " + exception.InnerException);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
            //    .ConfigureAppConfiguration((hostingContext, config) =>
            //     {
            //config.AddJsonFile("appsettings.json", optional: true);
            //      });
    }
}