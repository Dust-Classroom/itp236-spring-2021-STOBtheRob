using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing
{
    public partial class PurchaseOrder
    {
        private static PurchaserEntities db = new PurchaserEntities();
        public decimal TotalAmount
        {
            get
            {
                if (PurchaseOrderParts == null)
                    PurchaseOrderParts = db.PurchaseOrderParts
                        .Where(po => po.PurchaseOrderId == PurchaseOrderId)
                        .ToList();
                return (decimal)PurchaseOrderParts.Sum(po => po.Cost);
            }
        }
        public static List<PurchaseOrder> OpenOrders
        {
            get
            {
                var open = db.PurchaseOrders.Where(po => po.PurchaseOrderStatusID == (SatusIDEnum)1).ToList();
                    return open;
            }
        }
    }
    public partial class Part
    {
        
    }
    public partial class Receipt
    {
        private static PurchaserEntities db = new PurchaserEntities();
    }
    public partial class PurchaseOrderPart
    {
        private static PurchaserEntities db = new PurchaserEntities();
        public static string StudentName => "Robert Steele";
        public int QuantityReceived => Receipts != null ? Receipts.Count : -1;
        public int BackOrdered => Receipts != null ? Quantity - QuantityReceived : -1;
        public decimal TotalSales 
        { 
            get 
            { 
                if (Receipts == null) 
                    Receipts = db.Receipts
                        .Where(po => po.PurchaseOrderPartId == PurchaseOrderPartId)
                        .ToList(); 
                return Receipts.Sum(po => po.TotalCost); 
            } 
        }
    }
    public partial class Vendor
    {
        private static PurchaserEntities db = new PurchaserEntities();
        public decimal TotalAmount
        {
            get
            {
                if (PurchaseOrders == null)
                    PurchaseOrders = db.PurchaseOrders
                        .Where(po => po.VendorId == VendorId)
                        .ToList();
                return (decimal)PurchaseOrders.Sum(po => po.Amount);
            }
        }

        public static List<Vendor> Top3
        {
            get
            {
                var top3 = db.Vendors.OrderByDescending(vend => vend.TotalAmount).Take(3).ToList();
                return top3;
            }
        }

    }
}
