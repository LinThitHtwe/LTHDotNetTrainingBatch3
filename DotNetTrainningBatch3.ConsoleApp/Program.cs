using DotNetTrainningBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainningBatch3.ConsoleApp.DapperExamples;
using DotNetTrainningBatch3.ConsoleApp.EFCoreExamples;
using DotNetTrainningBatch3.ConsoleApp.HttpClientExamples;

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
Console.ReadKey();

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.Run();



