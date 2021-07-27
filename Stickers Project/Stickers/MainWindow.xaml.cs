using System.Windows;
using System.Windows.Controls;

namespace Stickers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int idItem = 0;

        public MainWindow()
        {
            InitializeComponent();

            AddNewItemToStack(idItem);

        }

        /// <summary>
        /// Create new item in sticker
        /// </summary>
        public void AddNewItemToStack(int id)
        {
            GroupBox groupBox = new GroupBox();
            Grid grid = new Grid();
            CheckBox checkBox = new CheckBox();
            TextBox textBox = new TextBox();
            Button button = new Button();


            groupBox.HorizontalAlignment = HorizontalAlignment.Center;
            groupBox.Name = "checkbox" + id;

            checkBox.HorizontalAlignment = HorizontalAlignment.Left;
            checkBox.Margin = new Thickness(3, 6, 0, 0);
            checkBox.VerticalAlignment = VerticalAlignment.Top;
            checkBox.Width = 16;

            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.Margin = new Thickness(25, 5, 0, 5);
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Text = "";
            textBox.VerticalAlignment = VerticalAlignment.Top;
            textBox.Width = 140;

            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.Margin = new Thickness(170, 0, 0, 0);
            button.Height = 17;
            button.Width = 26;
            button.Content = "Del";
            button.FontSize = 11;
            button.Click += Button_Click;


            groupBox.Content = grid;
            grid.Children.Add(checkBox);
            grid.Children.Add(textBox);
            grid.Children.Add(button);

            listOfItems.Children.Add(groupBox);

            idItem++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GroupBox groupBoxItem = (GroupBox)((Grid)((Button)sender).Parent).Parent;

            listOfItems.Children.Remove(groupBoxItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNewItemToStack(idItem);
        }
    }
}
