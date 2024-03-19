using DotNetTrainningBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainningBatch3.ConsoleApp.DapperExamples;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.GetAll();

DapperExample dapperExample = new DapperExample();
dapperExample.GetAll();
Console.WriteLine("-------------");
dapperExample.GetById(1);
Console.WriteLine("-------------");
dapperExample.Create(5,"created","tttt");
Console.WriteLine("-------------");
dapperExample.Update(1, "Dapper","dapper"); ;
Console.WriteLine("-------------");
dapperExample.Delete(3);
Console.WriteLine("-------------");