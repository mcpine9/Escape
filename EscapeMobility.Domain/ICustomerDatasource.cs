using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace EscapeMobility.Domain
{
    public interface ICustomerDatasource
    {
        IQueryable<Customer> Customers { get; }
        IQueryable<Category> Categories { get; }
    }
}