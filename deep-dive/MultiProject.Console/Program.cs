// See https://aka.ms/new-console-template for more information
using MultiProject.ClassLibrary;
using System.Data.Entity;

Console.WriteLine("Hello, World!");

NeilPublicClass neilPublicClass = new();
neilPublicClass.SayHello();

NeilPublicClassWithInternalMembers neilPublicClassWithInternalMembers = new();
neilPublicClassWithInternalMembers.PublicMethod();
neilPublicClassWithInternalMembers.InternalMethod();

NeilInternalClass neilInternalClass = new();
neilInternalClass.PublicMethod();
neilInternalClass.InternalMethod();


public class AppContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
}

public record Product(
    int Id,
    string Name,
    string Description,
    decimal Price
);