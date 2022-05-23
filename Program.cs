var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/AddProduct", (string? name, double? prise) => AddProduct);

app.Run();

List<Product> Products = new List<Product>();

Products.Add(new Product() {name = "Apple", prise = 232});
Products.Add(new Product() {name = "Banana", prise = 215});
Products.Add(new Product() {name = "Egg", prise = 220});

app.MapGet("/catalog", () => Products);

app.MapPost("/AddProductLock", (Product[] products) => {
    lock (products)
    {
        Products.Add(new Product() { name = "Apple", prise = 232 });
    }
});

void AddProduct(List<Product> Products)
{
    Products.Add(new Product() { name = "Apple", prise = 232 });
}



public class Product
{
    public string name { get; set; }
    public double prise { get; set; }
}

