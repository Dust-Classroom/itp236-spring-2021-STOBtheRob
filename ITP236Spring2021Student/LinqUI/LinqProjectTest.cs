#define POP 
#define PO
#define Vendor
//#undef POP
//#undef PO
//#undef Vendor
using Purchasing;
using System;
using System.Linq;
namespace LinqUI
{    
    class LinqProjectTest    
    {        
        static void Main(string[] args)  
        {            
            Console.WriteLine($"Start: {PurchaseOrderPart.StudentName}");
            using (var db = new PurchaserEntities())     
            {                
                PurchaseOrderParts(db);                
                PurchaseOrders(db);                
                Vendors(db);            
            }            
            Console.WriteLine($"\nEnd: {PurchaseOrderPart.StudentName}");            
            Console.ReadKey();        
        }        
        static void PurchaseOrderParts(PurchaserEntities db)        
        {
            #if POP            
            Console.WriteLine("\n-----< PurchaseOrderParts >-----");            
            Console.WriteLine("PopId\tRec'd\tBO'ed\tCost Received");           
            var pops = db.PurchaseOrderParts                
                .Where(pop => pop.Receipts.Any())                
                .OrderBy(pop => pop.PurchaseOrderPartId);            
            foreach (dynamic pop in pops)            
            {                
                var testProperty = "QuantityReceived";                
                try                
                {                    
                    var quantityReceived = pop.QuantityReceived;                    
                    testProperty = "BackOrdered";                    
                    var backOrdered = pop.BackOrdered;                    
                    testProperty = "CostReceived";                    
                    var costReceived = pop.CostReceived;                    
                    Console.WriteLine($"{pop.PurchaseOrderPartId}\t{quantityReceived}\t{backOrdered}\t{costReceived:c}");                
                }                
                catch (Exception )                
                {                    
                    Console.WriteLine($"{testProperty} failed");                    
                    break;                
                }            
            }
            #endif        
        }        
        static void PurchaseOrders(PurchaserEntities db)        
        {
            #if PO
            Console.WriteLine("\n-----< PurchaseOrders >-----"); 
            Console.WriteLine("PoId\tTotalAmount"); 
            var testProperty = "TotalAmount"; 
            try 
            { 
                foreach (dynamic po in db.PurchaseOrders) 
                { 
                    Console.WriteLine($"{po.PurchaseOrderId}\t{po.TotalAmount:c}"); 
                } 
                testProperty = "OpenOrders"; 
                Console.WriteLine("\n-----< OpenOrders >-----"); 
                var property = typeof(PurchaseOrder).GetProperty("OpenOrders"); 
                if (property == null) { Console.WriteLine($"{testProperty} failed"); 
                    return; } Console.WriteLine("PoId\tPODate"); 
                dynamic openOrders = property.GetValue(null, null); 
                foreach (var po in openOrders) 
                { 
                    Console.WriteLine($"{po.PurchaseOrderId}\t{po.PODate:d}"); 
                } 
            } 
            catch (Exception) 
            { 
                Console.WriteLine($"{testProperty} failed"); 
            }
            #endif        
        }        
        static void Vendors(PurchaserEntities db)        
        {
            #if Vendor            
            Console.WriteLine("\n-----< Vendors >-----");            
            Console.WriteLine("VendorId\tName\t\tTotalAmount");            
            var testProperty = "TotalAmount";            
            try            
            {                
                foreach (dynamic vendor in db.Vendors)                
                {                    
                    Console.WriteLine($"{vendor.VendorId}\t\t{vendor.Name}\t{vendor.TotalAmount:c}");                
                }                
                testProperty = "Top3";                
                Console.WriteLine("\n-----< Top 3 >-----");                
                var property = typeof(Vendor).GetProperty("Top3");                
                if (property == null)                
                {                    
                    Console.WriteLine($"{testProperty} failed");                    
                    return;                
                }                
                Console.WriteLine("PoId\t\tName\t\tPODate");                
                dynamic top3 = property.GetValue(null, null);                
                foreach (dynamic vendor in top3)                
                {                    
                    Console.WriteLine($"{vendor.VendorId}\t\t{vendor.Name}\t{vendor.TotalAmount:c}");                
                }
            }            
            catch (Exception) 
            { Console.WriteLine($"{testProperty} failed"); 
            }
            #endif        
        }    
    }
}
