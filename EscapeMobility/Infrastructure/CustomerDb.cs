using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EscapeMobility.Domain;

namespace EscapeMobility.Infrastructure
{
    public class CustomerDb : DbContext, ICustomerDatasource
    {
        public CustomerDb() : base("DefaultConnection")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }

        IQueryable<Customer> ICustomerDatasource.Customers
        {
            get { return Customers; }
        }

        IQueryable<Category> ICustomerDatasource.Categories
        {
            get { return Categories; }
        }

    }
}