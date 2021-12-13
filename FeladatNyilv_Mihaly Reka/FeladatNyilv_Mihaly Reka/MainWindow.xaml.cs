using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeladatNyilv_Mihaly_Reka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CheckBox> feladatok = new List<CheckBox>();
        List<CheckBox> toroltek = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
            feladatList.ItemsSource = feladatok;
            toroltLista.ItemsSource = toroltek;
        }

        private void ujButton_Click(object sender, RoutedEventArgs e)
        {
            if (beFeladat.Text !="")
            {
                CheckBox uj = new CheckBox();
                uj.Content = beFeladat.Text;
                uj.Checked += new RoutedEventHandler(CheckBox_Checked);
                uj.Unchecked += new RoutedEventHandler(CheckBox_UnChecked);
                feladatok.Add(uj);
                feladatList.Items.Refresh(); 
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox aktualis = (CheckBox)sender;
            aktualis.FontStyle = FontStyles.Italic;
            aktualis.Foreground = Brushes.Gray;
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox aktualis = (CheckBox)sender;
            aktualis.FontStyle = FontStyles.Italic;
            aktualis.Foreground = Brushes.Black;
        }

        private void TorolButton_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt =(CheckBox) feladatList.SelectedItem;
            toroltek.Add(kijelolt);
            feladatok.Remove(kijelolt);
            feladatList.Items.Refresh();
            toroltLista.Items.Refresh();
        }

        private void VisszaallButton_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)toroltLista.SelectedItem;
            feladatok.Add(kijelolt);
            toroltek.Remove(kijelolt);
            toroltLista.Items.Refresh();
            feladatList.Items.Refresh();
        }


        private void VTorolButton_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)toroltLista.SelectedItem;
            toroltek.Remove(kijelolt);
            toroltLista.Items.Refresh();
        }

        private void modositGomb_Click(object sender, RoutedEventArgs e)
        {
            CheckBox kijelolt = (CheckBox)feladatList.SelectedItem;
            kijelolt.Content = beFeladat.Text;
            feladatList.Items.Refresh();
        }
    }

}
