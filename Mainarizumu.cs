using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainarizumuVerifier
{
    public class Mainarizumu
    {
        RuleSet rules;
        Board board;
        Board newBoard;

        public Mainarizumu(string initialPuzzleState)
        {
            using (StringReader reader = new StringReader(initialPuzzleState))
            {
                string header = reader.ReadLine();
                int boardSize = int.Parse(header);
                board = new Board(boardSize); //Init board (these are mutable)
                rules = new RuleSet(boardSize); //Init rules (these are immutable during a single run)
                board.SetRules(rules);

                string line;
                bool cellLine = true; //Toggle for border
                int row = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (cellLine)
                    {
                        board.ReadCellRow(row, line); //Cells are every other line, starting with the first.
                        rules.ReadHorizontalRules(row / 2, line); //They come with horizontal rules
                    }
                    else
                    {
                        rules.ReadVerticalRules(row / 2, line); //Vertical rules are lines between cell
                    }
                    cellLine = !cellLine; //Toggle read state
                    row++;
                }
            }
        }


        public string GetSolution()
        {
            //Check "Dancing Nines" 
            newBoard = board.ApplyRules(rules);
            newBoard.Rules = rules;
            Debug.WriteLine(newBoard.ToString());
            while (board.ToString() != newBoard.ToString())
            {
                board = newBoard;
                newBoard = board.ApplyRules(rules);
                newBoard.Rules = rules;
                Debug.WriteLine(newBoard.ToString());
            };

            return board.ToString(); //Return old board as it has attached rules.
        }
    }
}
