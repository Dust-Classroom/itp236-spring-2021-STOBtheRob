#define EfAssignment1
#define EfAssignment2 
#define EfAssignment3
#define Linq1
#define Linq2
#define Project
#define ViewSprocFunction
#undef  EfAssignment1
#undef  EfAssignment2
#undef ViewSprocFunction
#undef  EfAssignment3
#undef  Linq1
#undef  Linq2
#undef  Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Purchasing
{
    public static class PurchasingTest
    {
        public static void Test()
        {
            EfAssignment1();
            EfAssignment2();
            EfAssignment3();
            Linq1();
            Linq2();
            Project();
        }
        static void EfAssignment1()
        {
#if EfAssignment1
            VendorTest();
            PurchaseOrderTest();
#endif
        }
        static void EfAssignment2()
        {
#if EfAssignment2
           void UpdateVendor()
           {
                using (var db = new PurchaserEntities())
                {
                    var vend = new Vendor()
                    {
                        Name = "Fairy Dust"
                    };

                    db.Vendors.Add(vend);

                    db.SaveChanges();

                    vend = db.Vendors.Find(28);
                    db.Vendors.Remove(vend);

                    db.SaveChanges();

                }
           }

            UpdateVendor();
#endif
        }
        static void EfAssignment3()
        {
#if EfAssignment3
            using (var db = new PurchaserEntities())
            {
                try
                {
                    ViewsSprocsFunctions(db);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }

        }
        private static void ViewsSprocsFunctions(PurchaserEntities db)
        {
#if ViewSprocFunction

            string seperator = new string ('=', 40);

            // View //       

            Console.WriteLine("View:");

            var summaries = db.PoSummaries.ToList();
            foreach (var sum in summaries)
            {
                Console.WriteLine($"{sum.PurchaseOrderId}\t{sum.PODate}\t{sum.Vendor}\t{sum.TotalAmount:c}");
            }

            Console.WriteLine($"{seperator}");

            // Table-Valued Functions //

            Console.WriteLine("Table-Valued Function:");

            var poDetails = db.PoDetail(1).ToList();
            foreach (var poDetail in poDetails)
            {
                Console.WriteLine($"{poDetail.PurchaseOrderId}\t{poDetail.PODate}\t{poDetail.Vendor}\t{poDetail.Part}\t{poDetail.Quantity}\t{poDetail.Value}");
            }

            Console.WriteLine($"{seperator}");

            // Stored Procedures //

            Console.WriteLine("Stored Procedure");

            var amount = new System.Data.Entity.Core.Objects.ObjectParameter("amount", typeof(decimal));
            var pop = db.POP(1, amount);
            Console.WriteLine($"{amount.Value:c}");

#endif
#endif
        }




        static void Linq1()
        {
#if Linq1
            WriteLine($"\n<----- LINQ Test ----->\nAverage\tSum\tMin\tFirst");
            WriteLine($"{avg:0.00}\t{sum}\t{min}\t{first}");
#endif
        }
        static void Linq2()
        {
#if Linq2
            WriteLine($"\n<----- Purchase Orders by Vendor ----->");
            var pos = PurchaseOrder.ByVendor(21);
            foreach (var po in pos)
                Display(po);

            WriteLine($"\n<----- Parts > $70 ----->");
            var parts = Part.PartsAbove(70m);
            foreach (var p in parts)
                Display(p);

            WriteLine($"\n<----- Parts With Highest QoH ----->");
            var part = Part.HighestQoH();
            Display(part);

            WriteLine($"\n<----- Receipts Descending by Cost ----->");
            var receipts = Receipt.ByCost();
            foreach (var receipt in receipts)
                Display(receipt);

#endif
        }
        static void Project()
        {
#if Project
            using (var db = new PurchasingEntities())
            {
                WriteLine($"\n<----- Project ----->\nPop Properties");
                WriteLine($"PO ID\tPartId" +
                $"\tQuantity\tQuantityReceived" +
                $"\tBackOrdered\tCostReceived");
                var pops = db.PurchaseOrderParts.ToArray();
                foreach (var pop in pops)
                    Display(pop);

                WriteLine($"\n<----- Open Purchase Orders ----->");
                WriteLine($"PO ID\tPODate\t\tAmount" +
                $"\tVendor\tStatus\tTotal Amount Property");
                var pos = PurchaseOrder.OpenOrders;
                foreach (var po in pos)
                {
                    po.UpdateAmount();
                    Display(po);
                }

                WriteLine($"\n<----- Top 3 Vendors ----->\nVendorId\tName\t\tAmount");
                var vendors = Vendor.Top3;
                foreach (var vendor in vendors)
                    Display(vendor);
            }
#endif
        }
        private static void VendorTest()
        {
#if EfAssignment1
            using (var db = new PurchasingEntities())
            {
                WriteLine("\n<----------- Test Vendors ----------->");
                var vendors = db.Vendors;
                foreach (var vendor in vendors)
                    Display(vendor);
            }
#endif

        }
        private static void PurchaseOrderTest()
        {
#if EfAssignment1
            WriteLine("\n<----------- Test PurchaseOrders ----------->");
            using (var db = new PurchasingEntities())
            {
                var purchaseOrders = db.PurchaseOrders;
                foreach (var purchaseOrder in purchaseOrders)
                    Display(purchaseOrder);
            }
#endif

        }
        public static void Display(Vendor vendor)
        {
#if EfAssignment1
            WriteLine($"{vendor.VendorId}\t\t{vendor.Name}\t{vendor.TotalAmount:c}");
#endif
        }
        public static void Display(PurchaseOrder po)
        {
#if EfAssignment1
            WriteLine($"{po.PurchaseOrderId}\t{po.PODate:d}\t{po.Amount:c}" +
                $"\t{po.Vendor.Name}\t{po.PurchaseOrderStatusId}\t{po.TotalAmount:c}");
#endif
        }
#if EfAssignment1
        public static void Display(PoSummary poSum)
        {
            WriteLine($"{poSum.PurchaseOrderId}\t{poSum.Vendor}\t{poSum.TotalAmount:c}");
    }
#endif
#if EfAssignment1
        public static void Display(PoDetail_Result poDetail)
        {
            WriteLine($"{poDetail.PurchaseOrderId}\t{poDetail.Vendor}" +
                $"\t{poDetail.PODate:d}\t{poDetail.Quantity}" +
                $"\t{poDetail.Value:c}\t{poDetail.Part}");
        }
#endif
        public static void Display(Part part)
        {
#if EfAssignment1
            WriteLine($"{part.PartID}\t{part.QuantityOnHand}" +
                $"\t{part.CurrentValue:c}\t{part.Price:c}" +
                $"\t{part.Name}");
#endif
        }
        public static void Display(Receipt receipt)
        {
#if EfAssignment1
            WriteLine($"{receipt.ReceiptID}\t{receipt.PurchaseOrderPartId}\t{receipt.Quantity}\t{receipt.TotalCost:c}");
#endif
        }
        public static void Display(PurchaseOrderPart pop)
        {
#if EfAssignment1
            WriteLine($"{pop.PurchaseOrderId}\t{pop.PartId}" +
                $"\t{pop.Quantity}\t\t{pop.QuantityReceived}" +
                $"\t\t\t{pop.BackOrdered}\t\t{pop.CostReceived:c}");
#endif
        }
    }
}

