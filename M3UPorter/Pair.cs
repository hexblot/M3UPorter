using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3UPorter
{
    // An unimmutable key-value pair
    class Pair<L,R>
    {
        public Pair()
        {
        }

        public Pair(L left, R right)
        {
            this.Left = left;
            this.Right = right;
        }

        public L Left { get; set; }
        public R Right { get; set; }
    };
}
