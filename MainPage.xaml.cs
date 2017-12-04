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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Connect4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

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
            }
            else if (buttonid == "RadioButton2")
            {
                chosenColour.Text = "Player 1 is Yellow";
                selectedColour.Children.Clear();
                selectedColour.Children.Add(chosenColour);
                selectedColour.Children.Add(next);
                Grid.SetColumn(chosenColour, 0);
                Grid.SetColumn(next, 1);
            }

            //button starts game
            next.Click += StartGame;
        }

        void StartGame(object sender, RoutedEventArgs e)
        {
            //Clear StackPanel
            ChooseColour.Children.Clear();

            Grid grid = new Grid();
            Button button = new Button();
            button.Width = 40;
            button.Height = 40;
            button.Content = "here";

            int rows = 7;
            int cols = 7;
            int cellSize = 50;
            int ColCounter = 0;

            //Grid details
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.Width = cols * cellSize;
            grid.Height = rows * cellSize;
            grid.Background = new SolidColorBrush(Colors.Black);
            grid.Margin = new Thickness(5);

            TextBlock t = new TextBlock();
           
            //Create 7x7 grid
            for (int i = 0; i < 7; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                //Grid.SetRow(button, i);
                for (int j = 0; j < 7; j++)
                {
                    grid.SetValue(Grid.RowProperty, j);
                    grid.Children.Add(button);
                }
                grid.SetValue(Grid.ColumnProperty, i); 
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

            void SetupButtons()
            {
                Button button1 = new Button();
                SetupButton(button1, new RoutedEventHandler(AddChip));
            }

            void SetupButton(Button button1, RoutedEventHandler handler)
            {
                button1.Width = 50;
                button1.Height = 50;
                
                button1.Click += handler;
            }

            void AddChip(object sender1, RoutedEventArgs e1)
            {
                
            }
        }//Start Game

        

    }
}
