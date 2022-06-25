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

namespace Zadanie_2.Net
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dane dane = new Dane();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = dane;
        }

        private void Cyfra(object sender, RoutedEventArgs e)
        {
            dane.Litery(
                (string)((Button)sender).Content
            );

        }

        private void Przecinek(object sender, RoutedEventArgs e)
        {
            dane.Dopisz(
                (string)((Button)sender).Content
            );
        }

        private void Znak(object sender, RoutedEventArgs e)
        {
            dane.ZmieńZnak();
        }

        private void RównaSię(object sender, RoutedEventArgs e)
        {
            dane.Wykonaj();
        }

        private void Procent(object sender, RoutedEventArgs e)
        {
            dane.DziałanieProcentowe();
        }

        private void Operator(object sender, RoutedEventArgs e)
        {
            dane.PrzełączOperator(
                (string)((Button)sender).Content
            );
            dane.Operatory(
                (string)((Button)sender).Content
            );
        }

        private void Jednoargumentowe(object sender, RoutedEventArgs e)
        {
            dane.działaniaJednoargumentowe(
                (string)((Button)sender).Content
            );
        }

        private void Cofnij(object sender, RoutedEventArgs e)
        {
            dane.Cofnij();
        }

        private void Resetuj(object sender, RoutedEventArgs e)
        {
            dane.Resetuj();
        }

        private void Skasuj(object sender, RoutedEventArgs e)
        {
            dane.Resetuj();
        }
    }
}
