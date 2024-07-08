using Serilog;
using Serilog.Sinks.MSSqlServer;

Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .WriteTo.Console()
          .WriteTo.File("logs/DotNetTrainingBatch3.ConsoleApp2_.log", rollingInterval: RollingInterval.Hour)
          .WriteTo
            .MSSqlServer(
                connectionString: "Data Source=DESKTOP-IF45PH3\\SQLEXPRESS;Initial Catalog=dotNetTrainningBatch3;User ID=sa;Password=root;TrustServerCertificate=True;",
                sinkOptions: new MSSqlServerSinkOptions
                {
                    TableName = "LogEvents",
                    AutoCreateSqlTable = true,
                })
          .CreateLogger();

Log.Information("Hello, world!");

int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}


Console.ReadKey();