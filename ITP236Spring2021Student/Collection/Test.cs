#define stub
//#undef  stub
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCollection
{
    public class TestStateCollection
    {
        public static void Test()
        {
            string seperator = new string('=', 30);

            Console.WriteLine(seperator);

            Console.WriteLine("List:");

            var names = StateCollection.Names;

            names.Add("Oklahoma");
            var oldState = names[4];
            names.Remove(oldState);

            foreach (var state in names)
            {
                Console.WriteLine(state);
            }

            Console.WriteLine(seperator);

            Console.WriteLine("Sorted Dictionary");

            var sortDic = StateCollection.StatesDictionary;

            sortDic.Add("HI", "Hawaii");
            var oldStateDic = sortDic["TX"];
            sortDic.Remove("TX");

            foreach (var state in sortDic)
            {
                Console.WriteLine(state);
            }

            Console.WriteLine(seperator);

            Console.WriteLine("Sorted List");

            var sortList = StateCollection.SortedStates;

            sortList.Add("RI", new State("RI", "Rhode Island", "Providence", 1059361));
            var oldStateList = sortList["TX"];
            sortList.Remove("TX");

            foreach (var state in sortList)
            {
                Console.WriteLine($"{state.Value.Code} \t {state.Value.Name} \t {state.Value.Capitol} \t {state.Value.Population}");
            }

            Console.WriteLine(seperator);

        }
    }
}
