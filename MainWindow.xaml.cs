using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PixelGridApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RowsInput.Text, out int rows) && int.TryParse(ColumnsInput.Text, out int columns))
            {
                if (rows >= 1 && rows <= 10 && columns >= 1 && columns <= 10)
                {
                    GenerateGrid(rows, columns);
                }
                else
                {
                    MessageBox.Show("Error! Please enter numbers between 1 and 10 for both rows and columns.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Numbers only.");
            }
        }

        private void GenerateGrid(int rows, int columns)
        {
            PixelGrid.Children.Clear();
            PixelGrid.Rows = rows;
            PixelGrid.Columns = columns;

            for (int i = 0; i < rows * columns; i++)
            {
                var cell = new Border
                {
                    Background = Brushes.Black,
                    Margin = new Thickness(1),
                    Width = 30,
                    Height = 30
                };

                cell.MouseLeftButtonDown += (s, e) =>
                {
                    var border = s as Border;
                    if (border.Background == Brushes.Black)
                        border.Background = Brushes.White;
                    else
                        border.Background = Brushes.Black;
                };

                PixelGrid.Children.Add(cell);
            }
        }
    }
}
