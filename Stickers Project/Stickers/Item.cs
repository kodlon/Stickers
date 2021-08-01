using System;
using System.Windows;
using System.Windows.Controls;

namespace Stickers
{
    [Serializable]
    public class Item
    {
        [NonSerialized]
        internal GroupBox groupBox;
        [NonSerialized]
        internal Grid grid;
        [NonSerialized]
        internal CheckBox checkBox;
        [NonSerialized]
        internal TextBox textBox;
        [NonSerialized]
        internal Button button;

        [NonSerialized]
        static int id = 0;
        [NonSerialized]
        internal int idItem = id;

        public string textItem = "Hello world!";

        public Item()
        {

        }

        public Item(StackPanel listOfItems, string text = "")
        {
            groupBox = new GroupBox();
            grid = new Grid();
            checkBox = new CheckBox();
            textBox = new TextBox();
            button = new Button();


            groupBox.HorizontalAlignment = HorizontalAlignment.Center;
            groupBox.Name = "groupBox" + id;

            checkBox.HorizontalAlignment = HorizontalAlignment.Left;
            checkBox.Margin = new Thickness(3, 6, 0, 0);
            checkBox.VerticalAlignment = VerticalAlignment.Top;
            checkBox.Width = 16;

            textBox.HorizontalAlignment = HorizontalAlignment.Left;
            textBox.Margin = new Thickness(25, 5, 0, 5);
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.Text = text;
            textBox.VerticalAlignment = VerticalAlignment.Top;
            textBox.Width = 140;
            textBox.Focusable = true;
            //textBox.KeyDown += textBoxKeyDown;
            //textItem = this.textBox.Text;

            //textBox.Focus();
            //Keyboard.Focus(textBox);

            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.Margin = new Thickness(170, 0, 0, 0);
            button.Height = 17;
            button.Width = 26;
            button.Content = "Del";
            button.FontSize = 11;
            //button.Click += Button_Click;


            groupBox.Content = grid;
            grid.Children.Add(checkBox);
            grid.Children.Add(textBox);
            grid.Children.Add(button);

            listOfItems.Children.Add(groupBox);

            id++;
        }

        public override string ToString()
        {
            return $"{textBox.Text}";
        }

        public void DeleteItem()
        {
            grid.Children.Clear();
        }
    }
}
