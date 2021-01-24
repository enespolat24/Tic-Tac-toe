using System;
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
                button.Background = Brushes.PapayaWhip;
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
        }
    }
}
