using DotNetTrainningBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainningBatch3.ConsoleApp.DapperExamples;
using DotNetTrainningBatch3.ConsoleApp.EFCoreExamples;
using DotNetTrainningBatch3.ConsoleApp.HttpClientExamples;
using DotNetTrainningBatch3.ConsoleApp.RefitExamples;
using DotNetTrainningBatch3.ConsoleApp.RestClientExamples;

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

Console.WriteLine("Waiting for api...");


//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();

//RefitExample refitExample = new RefitExample();
//await refitExample.Run();

//EFCoreExample eFCoreExample = new();
//eFCoreExample.Generate(100);

int pageSize = 3;
AppDbContext appDbContext = new();
int rowCount = appDbContext.Blogs.Count();

int pageCount = rowCount /pageSize;
Console.WriteLine($"Current PageCount {pageCount}");

if(rowCount % pageSize > 0)
{
    pageCount++;
}

Console.WriteLine($"Final PageCount {pageCount}");

Console.ReadKey();


