using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateCollection
{
    public class StateCollection
    {
        public static List<string> Names
        {
            get
            {
                var list = new List<string>();
                foreach (var state in State.states)
                {
                    list.Add(state.Name);
                }
                return list;
            }
        }

        public static SortedDictionary<string, string> StatesDictionary
        {
            get
            {
                var dic = new SortedDictionary<string, string>();
                foreach (var state in State.states)
                {
                    dic.Add(state.Code, state.Name);
                }
                return dic;
            }
        }

        public static SortedList<string, State> SortedStates
        {
            get
            {
                var sort = new SortedList<string, State>();
                foreach (var state in State.states)
                {
                    sort.Add(state.Code, state);
                }
                
                return sort;
            }
        }

    }
}
