using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainarizumuVerifier
{
    public class ValueSet : List<int>
    {
        public void Set(IEnumerable<int> enumerable)
        {
            this.Clear();
            this.AddRange(enumerable.ToList());
        }

        public void Set(int value)
        {
            this.Clear();
            this.Add(value);
        }

        public override string ToString()
        {
            if (this.Count == 0)
                return "Error";

            StringBuilder builder = new StringBuilder();
            foreach (int i in this.OrderBy(i => i))
            {
                builder.Append(i.ToString());
            }
            return builder.ToString();
        }
    }
}
