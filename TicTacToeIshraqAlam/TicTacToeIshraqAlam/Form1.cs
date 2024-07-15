//Name: Ishraq Alam
//Date: May 29, 2024
//Title: A9TicTacToeIA
//Purpose: To create an interactive TicTacToe Game where the user can verse an AI.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeIshraqAlam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Disables all of the buttons so that they can't be touched mid-game and forces user to pick a square that is not taken.
            btnSquare1.Enabled = false; 
            btnSquare2.Enabled = false;
            btnSquare3.Enabled = false;
            btnSquare4.Enabled = false;
            btnSquare5.Enabled = false;
            btnSquare6.Enabled = false;
            btnSquare7.Enabled = false;
            btnSquare8.Enabled = false;
            btnSquare9.Enabled = false;

            pcbWinnerPicture.Image = Resource1.catanddog;

        }


        //Variable Declaration
        //keeps track of what is selected - when user or computer clicks a button these become true
        bool blnClickedOne = false;
        bool blnClickedTwo = false;
        bool blnClickedThree = false;
        bool blnClickedFour = false;
        bool blnClickedFive = false;
        bool blnClickedSix = false;
        bool blnClickedSeven = false;
        bool blnClickedEight = false;
        bool blnClickedNine = false;

        bool blnPlayerTurn = true; //player goes first 

        int intCounterPlayer = -1; //Number of moves player does 
        int intCounterComp = -1; //Number of moves computer does 

        int[] playerMoves = { -99, -99, -99, -99, -99 }; //The moves the user chooses is stored 
        int[] compMoves = { -99, -99, -99, -99, -99 }; //The moves the computer chooses is stored

        int intCompWins = 0; //Display for number of wins computer has 
        int intUserWins = 0; //Display for number of wins user has 

        Random rnd = new Random(); //Random number generator used to make move decisions

        private void btnReset_Click(object sender, EventArgs e) //If the reset button gets clicked
        { 
            ResetGame(); //The reset method activates, erasing everything and starting fresh. 
        }

        private void btnSquare2_Click(object sender, EventArgs e) //If the first (top left) square is clicked 
        {
            int intBtnVal = 2; //The button has a value of 2 

            if (blnClickedOne == false) //Checks if the button has already been clicked - if it hasn't then it is false and will be able to be clicked. 
            {
                intCounterPlayer++; //Player's counter goes up 
                this.btnSquare2.BackgroundImage = Resource1.cat; //Replaces first square with the cat 
                playerMoves[intCounterPlayer] = intBtnVal; //Stores value of this button (2) in the array to show the user chose 2

                blnPlayerTurn = false; 
                blnClickedOne = true; //The button becomes true so it belongs to user 
                btnSquare2.Enabled = false; //The button is disabled 



            }

            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Displays cat as winner
                this.lblWinner.Text = "WINNER: Cat"; //Updates win status on screen
                MessageBox.Show("Game has finished! The winner are the cats."); //Outputs message box 
                intUserWins++; //Counter displayed to show number of wins on screen 
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner; //Replaces winner picture with cat 
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Displays dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++; //Counter displayed to show number of wins on screen 
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner; //Replaces winner picture with dog 
            }
            else
            {
                AllTaken(); //Checks for tie 

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    ComputerMove(); //If tie, win, or loss, don't occur then it does the computer's move 
                }

            }

        }



        private void btnSquare9_Click(object sender, EventArgs e) //If the second square to the right of the first square is cliced 
        {
            int intBtnVal = 9; //Changes val of button to 9

            if (blnClickedTwo == false) //If the button isn't selected already 
            {
                intCounterPlayer++; //Adds a counter to the player 
                this.btnSquare9.BackgroundImage = Resource1.cat; //The square then belongs to the user 
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value to button value 
                blnPlayerTurn = false; 
                blnClickedTwo = true; //Changed condition of button so it belongs to user 
                btnSquare9.Enabled = false; //Disables button so it can't be clicked again 

            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }
            else
            {
                //Checks if there is a tie 
                AllTaken();

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    //If no loss, win, or tie, then makes computer move 
                    ComputerMove();
                }

            }

        }

        private void btnSquare4_Click(object sender, EventArgs e) //If the third button on the first row is clicked 
        {
            int intBtnVal = 4; //Changes button value to 4 

            if (blnClickedThree == false) //If the button is false (not occupied)
            {
                intCounterPlayer++; //Increases counter 
                this.btnSquare4.BackgroundImage = Resource1.cat; //Replaces button with cat
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value to 4 
                blnPlayerTurn = false; 
                blnClickedThree = true; //Makes the button occupied 
                btnSquare4.Enabled = false; //Makes button unclickable 

            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }

            else
            {

                AllTaken(); //Checks for a tie 

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    //if no loss, win, or tie, computer does move 
                    ComputerMove();
                }

            }

        }

        private void btnSquare7_Click(object sender, EventArgs e) //If the first square on second row is clicked 
        {
            int intBtnVal = 7; //Changes button value to 7 

            if (blnClickedFour == false) //Checks if unoccupied 
            {
                intCounterPlayer++; //Adds to counter 
                this.btnSquare7.BackgroundImage = Resource1.cat;
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value to button value 
                blnPlayerTurn = false;
                blnClickedFour = true; //Makes button occupied 
                btnSquare7.Enabled = false; //Disables button 

            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }

            else
            {

                AllTaken(); //Checks for tie 

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    ComputerMove(); //If no loss, win, or tie, computer does move 
                }

            }

        }

        private void btnSquare5_Click(object sender, EventArgs e) //If centre button is clicked 
        {
            int intBtnVal = 5; //Button value changed to 5 

            if (blnClickedFive == false) //Checks if unoccupied
            {
                intCounterPlayer++; //Adds to counter 
                this.btnSquare5.BackgroundImage = Resource1.cat; 
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value 
                blnPlayerTurn = false;
                blnClickedFive = true; //Makes it occupied for user 
                btnSquare5.Enabled = false; //Disables button 


            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }

            else
            {

                AllTaken(); //Checks for tie 

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    ComputerMove(); //If no win, loss, or tie, then computer does move 
                }

            }

        }

        private void btnSquare3_Click(object sender, EventArgs e) //Last button on second row gets clicked 
        {
            int intBtnVal = 3; //Changes button value to 3 

            if (blnClickedSix == false) //Checks if occupied 
            { 
                intCounterPlayer++; //Adds to counter 
                this.btnSquare3.BackgroundImage = Resource1.cat;
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value 
                blnPlayerTurn = false;
                blnClickedSix = true; //Makes it occupied for user 
                btnSquare3.Enabled = false; //Disables button 


            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true) 
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }
            else
            {

                //Checks for tie 
                AllTaken();

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    //Makes computer do move if none happen 
                    ComputerMove();
                }

            }

        }

        private void btnSquare6_Click(object sender, EventArgs e) //If first button on last row is clicked 
        {
            int intBtnVal = 6; //Button value changes to 6

            if (blnClickedSeven == false) //If it is unoccupied 
            {
                intCounterPlayer++; //Adds to counter 
                this.btnSquare6.BackgroundImage = Resource1.cat;
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value 
                blnPlayerTurn = false;
                blnClickedSeven = true; //Changes so user occupies 
                btnSquare6.Enabled = false; //Disables button 


            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }
            else
            {
                //Checks for tie 
                AllTaken();

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    //If none, computer does move 
                    ComputerMove();
                }

            }

        }

        private void btnSquare1_Click(object sender, EventArgs e) //If second button on last row is clicked 
        {
            int intBtnVal = 1; //Changes button value to 1 

            if (blnClickedEight == false) //Checks if occupied 
            {
                intCounterPlayer++; //Adds to counter 
                this.btnSquare1.BackgroundImage = Resource1.cat;
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value 
                blnPlayerTurn = false;
                blnClickedEight = true; //Changes occupancy for user 
                btnSquare1.Enabled = false; //Disables button 


            }


            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }
            else
            {

                AllTaken(); //Checks for tie 

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    ComputerMove(); //If no win, loss, or tie, then computer does move 
                }

            }

        }

        private void btnSquare8_Click(object sender, EventArgs e) //If the last button in last row is clicked 
        {
            int intBtnVal = 8; //Changes button value to 8 

            if (blnClickedNine == false) //If it is not occupied 
            {
                intCounterPlayer++; //Adds to counter 
                this.btnSquare8.BackgroundImage = Resource1.cat; //Replaces with cat image 
                playerMoves[intCounterPlayer] = intBtnVal; //Changes array value 
                blnPlayerTurn = false;
                blnClickedNine = true; //Changes occupancy for user 
                btnSquare8.Enabled = false; //Disables button 


            }

            //Checks win, loss, or tie condition after user moves and if none applies then it does the computer's move
            if (CheckWinner(playerMoves) == true)
            {
                //Declares cat as winner 
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++;
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }

            else
            {
                //Checks for tie 
                AllTaken();

                if (CheckWinner(compMoves) == false && CheckWinner(playerMoves) == false)
                {
                    //If no win, loss, or tie, then computer does move 
                    ComputerMove();
                }

            }



        }

        public bool CheckWinner(int[] intMoves) //The function used to check for the winner 
        {
            //Checks for winner

            //There are 10 scenarios where either comp or user can win. Each scenario is considered by adding 3 array values with all possible combinations. If any are 15, then it returns true and can be used to determine the winner 
            if (intMoves[0] + intMoves[1] + intMoves[2] == 15)
            {
                return true;
            }

            else if (intMoves[0] + intMoves[1] + intMoves[3] == 15)
            {
                return true;
            }

            else if (intMoves[0] + intMoves[1] + intMoves[4] == 15)
            {
                return true;
            }

            else if (intMoves[0] + intMoves[2] + intMoves[3] == 15)
            {
                return true;
            }

            else if (intMoves[0] + intMoves[2] + intMoves[4] == 15)
            {
                return true;
            }

            else if (intMoves[0] + intMoves[3] + intMoves[4] == 15)
            {
                return true;
            }

            else if (intMoves[1] + intMoves[2] + intMoves[3] == 15)
            {
                return true;
            }

            else if (intMoves[1] + intMoves[2] + intMoves[4] == 15)
            {
                return true;
            }

            else if (intMoves[1] + intMoves[3] + intMoves[4] == 15)
            {
                return true;
            }

            else if (intMoves[2] + intMoves[3] + intMoves[4] == 15)
            {
                return true;
            }
            else
            {
                return false; //If none of the sums are 15, then it returns false and there is no winner yet 
            }

        }

        public void AllTaken() //Method for checking if there is a tie
        {
            if (intCounterPlayer == 4 || intCounterComp == 4 && (CheckWinner(playerMoves) == false) && (CheckWinner(compMoves) == false)) //Checks if the counter is 4 (max) for either comp or user and if there is no true return from the checkwinner function
            {

                MessageBox.Show("The game has ended in a tie! Neither the dogs or cats won..."); //Outputs result as tie 
                btnReset.Enabled = true; //Enables the ability to reset game 
            }
        }

        private void btnExit_Click(object sender, EventArgs e) //If user clicks exit button they exit the application 
        {
            Application.Exit();
        }

        bool blnUserOrCompFirst = false; //Used to determine if the user or the computer went first 
        private void btnUserFirst_Click(object sender, EventArgs e) //Cat goes first 
        {
            //Enables all the buttons if "Cat First" Clicked 
            btnSquare1.Enabled = true;
            btnSquare2.Enabled = true;
            btnSquare3.Enabled = true;
            btnSquare4.Enabled = true;
            btnSquare5.Enabled = true;
            btnSquare6.Enabled = true;
            btnSquare7.Enabled = true;
            btnSquare8.Enabled = true;
            btnSquare9.Enabled = true;

            //Disables the who goes first buttons 
            btnUserFirst.Enabled = false;
            btnComputerFirst.Enabled = false;

            //Makes button true - used for 2nd move decision for comp 
            blnUserOrCompFirst = true;
        }

        private void btnComputerFirst_Click(object sender, EventArgs e) //Dog goes first 
        {
            ComputerMove(); //Computer does the move first
            //Enables every button 
            btnSquare1.Enabled = true;
            btnSquare2.Enabled = true;
            btnSquare3.Enabled = true;
            btnSquare4.Enabled = true;
            btnSquare5.Enabled = false;
            btnSquare6.Enabled = true;
            btnSquare7.Enabled = true;
            btnSquare8.Enabled = true;
            btnSquare9.Enabled = true;

            //Disables the who goes first buttons 
            btnComputerFirst.Enabled = false;
            btnUserFirst.Enabled = false;

            //Keeps the button false - used for 2nd move decision for comp 
            blnUserOrCompFirst = false;
        }

        public void ComputerMove() //The computer's move 
        {
            intCounterComp++; //Computer counter increases by 1 

            if (intCounterComp == 0) //If counter is 0 (first move)
            {
                FirstCompMove(); //The first move is conducted 
            }

            else if (intCounterComp == 1) //If the counter is 1 
            {
                if (blnUserOrCompFirst == true) //If the user is first 
                {
                    CheckBlock(); //Computer's second move is to check if it can block first 

                    if (compMoves[1] == -99) //If the array value didn't change (nothing to block)
                    {
                        SecondCompMove(); //Computer attacks 

                        if (compMoves[1] == -99) //If computer couldn't win with previous move, then it performs a random move 
                        {
                            StaleMate();
                        }
                    }
                }

                else
                {
                    SecondCompMove(); //Does the second move if the computer is chosen to move first 

                    if (compMoves[1] == -99) //If it did nothing, then it will check to see if it can block 
                    {
                        CheckBlock();

                        if (compMoves[1] == -99) //If it couldn't block or attack, it will do a random move 
                        {
                            StaleMate();
                        }
                    }
                }

            }

            else if (intCounterComp == 2) //If the counter is 2 
            {
                CheckIfComputerCanWin1(); //Activates method to check difference in array values 
                ComputerAttack(); //Tries to win first


                if (compMoves[2] == -99) //If it can't win with next move then 
                {

                    CheckBlock(); //It checks to see if it can block or prevent user from winning 

                    if (compMoves[2] == -99) //If it could neither attack nor defend, it will do a random move 
                    {
                        StaleMate();
                    }

                }
            }

            else if (intCounterComp == 3) //Counter 3 
            {
                //Finds all the possible  differences in array values 
                CheckIfComputerCanWin1();
                CheckIfComputerCanWin2();
                CheckIfComputerCanWin3();
                ComputerAttack(); //Tries to win in the next move 


                if (compMoves[3] == -99) //If it can't then it tries to defend or prevent user from winning
                {
                    CheckBlock();

                    if (compMoves[3] == -99) //if it could do neither, then it does a random move 
                    {
                        StaleMate();
                    }

                }

            }

            else if (intCounterComp == 4) //Counter 4 
            {
                //Checks all possible differences in array values 
                CheckIfComputerCanWin1();
                CheckIfComputerCanWin2();
                CheckIfComputerCanWin3();
                CheckIfComputerCanWin4();
                CheckIfComputerCanWin5();
                CheckIfComputerCanWin6();

                ComputerAttack(); //Tries to win with next move 

                if (compMoves[4] == -99) //If it can't then it checks if it can defend 
                {
                    CheckBlock();

                    if (compMoves[4] == -99) //If it could do neither, then it does a random move 
                    {
                        StaleMate();
                    }
                }

            }


            if (CheckWinner(playerMoves) == true) //Checks win condition for user and computer 
            {
                this.lblWinner.Text = "WINNER: Cat";
                MessageBox.Show("Game has finished! The winner are the cats.");
                intUserWins++;
                this.lblUserWins.Text = "Cat Wins: " + intUserWins;
                pcbWinnerPicture.Image = Resource1.CatWinner;
            }

            else if (CheckWinner(compMoves) == true)
            {
                //Declares dog as winner 
                this.lblWinner.Text = "WINNER: Dog";
                MessageBox.Show("Game has finished! The winner are the dogs.");
                intCompWins++; //Computer counter increases 
                this.lblCompWins.Text = "Dog Wins: " + intCompWins;
                pcbWinnerPicture.Image = Resource1.DogWinner;
            }

            else
            {
                AllTaken(); //If no win condition, then it checks for a tie 
            }

        }

        public void FirstCompMove() //Computer's first move 
        {
            
            if (blnClickedFive == false) //If the centre square is open then it chooses that 
            {
                this.btnSquare5.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 5; 
                blnClickedFive = true;
                btnSquare5.Enabled = false;

            }

            else if (blnClickedFive == true) //If the centre square is not open, then it randomly chooses a corner 
            {
                int rndFirstMove = rnd.Next(1, 5); //Random number from 1 to 4 

                if (rndFirstMove == 1) //Random value of 1 means top left corner is selected
                {
                    this.btnSquare2.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnSquare2.Enabled = false;
                }

                else if (rndFirstMove == 2) //Random value of 2 means top right corner is selected 
                {
                    this.btnSquare4.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnSquare4.Enabled = false;

                }

                else if (rndFirstMove == 3) //Random value of 3 means bottom left corner is selected 
                {
                    this.btnSquare6.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSquare6.Enabled = false;
                }

                else if (rndFirstMove == 4) //Random value of 4 means bottom right corner is selected 
                {
                    this.btnSquare8.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnSquare8.Enabled = false;
                }

            }
        }

        public void SecondCompMove() //The computer's second move is based off of the computer's first move 
        {
            
            if (blnClickedFive == true && compMoves[0] == 5) //If computer's first move is middle
            {
                int rndMove = rnd.Next(1, 5); //Generates random number from 1 to 4, then randomly selects a corner.

                if (playerMoves[0] == 4 && playerMoves[1] == 6) //However, if the user chooses two opposite corners, when the computer chooses the centre - there is an exception that would make it possible for the user to win in the next move. To prevent that, there is a counter that can be played to force a win or tie for the computer instead. 
                {
                    this.btnSquare7.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnSquare7.Enabled = false;
                }

                //Horizontally, 7 or 3 can be selected to prevent this situation. In this case, 7 is selected for all cases where opposite corners are chosen. 
                else if (playerMoves[0] == 6 && playerMoves[1] == 4)
                {
                    this.btnSquare7.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnSquare7.Enabled = false;
                }

                else if (playerMoves[0] == 2 && playerMoves[1] == 8)
                {
                    this.btnSquare7.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnSquare7.Enabled = false;
                }

                else if (playerMoves[0] == 8 && playerMoves[1] == 2)
                {
                    this.btnSquare7.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnSquare7.Enabled = false;
                }

                //If random move is 1, top left corner is selected
                else if (rndMove == 1 && blnClickedOne == false && intCounterComp == 1)
                {
                    this.btnSquare2.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnSquare2.Enabled = false;
                }

                //if random move is 2, bottom left corner is selected 
                else if (rndMove == 2 && blnClickedSeven == false && intCounterComp == 1)
                {
                    this.btnSquare6.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSquare6.Enabled = false;
                }

                //if random move is 3, top right corner is selected
                else if (rndMove == 3 && blnClickedThree == false && intCounterComp == 1)
                {
                    this.btnSquare4.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnSquare4.Enabled = false;
                }

                //if random move is 4, bottom right corner is selected 
                else if (rndMove == 4 && blnClickedNine == false && intCounterComp == 1)
                {
                    this.btnSquare8.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnSquare8.Enabled = false;
                }
            }

            else //If computer's first move is a corner
            {
                if (compMoves[0] == 2 && blnClickedThree == false) //If computer first move is top left it will choose top right next
                {
                    this.btnSquare4.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnSquare4.Enabled = false;
                }

                else if (compMoves[0] == 2 && blnClickedSeven == false) //If first move is top left it may choose bottom left next 
                {
                    this.btnSquare6.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSquare6.Enabled = false;
                }

                else if (compMoves[0] == 6 && blnClickedOne == false) //If first move is bottom left it may choose top left next 
                {
                    this.btnSquare2.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnSquare2.Enabled = false;
                }

                else if (compMoves[0] == 6 && blnClickedNine == false) //If first move is bottom left it may choose bottom right next
                {
                    this.btnSquare8.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnSquare8.Enabled = false;
                }

                else if (compMoves[0] == 8 && blnClickedSeven == false) //If first move is bottom right, it may choose bottom left next
                {
                    this.btnSquare6.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSquare6.Enabled = false;
                }

                else if (compMoves[0] == 8 && blnClickedThree == false) //if first move is bottom right, it may choose top right next 
                {
                    this.btnSquare4.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnSquare4.Enabled = false;
                }

                else if (compMoves[0] == 4 && blnClickedOne == false) //If first move is top right, it may choose top left next
                {
                    this.btnSquare2.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnSquare2.Enabled = false;
                }

                else if (compMoves[0] == 4 && blnClickedNine == false) //If first move is top right, it may choose bottom right next 
                {
                    this.btnSquare8.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnSquare8.Enabled = false;
                }
            }


        }
        public void ComputerAttack() //Computer will try to win with the next move 
        {
            
            //Counter 2 
            if (intCounterComp == 2 && compMoves[1] == 2 && blnClickedNine == false) //If the computer's 2nd move is top left, then it will try getting bottom right corner 
            {
                this.btnSquare8.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 8;
                blnClickedNine = true;


                btnSquare8.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 6 && blnClickedThree == false) //If 2nd move is bottom left, it will try getting top right corner 
            {
                this.btnSquare4.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 4;
                blnClickedThree = true;
                btnSquare4.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 4 && blnClickedSeven == false) //if 2nd move is top right, it will try getting bottom left corner 
            {
                this.btnSquare6.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 6;
                blnClickedSeven = true;
                btnSquare6.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 8 && blnClickedOne == false) //If 2nd move is bottom right, it will try getting top left corner 
            {
                this.btnSquare2.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 2;
                blnClickedOne = true;
                btnSquare2.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 9 && blnClickedEight == false) //If 2nd move is 2nd square in first row, it will try getting 2nd square in last row 
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 1 && blnClickedTwo == false) //If 2nd move is 2nd in last row, it will try getting 2nd in first row 
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 3 && blnClickedFour == false) //If 2nd move is last in 2nd row, it will try getting first in 2nd row 
            { 
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[1] == 7 && blnClickedSix == false) //If 2nd move is first in 2nd row, it will try getting last in 2nd row 
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 2 && compMoves[1] == 4 && blnClickedTwo == false) //Try getting square 2 if 1 and 3 selected
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 2 && compMoves[1] == 6 && blnClickedFour == false) //Try getting square 4 if 1 and 7 are selected 
            {
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 6 && compMoves[1] == 2 && blnClickedFour == false) //Try getting square 4 if 7 and 1 are selected
            {
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 6 && compMoves[1] == 8 && blnClickedEight == false) //Try getting square 8 if 7 and 9 are selected
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 8 && compMoves[1] == 6 && blnClickedEight == false) //Try getting square 8 if 9 and 7 are selected 
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 8 && compMoves[1] == 4 && blnClickedSix == false) //Try getting square 6 if 9 and 3 are selected
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 4 && compMoves[1] == 8 && blnClickedSix == false) //Try getting square 6 if 3 and 9 are selected
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

            else if (intCounterComp == 2 && compMoves[0] == 4 && compMoves[1] == 2 && blnClickedTwo == false) 
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }


            // Counter 3


            //Finds the difference between all array values up to 3rd counter - then for each difference - checks if the square is available to take. If it is, then it takes and wins

            if (intCounterComp == 3 && blnClickedNine == false && (intCheckDifference == 8 || intCheckDifference2 == 8 || intCheckDifference3 == 8)) //Checks if square 9 open
            {
                this.btnSquare8.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 8;
                blnClickedNine = true;
                btnSquare8.Enabled = false;
            }

            else if (intCounterComp == 3 &&  blnClickedThree == false && (intCheckDifference == 4 || intCheckDifference2 == 4 || intCheckDifference3 == 4)) //Checks if square 3 open 
            {
                this.btnSquare4.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 4;
                blnClickedThree = true;
                btnSquare4.Enabled = false;
            }

            else if (intCounterComp == 3 && blnClickedSeven == false && (intCheckDifference == 6 || intCheckDifference2 == 6 || intCheckDifference3 == 6)) //Checks if square 7 open 
            {
                this.btnSquare6.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 6;
                blnClickedSeven = true;
                btnSquare6.Enabled = false;
            }

            else if (intCounterComp == 3 && blnClickedOne == false && (intCheckDifference == 2 || intCheckDifference2 == 2 || intCheckDifference3 == 2)) //Checks if square 1 open 
            {
                this.btnSquare2.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 2;
                blnClickedOne = true;
                btnSquare2.Enabled = false;
            }

            else if (intCounterComp == 3 && blnClickedEight == false && (intCheckDifference == 1 || intCheckDifference2 == 1 || intCheckDifference3 == 1)) //Checks if square 8 open
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            else if (intCounterComp == 3 && blnClickedTwo == false && (intCheckDifference == 9 || intCheckDifference2 == 9 || intCheckDifference3 == 9)) //Checks if square 2 open 
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }

            else if (intCounterComp == 3 && blnClickedFour == false && (intCheckDifference == 7 || intCheckDifference2 == 7 || intCheckDifference3 == 7)) //Checks if square 4 open 
            {
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            else if (intCounterComp == 3 && blnClickedSix == false && (intCheckDifference == 3 || intCheckDifference2 == 3 || intCheckDifference3 == 3)) //Checks if square 6 open 
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

            //Counter 4

            //Same as before - checks the difference between all possible array locations and if it is possible to win by grabbing a square - it will grab that square. 

            if (intCounterComp == 4  && blnClickedNine == false && (intCheckDifference == 8 || intCheckDifference2 == 8 || intCheckDifference3 == 8 || intCheckDifference4 == 8 || intCheckDifference5 == 8 || intCheckDifference6 == 8))
            {
                this.btnSquare8.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 8;


                blnClickedNine = true;
                btnSquare8.Enabled = false;
            }

            else if (intCounterComp == 4 &&  blnClickedThree == false && (intCheckDifference == 4 || intCheckDifference2 == 4 || intCheckDifference3 == 4 || intCheckDifference4 == 4 || intCheckDifference5 == 4 || intCheckDifference6 == 4))
            {
                this.btnSquare4.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 4;
                blnClickedThree = true;
                btnSquare4.Enabled = false;
            }

            else if (intCounterComp == 4 &&  blnClickedSeven == false && (intCheckDifference == 6 || intCheckDifference2 == 6 || intCheckDifference3 == 6 || intCheckDifference4 == 6 || intCheckDifference5 == 6 || intCheckDifference6 == 6))
            {
                this.btnSquare6.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 6;
                blnClickedSeven = true;
                btnSquare6.Enabled = false;
            }

            else if (intCounterComp == 4 &&  blnClickedOne == false && (intCheckDifference == 2 || intCheckDifference2 == 2 || intCheckDifference3 == 2 || intCheckDifference4 == 2 || intCheckDifference5 == 2 || intCheckDifference6 == 2))
            {
                this.btnSquare2.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 2;
                blnClickedOne = true;
                btnSquare2.Enabled = false;
            }

            else if (intCounterComp == 4 &&  blnClickedEight == false && (intCheckDifference == 1 || intCheckDifference2 == 1 || intCheckDifference3 == 1 || intCheckDifference4 == 1 || intCheckDifference5 == 1 || intCheckDifference6 == 1))
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            else if (intCounterComp == 4 &&  blnClickedTwo == false && (intCheckDifference == 9 || intCheckDifference2 == 9 || intCheckDifference3 == 9 || intCheckDifference4 == 9 || intCheckDifference5 == 9 || intCheckDifference6 == 9))
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }

            else if (intCounterComp == 4 &&  blnClickedFour == false && (intCheckDifference == 7 || intCheckDifference2 == 7 || intCheckDifference3 == 7 || intCheckDifference4 == 7 || intCheckDifference5 == 7 || intCheckDifference6 == 7))
            {
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            else if (intCounterComp == 4 && blnClickedSix == false && (intCheckDifference == 3 || intCheckDifference2 == 3 || intCheckDifference3 == 3 || intCheckDifference4 == 3 || intCheckDifference5 == 3 || intCheckDifference6 == 3))
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

        }



        public void StaleMate() //If the computer can not win in the next move or block the user from winning in the next move. This will make a random move 
        {

            while (true) //Infinite loop 
            {
                int RndMove; 

                RndMove = rnd.Next(1, 10); //Generates random number from 1-9, to select a square on the grid


                //Checks if each square is available for the corresponding random number - then takes 
                if (RndMove == 1 && blnClickedOne == false) //Random val 1 makes square 1
                {
                    this.btnSquare2.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 2;
                    blnClickedOne = true;
                    btnSquare2.Enabled = false;
                    break;
                }

                else if (RndMove == 2 && blnClickedTwo == false) //Random val 2 makes square 2 
                {
                    this.btnSquare9.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 9;
                    blnClickedTwo = true;
                    btnSquare9.Enabled = false;
                    break;
                }

                else if (RndMove == 3 && blnClickedThree == false) //Random val 3 makes square 3 
                {
                    this.btnSquare4.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 4;
                    blnClickedThree = true;
                    btnSquare4.Enabled = false;
                    break;
                }

                else if (RndMove == 4 && blnClickedFour == false) //Random val 4 makes square 4 
                {
                    this.btnSquare7.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 7;
                    blnClickedFour = true;
                    btnSquare7.Enabled = false;
                    break;
                }

                else if (RndMove == 5 && blnClickedFive == false) //Random val 5 makes square 5 
                {
                    this.btnSquare5.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 5;
                    blnClickedFive = true;
                    btnSquare5.Enabled = false;
                    break;
                }

                else if (RndMove == 6 && blnClickedSix == false) //Random val 6 makes square 6 
                {
                    this.btnSquare3.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 3;
                    blnClickedSix = true;
                    btnSquare3.Enabled = false;
                    break;
                }

                else if (RndMove == 7 && blnClickedSeven == false) //Random val 7 makes square 7 
                {
                    this.btnSquare6.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 6;
                    blnClickedSeven = true;
                    btnSquare6.Enabled = false;
                    break;
                }

                else if (RndMove == 8 && blnClickedEight == false) //Random val 8 makes square 8 
                {
                    this.btnSquare1.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 1;
                    blnClickedEight = true;
                    btnSquare1.Enabled = false;
                    break;
                }

                else if (RndMove == 9 && blnClickedNine == false) //Random val 9 makes square 9 
                {
                    this.btnSquare8.BackgroundImage = Resource1.dog;
                    compMoves[intCounterComp] = 8;
                    blnClickedNine = true;
                    btnSquare8.Enabled = false;
                    break;
                }

                //If all the squares are occupied (all 9 are taken), then it exits loop without doing anything 
                else if (blnClickedOne == true && blnClickedTwo == true && blnClickedThree == true && blnClickedFour == true && blnClickedFive == true && blnClickedSix == true && blnClickedSeven == true && blnClickedEight == true && blnClickedNine == true)
                {

                    break;
                }

            }
        }

        
        public void CheckBlock() //Checks every situation where the computer can block the user 
        {
            //Square 3 and 5 taken by user 
            if (blnClickedSeven == false && blnClickedThree == true && blnClickedFive == true && compMoves[0] != 5 && compMoves[1] != 5 && compMoves[2] != 5 && compMoves[3] != 5 && compMoves[4] != 5 && compMoves[0] != 4 && compMoves[1] != 4 && compMoves[2] != 4 && compMoves[3] != 4 && compMoves[4] != 4)
            {
                this.btnSquare6.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 6;
                blnClickedSeven = true;
                btnSquare6.Enabled = false;
            }

            //Square 7 and 5 taken by user
            else if (blnClickedThree == false && blnClickedSeven == true && blnClickedFive == true && compMoves[0] != 5 && compMoves[1] != 5 && compMoves[2] != 5 && compMoves[3] != 5 && compMoves[4] != 5 && compMoves[0] != 6 && compMoves[1] != 6 && compMoves[2] != 6 && compMoves[3] != 6 && compMoves[4] != 6)
            {
                this.btnSquare4.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 4;
                blnClickedThree = true;
                btnSquare4.Enabled = false;
            }

            //Square 4 and 5 taken by user 
            else if (blnClickedSix == false && blnClickedFour == true && blnClickedFive == true && compMoves[0] != 5 && compMoves[1] != 5 && compMoves[2] != 5 && compMoves[3] != 5 && compMoves[4] != 5 && compMoves[0] != 7 && compMoves[1] != 7 && compMoves[2] != 7 && compMoves[3] != 7 && compMoves[4] != 7)
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

            //Square 6 and 5 taken by user 
            else if (blnClickedFour == false && blnClickedSix == true && blnClickedFive == true && compMoves[0] != 5 && compMoves[1] != 5 && compMoves[2] != 5 && compMoves[3] != 5 && compMoves[4] != 5 && compMoves[0] != 3 && compMoves[1] != 3 && compMoves[2] != 3 && compMoves[3] != 3 && compMoves[4] != 3)
            {
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            //Squre 2 and 5 taken by user 

            else if (blnClickedEight == false && blnClickedTwo == true && blnClickedFive == true && compMoves[0] != 5 && compMoves[1] != 5 && compMoves[2] != 5 && compMoves[3] != 5 && compMoves[4] != 5 && compMoves[0] != 9 && compMoves[1] != 9 && compMoves[2] != 9 && compMoves[3] != 9 && compMoves[4] != 9)
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            //Square 8 and 5 taken by user 
            else if (blnClickedTwo == false && blnClickedEight == true && blnClickedFive == true && compMoves[0] != 5 && compMoves[1] != 5 && compMoves[2] != 5 && compMoves[3] != 5 && compMoves[4] != 5 && compMoves[0] != 1 && compMoves[1] != 1 && compMoves[2] != 1 && compMoves[3] != 1 && compMoves[4] != 1)
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }

            //Square 1 and 2 taken by user 
            else if (blnClickedThree == false && blnClickedOne == true && blnClickedTwo == true && compMoves[0] != 2 && compMoves[1] != 2 && compMoves[2] != 2 && compMoves[3] != 2 && compMoves[4] != 2 && compMoves[0] != 9 && compMoves[1] != 9 && compMoves[2] != 9 && compMoves[3] != 9 && compMoves[4] != 9)
            {
                this.btnSquare4.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 4;
                blnClickedThree = true;
                btnSquare4.Enabled = false;
            }


            //Square 1 and 3 taken by user 
            else if (blnClickedTwo == false && blnClickedOne == true && blnClickedThree == true && compMoves[0] != 2 && compMoves[1] != 2 && compMoves[2] != 2 && compMoves[3] != 2 && compMoves[4] != 2 && compMoves[0] != 4 && compMoves[1] != 4 && compMoves[2] != 4 && compMoves[3] != 4 && compMoves[4] != 4)
            {
                this.btnSquare9.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 9;
                blnClickedTwo = true;
                btnSquare9.Enabled = false;
            }

            //Square 1 and 4 taken by user
            else if (blnClickedSeven == false && blnClickedOne == true && blnClickedFour == true && compMoves[0] != 2 && compMoves[1] != 2 && compMoves[2] != 2 && compMoves[3] != 2 && compMoves[4] != 2 && compMoves[0] != 7 && compMoves[1] != 7 && compMoves[2] != 7 && compMoves[3] != 7 && compMoves[4] != 7)
            {
                this.btnSquare6.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 6;
                blnClickedSeven = true;
                btnSquare6.Enabled = false;
            }

            //Square 1 and 7 taken by user 
            else if (blnClickedFour == false && blnClickedOne == true && blnClickedSeven == true && compMoves[0] != 2 && compMoves[1] != 2 && compMoves[2] != 2 && compMoves[3] != 2 && compMoves[4] != 2 && compMoves[0] != 6 && compMoves[1] != 6 && compMoves[2] != 6 && compMoves[3] != 6 && compMoves[4] != 6)
            {
                this.btnSquare7.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 7;
                blnClickedFour = true;
                btnSquare7.Enabled = false;
            }

            //Square 9 and 6 taken by user 
            else if (blnClickedThree == false && blnClickedNine == true && blnClickedSix == true && compMoves[0] != 8 && compMoves[1] != 8 && compMoves[2] != 8 && compMoves[3] != 8 && compMoves[4] != 8 && compMoves[0] != 3 && compMoves[1] != 3 && compMoves[2] != 3 && compMoves[3] != 3 && compMoves[4] != 3)
            {
                this.btnSquare4.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 4;
                blnClickedThree = true;
                btnSquare4.Enabled = false;
            }

            //Square 9 and 3 taken by user 
            else if (blnClickedSix == false && blnClickedNine == true && blnClickedThree == true && compMoves[0] != 8 && compMoves[1] != 8 && compMoves[2] != 8 && compMoves[3] != 8 && compMoves[4] != 8 && compMoves[0] != 4 && compMoves[1] != 4 && compMoves[2] != 4 && compMoves[3] != 4 && compMoves[4] != 4)
            {
                this.btnSquare3.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 3;
                blnClickedSix = true;
                btnSquare3.Enabled = false;
            }

            //Square 9 and 7 taken by user 
            else if (blnClickedEight == false && blnClickedNine == true && blnClickedSeven == true && compMoves[0] != 8 && compMoves[1] != 8 && compMoves[2] != 8 && compMoves[3] != 8 && compMoves[4] != 8 && compMoves[0] != 6 && compMoves[1] != 6 && compMoves[2] != 6 && compMoves[3] != 6 && compMoves[4] != 6)
            {
                this.btnSquare1.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 1;
                blnClickedEight = true;
                btnSquare1.Enabled = false;
            }

            //Square 9 and 8 taken by user 
            else if (blnClickedSeven == false && blnClickedNine == true && blnClickedEight == true && compMoves[0] != 8 && compMoves[1] != 8 && compMoves[2] != 8 && compMoves[3] != 8 && compMoves[4] != 8 && compMoves[0] != 1 && compMoves[1] != 1 && compMoves[2] != 1 && compMoves[3] != 1 && compMoves[4] != 1)
            {
                this.btnSquare6.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 6;
                blnClickedSeven = true;
                btnSquare6.Enabled = false;
            }

            //Square 6 and 3 taken by user 
            else if (blnClickedNine == false && blnClickedSix == true && blnClickedThree == true && compMoves[0] != 3 && compMoves[1] != 3 && compMoves[2] != 3 && compMoves[3] != 3 && compMoves[4] != 3 && compMoves[0] != 4 && compMoves[1] != 4 && compMoves[2] != 4 && compMoves[3] != 4 && compMoves[4] != 4)
            {
                this.btnSquare8.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 8;
                blnClickedNine = true;


                btnSquare8.Enabled = false;
            }

            //Square 7 and 8 taken by user 
            else if (blnClickedNine == false && blnClickedSeven == true && blnClickedEight == true && compMoves[0] != 6 && compMoves[1] != 6 && compMoves[2] != 6 && compMoves[3] != 6 && compMoves[4] != 6 && compMoves[0] != 1 && compMoves[1] != 1 && compMoves[2] != 1 && compMoves[3] != 1 && compMoves[4] != 1)
            {
                this.btnSquare8.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 8;
                blnClickedNine = true;


                btnSquare8.Enabled = false;
            }

            //Square 7 and 4 taken by user 
            else if (blnClickedOne == false && blnClickedSeven == true && blnClickedFour == true && compMoves[0] != 6 && compMoves[1] != 6 && compMoves[2] != 6 && compMoves[3] != 6 && compMoves[4] != 6 && compMoves[0] != 7 && compMoves[1] != 7 && compMoves[2] != 7 && compMoves[3] != 7 && compMoves[4] != 7)
            {
                this.btnSquare2.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 2;
                blnClickedOne = true;
                btnSquare2.Enabled = false;
            }

            //Square 2 and 3 taken by user 
            else if (blnClickedOne == false && blnClickedTwo == true && blnClickedThree == true && compMoves[0] != 9 && compMoves[1] != 9 && compMoves[2] != 9 && compMoves[3] != 9 && compMoves[4] != 9 && compMoves[0] != 4 && compMoves[1] != 4 && compMoves[2] != 4 && compMoves[3] != 4 && compMoves[4] != 4)
            {
                this.btnSquare2.BackgroundImage = Resource1.dog;
                compMoves[intCounterComp] = 2;
                blnClickedOne = true;
                btnSquare2.Enabled = false;
            }


        }

        //Variables for checking the difference between array locations used in methods 
        int intCheckDifference = 0;
        int intCheckDifference2 = 0;
        int intCheckDifference3 = 0;
        int intCheckDifference4 = 0;
        int intCheckDifference5 = 0;
        int intCheckDifference6 = 0;




        public void CheckIfComputerCanWin1() //Diff between array location 1 and 0
        {
            intCheckDifference = 15 - compMoves[1] - compMoves[0];
        }

        public void CheckIfComputerCanWin2() //Diff between array location 2 and 0 
        {
            intCheckDifference2 = 15 - compMoves[2] - compMoves[0];
        }

        public void CheckIfComputerCanWin3() //Diff between array location 2 and 1 
        {
            intCheckDifference3 = 15 - compMoves[2] - compMoves[1];
        }

        public void CheckIfComputerCanWin4() //Diff between array location 3 and 0 
        {
            intCheckDifference4 = 15 - compMoves[3] - compMoves[0];
        }

        public void CheckIfComputerCanWin5() //Diff between array location 3 and 1 
        {
            intCheckDifference5 = 15 - compMoves[3] - compMoves[1];
        }

        public void CheckIfComputerCanWin6() //Diff between Array Location 3 and 2 
        {
            intCheckDifference6 = 15 - compMoves[3] - compMoves[2];
        }



        //Reset game method 
        public void ResetGame()
        {
            //Enables the buttons to choose who goes first 
            btnComputerFirst.Enabled = true;
            btnUserFirst.Enabled = true;
            this.lblWinner.Text = "Winner: Undecided"; //Resets winner display

            //Changes the backgrounds of the buttons back to normal 
            this.btnSquare1.BackgroundImage = null;
            this.btnSquare2.BackgroundImage = null;
            this.btnSquare3.BackgroundImage = null;
            this.btnSquare4.BackgroundImage = null;
            this.btnSquare5.BackgroundImage = null;
            this.btnSquare6.BackgroundImage = null;
            this.btnSquare7.BackgroundImage = null;
            this.btnSquare8.BackgroundImage = null;
            this.btnSquare9.BackgroundImage = null;

            //Disables all the buttons in the tic tac toe except who goes first, exit, and reset
            btnSquare1.Enabled = false;
            btnSquare2.Enabled = false;
            btnSquare3.Enabled = false;
            btnSquare4.Enabled = false;
            btnSquare5.Enabled = false;
            btnSquare6.Enabled = false;
            btnSquare7.Enabled = false;
            btnSquare8.Enabled = false;
            btnSquare9.Enabled = false;

            //Reverts boolean values for each button to false 
            blnClickedOne = false;
            blnClickedTwo = false;
            blnClickedThree = false;
            blnClickedFour = false;
            blnClickedFive = false;
            blnClickedSix = false;
            blnClickedSeven = false;
            blnClickedEight = false;
            blnClickedNine = false;

            blnPlayerTurn = true; //player goes first 

            intCounterPlayer = -1; //Reset counter
            intCounterComp = -1; //Reset counter

            //Resets the array values to -99 for all 
            playerMoves[0] = -99;
            playerMoves[1] = -99;
            playerMoves[2] = -99;
            playerMoves[3] = -99;
            playerMoves[4] = -99;

            //Resets the array values to -99 for all 
            compMoves[0] = -99;
            compMoves[1] = -99;
            compMoves[2] = -99;
            compMoves[3] = -99;
            compMoves[4] = -99;

            pcbWinnerPicture.Image = Resource1.catanddog; //Reverts winner display picture to default 

            blnUserOrCompFirst = false; //Who goes first boolean is reset 


        }
    }
}


