﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing
{
    public class TestSales
    {
        public TestSales()
        {
            using (var db = new SalesEntities())
            {
                try
                {
                    LinqSales1(db);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void LinqSales1(SalesEntities db)
        {
            
            // -Sum-
            // Method Syntax
            var totalSales = db.SalesOrders.Sum(so => so.OrderTotal);

            // Query Syntax
            totalSales = (from so in db.SalesOrders select so.OrderTotal).Sum();
            // These two syntaxes do the same thing, sum up the order totals.

            // -Accounts Receivable-

            var accountsReceivable = db.Customers.Sum(c => c.Balance);
            // OR...
            accountsReceivable = (from cust in db.Customers select cust.Balance).Sum();

            // -Join- This is when you must gather information from multiple places.
            //Method Syntax is a little more messy when doing a join.
            var customerSalesTotal = db.Customers.Sum(c => c.SalesOrders.Sum(so => so.OrderTotal));
            // Better off using Query Syntax
            customerSalesTotal = (from cust in db.Customers from salesOrders in cust.SalesOrders select salesOrders.OrderTotal).Sum();

            // -Order By-
            var bigDebts = db.Customers.OrderByDescending(c => c.Balance).ToList();
            // OR...
            bigDebts = (from cust in db.Customers orderby cust.Balance descending select cust).ToList();

            // -Anonymous Class-
            // Method Syntax
            var taxes = db.SalesOrders.Select(so => new {OrderNum = so.SalesOrderNumber, so.OrderTotal, Customer = so.Customer.FirstName + "" + so.Customer.LastName, Taxes = so.OrderTotal * .06m}).ToList();
            foreach (var tax in taxes)
            {
                Console.WriteLine($"{tax.OrderNum}\t{tax.OrderTotal}\t{tax.Taxes:c}\t{tax.Customer}");

            }

            // Query Syntax
            taxes = (from so in db.SalesOrders let tax = so.OrderTotal * .06m select new
            {
                OrderNum = so.SalesOrderNumber,
                so.OrderTotal,
                Customer = so.Customer.FirstName + "" + so.Customer.LastName,
                Taxes = tax
            }
            ).ToList();

            //// -Contains (Like a IN in SQL)- 
            //var customerIds = db.Customers.Where(c = c.Balance > 100).Select(c => c.CustomerId);
            //// Grabs customer ID #s with balance greater than 100.

            //var selectedOrders = (from so in db.SalesOrders where customerIds.Contains(so.CustomerId) select so);
            //// Iterates through selected ID numbers and shows Sales Orders for those Customer IDs

            //// -Group By-
            //var customerparts = (
            //    from sop 
            //    in db.SalesOrderParts 
            //    group sop 
            //    by sop.SalesOrder.CustomerId 
            //    into sopGroup 
            //    select new
            //    {
            //        CustomerId = sopGroup.Key,
            //        SOPs = sopGroup,
            //        Sales = sopGroup.Sum(sg => sg.Quanity * sg.UnitPrice)
            //    }
            //    ).ToList();

            //var customerSales = (
            //    from so in db.SalesOrders
            //    group so by so.CustomerId into custGroup
            //    select new
            //    {
            //        CustomerId = custGroup.Key,
            //        Sales = custGroup.Sum(cg => cg.OrderTotal)
            //    }
            //    ).ToList();


        }
    }
}
