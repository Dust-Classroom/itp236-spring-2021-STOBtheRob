#define Shapes
#define EmployeePay
#define Debugging
#define StateCollection 
#define Purchasing
#define EDI
#define ETL
#undef Shapes
#undef EmployeePay
#undef Debugging
#undef StateCollection
//#undef Purchasing
#undef EDI
#undef ETL

using static System.Console;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("<----- Student: Robert Steele ----->");
            #region Shapes
#if Shapes
            Shapes.TestShapes.Test();
#endif
            #endregion
            #region Employee Pay
#if EmployeePay
            EmployeePay.EmployeePay.Test();
#endif
            #endregion
            #region Debugging
#if Debugging
            Debugging.Debugging.Test();
#endif
            #endregion
            #region State Collection
#if StateCollection
            StateCollection.TestStateCollection.Test();
#endif
            #endregion
            #region Purchasing
#if Purchasing
            Purchasing.PurchasingTest.Test();
            //Purchasing.LinqProject
            //Purchasing.TestSales.Test();
#endif
            #endregion
            #region EDI
#if EDI
            EDI.TestEDI.Test();
            EDI.LinqExample.TestLinq();
#endif
            #endregion
            #region ETL
#if ETL
            ETL.TestEtl.Test();
#endif
            #endregion
            ReadKey();
        }
    }
}
