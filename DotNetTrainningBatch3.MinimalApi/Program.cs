using DotNetTrainningBatch3.MinimalApi.Db;
using DotNetTrainningBatch3.MinimalApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/blog", (AppDbContext _db) =>
{
    List<Blog> blogs = _db.Blogs.OrderByDescending(blog => blog.Id).ToList();
    return Results.Ok(blogs);
})
.WithName("GetBlogs")
.WithOpenApi();

app.MapGet("/api/blog/{id}", (AppDbContext _db, string id) =>
{
    Blog? blog = _db.Blogs.FirstOrDefault(blog => blog.Id == id);
    if (blog is null)
    {
        return Results.NotFound("No Blog found.");
    }
    return Results.Ok(blog);
})
.WithName("GetBlog")
.WithOpenApi();

app.MapGet("/api/blog/{pageNo}/{pageSize}", (AppDbContext _db, int pageNo, int pageSize) =>
{
    int rowCount = _db.Blogs.Count();
    int pageCount = rowCount / pageSize;
    if (rowCount % pageSize > 0)
    {
        pageCount++;
    }
    if (pageNo > pageCount)
    {
        return Results.BadRequest(new { Message = "Invalid PageNo." });
    }

    List<Blog> blogs = _db.Blogs
        .OrderByDescending(blog => blog.Id)
        .Skip((pageNo - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    List<BlogModel> blogModels = new();
    foreach (var blog in blogs)
    {
        BlogModel blogModel = new()
        {
            author = blog.Author,
            id = blog.Id,
            title = blog.Title
        };
        blogModels.Add(blogModel);
    }

    BlogResponseModel model = new()
    {
        data = blogModels,
        pageSize = pageSize,
        pageNo = pageNo,
        pageCount = pageCount
    };

    return Results.Ok(model);
})
.WithName("GetBlogsByPagination")
.WithOpenApi();


app.MapPost("/api/blog", (AppDbContext _db, Blog blog) =>
{
    _db.Blogs.Add(blog);
    int result = _db.SaveChanges();
    string message = result > 0 ? "Successfully Created." : "Create Failed.";
    return Results.Ok(message);
})
.WithName("CreateBlog")
.WithOpenApi();

app.MapPut("/api/blog/{id}", (AppDbContext _db, string id, Blog requestBlog) =>
{
    Blog? existingBlog = _db.Blogs.FirstOrDefault(blog => blog.Id == id);
    if (existingBlog is null)
    {
        return Results.NotFound("No data found.");
    }
    existingBlog.Title = requestBlog.Title;
    existingBlog.Author = requestBlog.Author;
    int result = _db.SaveChanges();
    string message = result > 0 ? "Successfully Updated." : "Update Failed.";
    return Results.Ok(message);
})
.WithName("UpdateBlog")
.WithOpenApi();

app.MapDelete("/api/blog", (AppDbContext _db, string id) =>
{
    Blog? existingBlog = _db.Blogs.FirstOrDefault(blog => blog.Id == id);
    if (existingBlog is null)
    {
        return Results.NotFound("No data found.");
    }
    _db.Blogs.Remove(existingBlog);
    int result = _db.SaveChanges();
    string message = result > 0 ? "Successfully Deleted" : "Delete Failed.";
    return Results.Ok(message);
})
.WithName("DeleteBlog")
.WithOpenApi();

app.Run();