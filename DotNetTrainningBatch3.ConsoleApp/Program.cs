using DotNetTrainningBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainningBatch3.ConsoleApp.DapperExamples;
using DotNetTrainningBatch3.ConsoleApp.EFCoreExamples;
using DotNetTrainningBatch3.ConsoleApp.HttpClientExamples;
using DotNetTrainningBatch3.ConsoleApp.RefitExamples;
using DotNetTrainningBatch3.ConsoleApp.RestClientExamples;
using Serilog;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.GetAll();

//DapperExample dapperExample = new DapperExample();
//dapperExample.GetAll();
//Console.WriteLine("-------------");
//dapperExample.GetById(1);
//Console.WriteLine("-------------");
//dapperExample.Create(5,"created","tttt");
//Console.WriteLine("-------------");
//dapperExample.Update(1, "Dapper","dapper"); ;
//Console.WriteLine("-------------");
//dapperExample.Delete(3);
//Console.WriteLine("-------------");

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();

//Console.WriteLine("Waiting for api...");


//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();

//RefitExample refitExample = new RefitExample();
//await refitExample.Run();

//EFCoreExample eFCoreExample = new();
//eFCoreExample.Generate(100);

//int pageSize = 3;
//AppDbContext appDbContext = new();
//int rowCount = appDbContext.Blogs.Count();

//int pageCount = rowCount /pageSize;
//Console.WriteLine($"Current PageCount {pageCount}");

//if(rowCount % pageSize > 0)
//{
//    pageCount++;
//}

//Console.WriteLine($"Final PageCount {pageCount}");

Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .WriteTo.Console()
          .WriteTo.File("logs/DotNetTrainingBatch3.ConsoleApp.log", rollingInterval: RollingInterval.Hour)
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


