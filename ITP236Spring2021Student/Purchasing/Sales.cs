using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Purchasing
{
    public partial class Customer
    {
        private static SalesEntities db = new SalesEntities();
        public string Name => $"{FirstName} {LastName}";

        public string Name2
        {
            get
            {
                return $"{ FirstName} {LastName}";
            }
        }

        // Name 2 is the more complicated way of doing Name. You can click the lightbulb to automatically convert it to the easier way.

        public static string Student => "Bob Dust";

        public int OrderCount => SalesOrders != null ? SalesOrders.Count() : -1;

        public static List<Customer> CurrentCustomers
        {
            get
            {
                var thisYear = db.SalesOrders.Where(so => so.OrderDate.Year == DateTime.Now.Year).Select(so => so.Customer).Distinct().ToList();
                return thisYear;
                // .Distinct eliminates duplicates and returns one of each.

            }
        }
        public static List<CustomerSale> CustomerSales
        {
            get
            {
                return (from sop in db.SalesOrderParts
                        group sop by new { sop.SalesOrder.CustomerId, Customer = sop.SalesOrder.Customer.FirstName + " " + sop.SalesOrder.Customer.LastName } 
                        into custGroup
                        select new CustomerSale()
                        {
                            CustomerId = custGroup.Key.CustomerId,
                            CustomerName = custGroup.Key.Customer,
                            TotalSales = custGroup.Sum(cg => cg.Quantity * cg.UnitPrice)
                        }).ToList();
            }
        }

        public class CustomerSale
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public decimal TotalSales { get; set; }
        }

    }

    public partial class SalesOrder
    {
        private static SalesEntities db = new SalesEntities();

    }
}
