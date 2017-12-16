using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        int turnCounter = 0;
        int colCounter = 0;
        int getCol = 0;
        int getRow = 0;
        int[,] full = new int[7, 7] {
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0}
            };

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

        }//end createGame


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            String buttonid = radioButton.Name;

            TextBlock chosenColour = new TextBlock();

            Button next = new Button();
            next.Content = "Next";

            if (buttonid == "RadioButton1")
            {
                chosenColour.Text = "Player 1 is Red";
                selectedColour.Children.Clear();
                selectedColour.Children.Add(chosenColour);
                selectedColour.Children.Add(next);
                Grid.SetColumn(chosenColour, 0);
                Grid.SetColumn(next, 1);
                turnCounter = 0;
            }

            else if (buttonid == "RadioButton2")
            {
                chosenColour.Text = "Player 1 is Yellow";
                selectedColour.Children.Clear();
                selectedColour.Children.Add(chosenColour);
                selectedColour.Children.Add(next);
                Grid.SetColumn(chosenColour, 0);
                Grid.SetColumn(next, 1);
                turnCounter = 1;
            }

            //button starts game
            next.Click += StartGame;
        }

        void StartGame(object sender, RoutedEventArgs e)
        {
            //Clear StackPanel
            ChooseColour.Children.Clear();

            Grid grid = new Grid();
            //Variables
            int rows = 7;
            int cols = 7;
            int cellSize = 50;

            //Grid details
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.Width = cols * cellSize;
            grid.Height = rows * cellSize;
            grid.Background = new SolidColorBrush(Colors.Black);
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

            ChooseColour.Children.Add(grid);

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
                    border.Background = new SolidColorBrush(Colors.White);
                    grid.Children.Add(border);
                }
            }

            //Buttons
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    
                    Button button = new Button();
                    button.Content = i.ToString();
                    button.Name = j.ToString();
                    button.Tag = j;
                    button.Height = cellSize - 4;
                    button.Width = cellSize - 4;
                    button.Background = new SolidColorBrush(Colors.White);
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

                chip.Width = 30;
                chip.Height = 30;
                chip.HorizontalAlignment = HorizontalAlignment.Center;
                chip.VerticalAlignment = VerticalAlignment.Center;

                turnCounter++;

                Grid.SetColumn(chip,getCol);
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

                btn.Content = getCol;
                 
                //Chip placement
                int foundRow = 0;
                for (int row = 6; row > -1; row--)
                {
                    switch (full[row, getCol])
                    {
                        case 0:
                        Ellipse chip = new Ellipse();
                        CreateEllipse();
                        getRow = row;
                        foundRow = 1;
                            break;
                        case 1:
                            break;
                    }

                    while(row == 0)
                    {
                    if(full[row,getCol] == 1)
                    {
                        string message = "This Collumn is full";
                        // var result = MessageBox.Show(message);
                        turnCounter--;
                    }
                    }

                    if(foundRow == 1)
                    break;
                    
                }

                //chipHolder.Children.Add(chip);


            }
        }//Start Game


    }
}
