using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Stickers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlSerializer formatter = new XmlSerializer(typeof(List<string>));
        List<Item> listOfItem = new List<Item>();



        public MainWindow()
        {
            InitializeComponent();

            LoadDate();
        }

        /// <summary>
        /// Create new item in sticker
        /// </summary>
        private void CreateItem(string textItem = "")
        {
            Item item = new Item(listOfItems, textItem);
            item.textBox.KeyDown += textBoxKeyDown;
            item.button.Click += Button_Click;

            listOfItem.Add(item);
        }

        private void textBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CreateItem();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GroupBox groupBoxItem = (GroupBox)((Grid)((Button)sender).Parent).Parent;

            listOfItems.Children.Remove(groupBoxItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateItem();
        }

        private void stickerName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (stickerName.Text == "Name of your sticker here")
                stickerName.Text = "";
        }

        private void stickerName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (stickerName.Text == "")
                stickerName.Text = "Name of your sticker here";
        }

        private void SaveDate()
        {
            List<string> str = new List<string>();
            foreach (object i in listOfItems.Children)
            {

                if (i is GroupBox)
                {
                    object s = (i as GroupBox).Content;

                    object a = (s as Grid).Children[1];

                    str.Add((a as TextBox).Text);
                }


            }

            File.Delete("items.xml");

            using (FileStream fs = new FileStream("items.xml", FileMode.OpenOrCreate))
            {

                formatter.Serialize(fs, str);

                fs.Close();
            }
        }

        private void LoadDate()
        {
            using (FileStream fs = new FileStream("items.xml", FileMode.OpenOrCreate))
            {
                List<string> newItems = (List<string>)formatter.Deserialize(fs);

                fs.Close();

                foreach (string item in newItems)
                {
                    CreateItem(item);
                }
            }


        }

        private void MainSticker_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDate();
        }

        private void MainSticker_Closed(object sender, System.EventArgs e)
        {
            SaveDate();
        }
    }
}
