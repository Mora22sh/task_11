using ch11.Data;
using ch11.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ch11
{
    internal class Program
    {
      

        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var customerDetails = context.Customers
                .Select(c => new { c.FirstName, c.LastName, c.Email });


            var SpecificstaffId = context
                .Orders.Where(o => o.StaffId == 3);


            var SpecificProductCategory = context.Products
                .Where(p => p.Category.CategoryName == "Mountain Bikes");


            var CountOreders = context.Orders.GroupBy(o => o.StoreId).Select(g => new {
                g.Key,
                OrderCount = g.Count()
            });

            var Order = context.Orders
                .Where(o => o.ShippedDate == null);


            var CustomerOrder = context.Customers
                .Select(c => new
                {
                    FullName = c.FirstName + " " + c.LastName,
                    OrdersCount = c.Orders.Count()
                });


            var NotOrdered = context.Products.
                Where(p => !p.OrderItems.Any());


            var QualityProduct = context.Products.
                Where(p => p.Stocks.Any(s => s.Quantity < 5));


            var FirstProduct = context.Products.FirstOrDefault();


            var SpecificYearProduct = context.Products.
                Where(p => p.ModelYear == 2018);


            var ProductOrder = context.Products.
                Select(p => new
                {
                    p.ProductName,
                    OrderCount = p.OrderItems.Count()
                });


            var ProductCount = context.Products.Count(p => p.CategoryId == 1);


            var averageProduct = context.Products.Average(p => p.ListPrice);


            var SpecificProduct = context.Products.FirstOrDefault(p => p.ProductId == 5);


            var Productorder = context.Products
                .Where(p => p.OrderItems.Any(o => o.Quantity > 3));


            var StaffOrder = context.Staffs.Select(s => new
            {
                Name = s.FirstName + " " + s.LastName,
                OrdersProcessed = s.Orders.Count()
            });


            var ActiveStuff = context.Staffs.Where(s => s.Active == true)
                .Select(s => new {
                    s.FirstName,
                    s.LastName,
                    s.Phone
                });


            var ProductBrandCategory = context.Products
                .Select(p => new
                {
                    p.ProductName,
                    Brand = p.Brand.BrandName,
                    Category = p.Category.CategoryName
                });


            var CompletedOrder = context.Orders
                .Where(o => o.OrderStatus == 4);


            var productQuantity = context.Products.Select(p => new
            {
                p.ProductName,
                TotalSold = p.OrderItems.Sum(oi => oi.Quantity)
            });


        }
    }
}
