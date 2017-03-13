using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainarizumuVerifier
{
    public class Board
    {
        public int Size { get; }
        Cell[,] Cells;
        public RuleSet Rules;

        public string[,] OutputGrid()
        {
            string[,] output = new string[Size, Size];

            foreach (int row in Enumerable.Range(0, Size))
                foreach (int col in Enumerable.Range(0, Size))
                    output[row, col] = string.Concat(Cells[row, col].LegalValues);

            return output;
        }

        public Board ApplyRules(RuleSet rules)
        {
            Rules = rules;
            //Clone the board
            Board cloned = CloneBoard();
            cloned.Rules = rules;
            cloned.ApplyHorizontalRules(rules);
            cloned.ApplyVerticalRules(rules);
            cloned.RemoveSolvedFromRowsAndColumns();


            return cloned;
        }

        /// <summary>
        /// If a row has solved values, remove them from all other cells in that row.
        /// </summary>
        private void RemoveSolvedFromRowsAndColumns()
        {
            for (int row = 0; row < Size; row++)
                for (int col = 0; col < Size; col++)
                    if (Cells[row, col].LegalValues.Count == 1)
                        RemoveSolved(row, col);
        }
        /// <summary>
        /// Check the row and column for cells containing this cell's solved value
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void RemoveSolved(int solvedRow, int solvedColumn)
        {
            int solvedValue = Cells[solvedRow, solvedColumn].LegalValues[0]; //Only one value
            for(int row = 0; row < Size; row++)
                if(row != solvedRow) //Don't remove from the source of the solution
                    if (Cells[row, solvedColumn].LegalValues.Contains(solvedValue))
                        Cells[row, solvedColumn].RemoveValue(solvedValue);
            for (int col = 0; col < Size; col++)
                if (col != solvedColumn) //Same protection for the source
                    if (Cells[solvedRow, col].LegalValues.Contains(solvedValue))
                        Cells[solvedRow, col].RemoveValue(solvedValue);
        }

        private void ApplyVerticalRules(RuleSet rules)
        {
            //Vertical
            for (int row = 0; row < Size - 1; row++)
            {
                for (int col = 0; col < Size - 1; col++)
                {
                    char rule = rules.VerticalRules[row, col];
                    Cell upperCell = Cells[row, col];
                    Cell lowerCell = Cells[row + 1, col];
                    switch (rule)
                    {
                        case ' ': //No op
                            break;
                        case 'v': //Cell inequality
                                  //The cell [row,col] must be greater than the smallest [row+1,col] and vice 
                            upperCell.UpdateGreaterThan(lowerCell);
                            lowerCell.UpdateLessThan(upperCell);
                            break;
                        case '^':
                            upperCell.UpdateLessThan(lowerCell);
                            lowerCell.UpdateGreaterThan(upperCell);
                            break;
                        default: //Anything else should be a difference rule
                            int difference = int.Parse(rule.ToString());
                            upperCell.UpdateDifference(difference, lowerCell);
                            lowerCell.UpdateDifference(difference, upperCell);
                            break;
                    }
                }
            }
        }

        private void ApplyHorizontalRules(RuleSet rules)
        {
            //Make one loop over the rulesets
            //Horizontal
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size - 1; col++)
                {
                    char rule = rules.HorizontalRules[row, col];
                    Cell leftSide = Cells[row, col];
                    Cell rightSide = Cells[row, col + 1];
                    switch (rule)
                    {
                        case ' ': //No op
                            break;
                        case '>': //Cell inequality
                                  //The cell [row,col] must be greater than the smallest [row,col+1] and vice 
                            leftSide.UpdateGreaterThan(rightSide);
                            rightSide.UpdateLessThan(leftSide);
                            break;
                        case '<':
                            leftSide.UpdateLessThan(rightSide);
                            rightSide.UpdateGreaterThan(leftSide);
                            break;
                        default: //Should be numeric
                            int difference = int.Parse(rule.ToString());
                            rightSide.UpdateDifference(difference, leftSide);
                            leftSide.UpdateDifference(difference, rightSide);
                            break;
                    }
                }
            }
        }

        private Board CloneBoard()
        {
            Board cloned = new Board(Size);
            foreach (int row in Enumerable.Range(0, Size))
            {
                foreach (int column in Enumerable.Range(0, Size))
                {
                    Cell newCell = new Cell(Size);
                    newCell.LegalValues.Set(Cells[row, column].LegalValues);
                    cloned.Cells[row, column] =  newCell;
                }
            }

            return cloned;
        }

        public void SetRules(RuleSet rules)
        {
            Rules = rules;
        }

        public Board(int boardSize)
        {
            Size = boardSize;
            Cells = new Cell[boardSize, boardSize];
            foreach (int row in Enumerable.Range(0, boardSize))
            {
                foreach (int column in Enumerable.Range(0, boardSize))
                {
                    Cells[row, column] = new Cell(boardSize);
                }
            }
        }

        public bool BoardDifferentFrom(Board otherBoard)
        {
            foreach (int row in Enumerable.Range(0, Size))
            {
                foreach (int column in Enumerable.Range(0, Size))
                {
                    if (otherBoard.Cells[row,column].LegalValues != Cells[row, column].LegalValues)
                        return true;
                }
            }
            return false;
        }
        public void ReadCellRow(int row, string data)
        {
            string[] dataElements = data.Split(',');
            //Need to take the even elements as rules
            for (int i = 0; i < dataElements.Length; i += 2)
            {
                if (dataElements[i].Length > 0)
                    Cells[row, i / 2].LoadValues(dataElements[i], Size);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Size.ToString());
            for (int row = 0; row < Size; row++)
            { 
                for (int column = 0; column < Size; column++)
                {
                    if (column > 0)
                        builder.Append(","); //Comma prior to value after first.
                    builder.Append(Cells[row,column].LegalValues.ToString());
                    if (column < Size - 1) //Add horizontal rule except last.
                        if (Rules.HorizontalRules[row, column] == ' ')
                            builder.Append(",");
                        else
                            builder.Append($",{Rules.HorizontalRules[row,column]}");
                }
                builder.AppendLine();//Finalize data row
                if (row < Size - 1) //Add border rules, except last.
                {
                    for (int column = 0; column < Size; column++)
                    {
                        if (column > 0)
                            builder.Append(",");
                        if(Rules.VerticalRules[row, column] != ' ')
                            builder.Append(Rules.VerticalRules[row, column]);
                        if (column < Size - 1) //Add dummy spacing except third column
                            builder.Append(",");
                    }
                    builder.AppendLine(); //Finalize border row
                }
            }
            return builder.ToString();           
        }
    }
}
