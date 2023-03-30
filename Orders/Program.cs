using Microsoft.EntityFrameworkCore;
using Orders.Model;
using Orders.Model.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<DaoClient>();
builder.Services.AddTransient<DaoProduct>();
builder.Services.AddTransient<DaoOrder>();
builder.Services.AddTransient<DaoStitching>();


var app = builder.Build();

//Product
app.MapGet("/getProducts", async (DaoProduct dao) =>
{
    return await dao.GetAllAsync();

});
app.MapPost("/addProduct", async (Product product, DaoProduct dao) =>
{
    return await dao.AddAsync(product);
});

app.MapPost("/deleteProduct", async (Product product, DaoProduct dao) =>
{
    return await dao.DeleteAsync(product.Id);
});

app.MapPost("/updateProduct", async (Product product, DaoProduct dao) =>
{
    return await dao.UpdateAsync(product);
});

app.MapPost("/findByIdProduct", async (Product product, DaoProduct dao) =>
{
    return await dao.GetAsync(product.Id);
});
//Client
app.MapGet("/getClients", async (DaoClient dao) =>
{
    return await dao.GetAllAsync();
});
app.MapPost("/addClient", async (Client client, DaoClient dao) =>
{
    return await dao.AddAsync(client);
});

app.MapPost("/deleteClient", async (Client client, DaoClient dao) =>
{
    return await dao.DeleteAsync(client.ClientId);
});

app.MapPost("/updateClient", async (Client client, DaoClient dao) =>
{
    return await dao.UpdateAsync(client);
});

app.MapPost("/findByIdClient", async (Client client, DaoClient dao) =>
{
    return await dao.GetAsync(client.ClientId);
});
//Orders
app.MapGet("/getOrders", async (DaoOrder dao) =>
{
    return await dao.GetAllAsync();
});
app.MapPost("/addOrder", async (Order order, DaoOrder dao) =>
{
    return await dao.AddAsync(order);
});

app.MapPost("/deleteOrder", async (Order order, DaoOrder dao) =>
{
    return await dao.DeleteAsync(order.OrderId);
});

app.MapPost("/updateOrder", async (Order order, DaoOrder dao) =>
{
    return await dao.UpdateAsync(order);
});

app.MapPost("/findByIdOrder", async (Order order, DaoOrder dao) =>
{
    return await dao.GetAsync(order.OrderId);
});

//Stitching
app.MapGet("/getAllStitching", async (DaoStitching dao) =>
{
    return await dao.GetAllAsync();
});

app.MapPost("/addStitching", async (Stitching stitching, DaoStitching dao) =>
{
    return await dao.AddAsync(stitching);
});

app.MapPost("/deleteStitching", async (Stitching stitching, DaoStitching dao) =>
{
    return await dao.DeleteAsync(stitching.StitchingId);
});

app.MapPost("/updateStitching", async (Stitching stitching, DaoStitching dao) =>
{
   return await dao.UpdateAsync(stitching);
});

app.MapPost("/findByIdStitching", async (Stitching stitching, DaoStitching dao) =>
{
    return await dao.GetAsync(stitching.StitchingId);
});



app.Run();
