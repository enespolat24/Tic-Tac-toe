using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
   
    // The type of value a cell in the gameboard is currently at
   
   public enum MarkType
    {
        Free,//the cell hasn't been clicked yet
        Nought,// the cell is an O
        Cross//the cell is an X
    }
}
