using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainarizumuVerifier
{
    public class Cell
    {
        public ValueSet LegalValues { get; set; } = new ValueSet();
        //Here we are making an open (no values removed) cell.
        public Cell(int boardSize)
        {
            LegalValues.AddRange(Enumerable.Range(1, boardSize));
        }

        //I must be greater than the minimum value of source.
        public void UpdateGreaterThan(Cell source)
        {
            int minValue = source.LegalValues.Min();
            List<int> remaining = LegalValues.Where(v => v > minValue).ToList();
            LegalValues.Set(remaining);
        }

        public void UpdateLessThan(Cell source)
        {
            int maxValue = source.LegalValues.Max();
            List<int> remaining = LegalValues.Where(v => v < maxValue).ToList();
            LegalValues.Set(remaining);
        }

        public void UpdateDifference(int difference, Cell source)
        {
            List<int> legalFromDifference = new List<int>();
            legalFromDifference.AddRange(source.LegalValues.Select(s => s + difference));
            legalFromDifference.AddRange(source.LegalValues.Select(s => s - difference));
            legalFromDifference = legalFromDifference.Distinct().ToList();
            LegalValues.Set( LegalValues.Where(v => legalFromDifference.Contains(v)).ToList() );
        }

        public void LoadValues(string values, int maxValue)
        {
            //Blank input cells are the entire range
            if (String.IsNullOrWhiteSpace(values))
            {
                for(int i = 1; i <= maxValue; i++)
                {
                    LegalValues.Add(i);
                }
            }
            else //Load the values permitted
            {
                LegalValues.Clear(); //Clear the default "everything".
                foreach (char c in values)
                {
                    LegalValues.Add(int.Parse(c.ToString()));
                }
            }
        }

        internal void RemoveValue(int solvedValue)
        {
            LegalValues.Remove(solvedValue);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(int value in this.LegalValues)
            {
                builder.Append(value.ToString());
            }
            return builder.ToString();
        }
    }
}
