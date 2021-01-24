using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// The type of value a cell in the gameboard is currently at
    /// </summary>
   public enum MarkType
    {
        Free,//the cell hasn't been clicked yet
        Nought,// the cell is an O
        Cross//the cell is an X
    }
}
