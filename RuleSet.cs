using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainarizumuVerifier
{
    public class RuleSet
    {
        public char[,] HorizontalRules;
        public char[,] VerticalRules;

        public RuleSet(int boardSize)
        {
            HorizontalRules = new char[boardSize, boardSize-1];
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize-1; col++)
                {
                    HorizontalRules[row, col] = ' ';
                }
            }
            VerticalRules = new char[boardSize-1, boardSize];
            for (int row = 0; row < boardSize-1; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    VerticalRules[row, col] = ' ';
                }
            }
        }

        public void ReadHorizontalRules(int row, string data)
        {
            string[] dataElements = data.Split(',');
            //Need to take the even elements as rules
            for (int i = 1; i < dataElements.Length; i += 2)
            {
                if (dataElements[i].Length > 0)
                    HorizontalRules[row, i / 2] = dataElements[i][0];
            }
        }
        public void ReadVerticalRules(int row, string data)
        {
            string[] dataElements = data.Split(',');
            for (int i = 0; i < dataElements.Length; i += 2)
            {
                if (dataElements[i].Length > 0)
                    VerticalRules[row, i / 2] = dataElements[i][0];
            }
        }
    }
}
