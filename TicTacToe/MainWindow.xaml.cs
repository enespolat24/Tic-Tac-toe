﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private members
        //holds the current results of cells in the active game
        private MarkType[] mResults;
        //true if it is player1's turn (x) or player 2's turn (0)
        private bool mPlayer1Turn;
        //tru if the game has ended
        private bool mGameEnded;


        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            NewGame();

        }
        #endregion


        //Starts a new game and clear the grid
        private void NewGame()
        {
            //create new blank array of empty cell
            mResults = new MarkType[9];
            for (int i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }
            //make sure player 1 starts the game
            mPlayer1Turn = true;

            //interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.WhiteSmoke;
                button.Foreground = Brushes.Blue;
            });
            mGameEnded = false; //the game has not finished yet
        }

        //button click event
        //sender => the button
        //e => the events of the click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //starts a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }
            //cast the sender to a button
            var button = (Button)sender;
            //find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            //do not do anything if the cell has a value in it
            if (mResults[index] != MarkType.Free)
            {
                return;
            }
            //set the cell calue based on which players turn it is
            if (mPlayer1Turn)
            {
                mResults[index] = MarkType.Cross;
            }
            else
            {
                mResults[index] = MarkType.Nought;
            }

            button.Content = mPlayer1Turn ? "X" : "O";

            //change noughts to green
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }

            //toggle the players turns
            mPlayer1Turn ^= true;


            //winner check
            CheckForWinner();
        }
        //checks if there's a winner of a 3 line straight
        private void CheckForWinner()
        {
            #region Horizontal

            //check for horizontal winner row 0
            if (mResults[0] != MarkType.Free && (mResults[1] & mResults[2]) == mResults[0])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }



            //check for horizontal winner row 1
            if (mResults[3] != MarkType.Free && (mResults[4] & mResults[5]) == mResults[3])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }



            //check for horizontal winner row 2
            if (mResults[6] != MarkType.Free && (mResults[7] & mResults[8]) == mResults[6])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion

            #region Vertical
            //check for vertical winner row 0
            if (mResults[0] != MarkType.Free && (mResults[3] & mResults[6]) == mResults[0])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }


            //check for vertical winner row 1
            if (mResults[1] != MarkType.Free && (mResults[4] & mResults[7]) == mResults[1])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }



            //check for vertical winner row 2
            if (mResults[2] != MarkType.Free && (mResults[5] & mResults[8]) == mResults[2])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }


            #endregion

            #region Diagonal
            //check for diagonal winner row 0
            if (mResults[0] != MarkType.Free && (mResults[4] & mResults[8]) == mResults[0])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }



            if (mResults[6] != MarkType.Free && (mResults[4] & mResults[2]) == mResults[6])
            {
                //game over
                mGameEnded = true;

                //higlight winning move
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;
            }
            #endregion
            #region No winner
            //if there's no winner
            if (!mResults.Any(rslt => rslt == MarkType.Free))
            {
                mGameEnded = true;

                //turn all cells orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
            #endregion
        }
    }
}
