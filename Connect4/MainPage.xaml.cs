﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Connect4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Public Variables
        string p1 = "", p2 = "";
        int turnCounter = 0;
        int colCounter = 0;
        int getCol = 0;
        int getRow = 0;
        int winner = 0;
        int checkRed = 0;
        int playerCorrector = 0;
        int[,] gameGrid = new int[7, 7] {
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
        };
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            createGame();
        }

        private void createGame()
        {
            //Local Settings
            ApplicationDataContainer container = localSettings.CreateContainer("Names", ApplicationDataCreateDisposition.Always);
            object p1obj;
            object p2obj;
            string p1Default;
            string p2Default;

            p1obj = localSettings.Containers["Names"].Values["P1"];
            p2obj = localSettings.Containers["Names"].Values["P2"];
            p1Default = (string)p1obj;
            p2Default = (string)p2obj;

            if (p2Default == null)
                P2.Text = "Player 2";
            else
                P2.Text = p2Default;

            if (p1Default == null)
                P1.Text = "Player 1";
            else
                P1.Text = p1Default;

        }//end createGame

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            String buttonid = radioButton.Name;
            TextBlock chosenColour = new TextBlock();
            Button next = new Button();

            next.Content = "Begin Match!";

            if (buttonid == "RadioButton1")
            {
                checkRed = 1;
                selectedColour.Background = new SolidColorBrush(Colors.Red);
                P1Color.Background = new SolidColorBrush(Colors.Red);
                P2Color.Background = new SolidColorBrush(Colors.Yellow);
                playerNames.Background = new SolidColorBrush(Colors.Black);
                MainPanel.Background = new SolidColorBrush(Colors.Black);
                Radiobtn.Background = new SolidColorBrush(Colors.Yellow);
                title.Foreground = new SolidColorBrush(Colors.White);
                choiceText.Foreground = new SolidColorBrush(Colors.White);
                next.Foreground = new SolidColorBrush(Colors.White);
                playerNames.Background = new SolidColorBrush(Colors.Black);
                MainPanel.Background = new SolidColorBrush(Colors.Black);
                Radiobtn.Background = new SolidColorBrush(Colors.Yellow);
                title.Foreground = new SolidColorBrush(Colors.White);
                choiceText.Foreground = new SolidColorBrush(Colors.White);
                next.Background = new SolidColorBrush(Colors.Maroon);
                chosenColour.Text = "Player 1 is Red";
                chosenColour.VerticalAlignment = VerticalAlignment.Center;
                selectedColour.Children.Clear();
                selectedColour.Children.Add(chosenColour);
                selectedColour.Children.Add(next);
                Grid.SetColumn(chosenColour, 0);
                Grid.SetColumn(next, 1);
                turnCounter = 0;
                playerCorrector = 0;
            }

            else if (buttonid == "RadioButton2")
            {
                checkRed = 0;
                selectedColour.Background = new SolidColorBrush(Colors.Yellow);
                P1Color.Background = new SolidColorBrush(Colors.Yellow);
                P2Color.Background = new SolidColorBrush(Colors.Red);
                playerNames.Background = new SolidColorBrush(Colors.Black);
                MainPanel.Background = new SolidColorBrush(Colors.Black);
                Radiobtn.Background = new SolidColorBrush(Colors.Red);
                title.Foreground = new SolidColorBrush(Colors.White);
                choiceText.Foreground = new SolidColorBrush(Colors.White);
                next.Foreground = new SolidColorBrush(Colors.White);
                playerNames.Background = new SolidColorBrush(Colors.Black);
                MainPanel.Background = new SolidColorBrush(Colors.Black);
                Radiobtn.Background = new SolidColorBrush(Colors.Red);
                title.Foreground = new SolidColorBrush(Colors.White);
                choiceText.Foreground = new SolidColorBrush(Colors.White);
                next.Background = new SolidColorBrush(Colors.DarkOrange);
                chosenColour.Text = "Player 1 is Yellow";
                chosenColour.VerticalAlignment = VerticalAlignment.Center;
                selectedColour.Children.Clear();
                selectedColour.Children.Add(chosenColour);
                selectedColour.Children.Add(next);
                Grid.SetColumn(chosenColour, 0);
                Grid.SetColumn(next, 1);
                turnCounter = 1;
                playerCorrector = -1;
            }

            next.Click += StartGame;
        }

        void StartGame(object sender, RoutedEventArgs e)
        {
            //Default Names
            if (P1.Text == "")
                P1.Text = "Player1";

            if (P2.Text == "")
                P2.Text = "Player2";

            //Remember Names
            ApplicationDataContainer container = localSettings.CreateContainer("Names", ApplicationDataCreateDisposition.Always);
            p1 = P1.Text;
            p2 = P2.Text;

            localSettings.Containers["Names"].Values["P1"] = p1;
            localSettings.Containers["Names"].Values["P2"] = p2;

            //Clear Main StackPanel
            MainPanel.Children.Clear();
            MainPanel.Background = new SolidColorBrush(Colors.Gray);

            Grid grid = new Grid();
            grid.Margin = new Thickness(0, 50, 0, 0);
            //Variables for grid
            int rows = 7;
            int cols = 7;
            int cellSize = 50;

            //Grid details
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.Width = cols * cellSize;
            grid.Height = rows * cellSize;
            grid.Background = new SolidColorBrush(Colors.White);
            grid.Margin = new Thickness(5);

            //Create 7x7 grid
            for (int i = 0; i < 7; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());

            }

            for (int i = 0; i < 7; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            MainPanel.Children.Add(grid);

            //Border
            Border border;
            for (int row = 0; row < rows; ++row)
            {
                for (int col = 0; col < cols; ++col)
                {

                    border = new Border();
                    border.Height = cellSize - 4;
                    border.Width = cellSize - 4;
                    border.HorizontalAlignment = HorizontalAlignment.Center;
                    border.VerticalAlignment = VerticalAlignment.Center;
                    border.SetValue(Grid.RowProperty, row);
                    border.SetValue(Grid.ColumnProperty, col);
                    border.Background = new SolidColorBrush(Colors.Black);
                    grid.Children.Add(border);
                }
            }

            //Buttons
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    Button button = new Button();
                    button.Content = "";
                    button.Name = j.ToString();
                    button.Tag = j;
                    button.Height = cellSize - 4;
                    button.Width = cellSize - 4;
                    // button.Background = new SolidColorBrush(Colors.White);
                    button.Click += ButtonClick;

                    Grid.SetColumn(button, j);
                    Grid.SetRow(button, i);
                    grid.Children.Add(button);
                }

            } //buttons in grid

            void CreateEllipse()
            {
                Ellipse chip = new Ellipse();

                //Decide Colour
                if (turnCounter % 2 == 0)
                {
                    chip.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    chip.Fill = new SolidColorBrush(Colors.Yellow);
                }

                //Chip details
                chip.Width = 30;
                chip.Height = 30;
                chip.HorizontalAlignment = HorizontalAlignment.Center;
                chip.VerticalAlignment = VerticalAlignment.Center;

                Grid.SetColumn(chip, getCol);
                Grid.SetRow(chip, getRow);
                grid.Children.Add(chip);

            }

            void ButtonClick(object sender1, RoutedEventArgs e1)
            {
                //Get Name Property of button
                DependencyObject dpobj = sender1 as DependencyObject;
                string name = dpobj.GetValue(FrameworkElement.NameProperty) as string;

                //sender as button
                Button btn = (Button)sender1;
                btn.Content = "";

                //Stackpanel to hold ellipse
                StackPanel chipHolder = new StackPanel();

                chipHolder.Height = 64;
                chipHolder.Width = 64;
                chipHolder.VerticalAlignment = VerticalAlignment.Center;
                chipHolder.HorizontalAlignment = HorizontalAlignment.Center;
                chipHolder.Orientation = Orientation.Vertical;

                //Get Column
                switch (name)
                {
                    case "0":
                        getCol = 0;
                        break;
                    case "1":
                        getCol = 1;
                        break;
                    case "2":
                        getCol = 2;
                        break;
                    case "3":
                        getCol = 3;
                        break;
                    case "4":
                        getCol = 4;
                        break;
                    case "5":
                        getCol = 5;
                        break;
                    case "6":
                        getCol = 6;
                        break;
                }

                //Chip placement
                int foundRow = 0;
                for (int row = 6; row > -1; row--)
                {
                    switch (gameGrid[row, getCol])
                    {
                        case 0:
                            Ellipse chip = new Ellipse();
                            getRow = row;
                            CreateEllipse();
                            foundRow = 1;
                            if (turnCounter % 2 == 0)
                            {
                                gameGrid[row, getCol] = 1;
                            }
                            else
                            {
                                gameGrid[row, getCol] = 2;
                            }

                            checkStatus();
                            turnCounter++;
                            break;
                        case 1:
                            break;
                    }

                    while (row == 0)
                    {
                        if (gameGrid[row, getCol] == 1)
                        {
                            turnCounter--;
                        }
                    }

                    if (foundRow == 1)
                        break;

                }

            }
        }//Start Game

        private void checkStatus()
        {
            int player = 0;

            if (turnCounter % 2 == 0)
            {
                player = 1;
            }
            else
            {
                player = 2;
            }

            for (int i = 6; i >= 3; i--)
            {
                for (int j = 6; j >= 3; j--)
                {
                    //Offset(-1,-1) Up and Right
                    if (gameGrid[i, j] == player &&
                        gameGrid[i - 1, j - 1] == player &&
                        gameGrid[i - 2, j - 2] == player &&
                        gameGrid[i - 3, j - 3] == player)
                    {
                        winner = player;
                    }
                }
            }

            for (int i = 6; i >= 0; i--)
            {
                for (int j = 6; j >= 3; j--)
                {
                    //Offset(0,1) Horizontal 
                    if (gameGrid[i, j] == player &&
                        gameGrid[i, j - 1] == player &&
                        gameGrid[i, j - 2] == player &&
                        gameGrid[i, j - 3] == player)
                    {
                        winner = player;
                    }
                }
            }

            for (int i = 3; i >= 0; i--)
            {
                for (int j = 6; j >= 3; j--)
                {
                    //Offset(1,-1) Down and Left
                    if (gameGrid[i, j] == player &&
                        gameGrid[i + 1, j - 1] == player &&
                        gameGrid[i + 2, j - 2] == player &&
                        gameGrid[i + 3, j - 3] == player)
                    {
                        winner = player;
                    }
                }
            }

            for (int i = 3; i >= 0; i--)
            {
                for (int j = 6; j >= 0; j--)
                {
                    //Offset(1,0) Vertical
                    if (gameGrid[i, j] == player &&
                        gameGrid[i + 1, j] == player &&
                        gameGrid[i + 2, j] == player &&
                        gameGrid[i + 3, j] == player)
                    {
                        winner = player;
                    }
                }
            }


            if (winner > 0)
            {
                GameWinner();
            }
        }//CheckBoard

        private void GameWinner()
        {
            //Clear StackPanel
            MainPanel.Children.Clear();

            Button restart = new Button();
            Button endGame = new Button();
            StackPanel DisplayChamp = new StackPanel();
            StackPanel buttonHolder = new StackPanel();
            TextBlock displayWinner = new TextBlock();
            displayWinner.FontSize = 30;
            displayWinner.FontWeight = FontWeight;
            displayWinner.HorizontalAlignment = HorizontalAlignment.Center;
            DisplayChamp.Background = new SolidColorBrush(Colors.Silver);

            if (winner + playerCorrector == 1)
            {
                displayWinner.Text = "P1: " + p1 + " is the Winner!";
                if (checkRed == 1)
                {
                    displayWinner.Foreground = new SolidColorBrush(Colors.Maroon);
                    restart.Background = new SolidColorBrush(Colors.Red);
                    endGame.Background = new SolidColorBrush(Colors.Red);
                    buttonHolder.Background = new SolidColorBrush(Colors.Maroon);
                }
                else
                {
                    displayWinner.Foreground = new SolidColorBrush(Colors.Yellow);
                    restart.Background = new SolidColorBrush(Colors.Yellow);
                    endGame.Background = new SolidColorBrush(Colors.Yellow);
                    buttonHolder.Background = new SolidColorBrush(Colors.DarkOrange);
                }
            }
            else
            {
                displayWinner.Text = "P2: " + p2 + " is the Winner!";
                if (checkRed == 1)
                {
                    displayWinner.Foreground = new SolidColorBrush(Colors.Yellow);
                    restart.Background = new SolidColorBrush(Colors.Yellow);
                    endGame.Background = new SolidColorBrush(Colors.Yellow);
                    buttonHolder.Background = new SolidColorBrush(Colors.DarkOrange);
                }
                else
                {
                    displayWinner.Foreground = new SolidColorBrush(Colors.Maroon);
                    restart.Background = new SolidColorBrush(Colors.Red);
                    endGame.Background = new SolidColorBrush(Colors.Red);
                    buttonHolder.Background = new SolidColorBrush(Colors.Maroon);
                }
            }

            DisplayChamp.Margin = new Thickness(10, 50, 10, 50);
            buttonHolder.Orientation = Orientation.Horizontal;
            buttonHolder.HorizontalAlignment = HorizontalAlignment.Center;
            restart.Content = "Restart";
            restart.HorizontalAlignment = HorizontalAlignment.Center;
            endGame.Content = "endGame";
            endGame.HorizontalAlignment = HorizontalAlignment.Center;

            DisplayChamp.Children.Add(displayWinner);
            MainPanel.Children.Add(DisplayChamp);

            buttonHolder.Children.Add(restart);
            buttonHolder.Children.Add(endGame);
            MainPanel.Children.Add(buttonHolder);

            restart.Click += Restart_Click;
            endGame.Click += endGame_Click;


        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            restartGame();
        }

        private void restartGame()
        {
            MainPanel.Children.Clear();
            TextBlock t = new TextBlock();
            t.Text = "Choose a colour.";
            t.FontSize = 30;
            t.HorizontalAlignment = HorizontalAlignment.Center;

            RadioButton1.IsChecked = false;
            RadioButton2.IsChecked = false;
            selectedColour.Children.Clear();
            MainPanel.Children.Add(Title);
            MainPanel.Children.Add(t);
            MainPanel.Children.Add(chooseChip);
            MainPanel.Children.Add(Radiobtn);
            MainPanel.Children.Add(selectedColour);

            //Reset Variables
            turnCounter = 0;
            colCounter = 0;
            getCol = 0;
            getRow = 0;
            winner = 0;
            playerCorrector = 0;
            gameGrid = new int[7, 7] {
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };
        }

        private void endGame_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            TextBlock t = new TextBlock();
            t.Margin = new Thickness(10, 50, 10, 50);
            t.Text = "Thanks for Playing";
            t.FontSize = 30;
            t.HorizontalAlignment = HorizontalAlignment.Center;
            MainPanel.Children.Add(t);

        }
    }
}
