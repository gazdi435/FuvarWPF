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
using System.IO;

namespace dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// balra:Sinka József
    /// jobbra: Beke Tamás
    /// </summary>
    public partial class MainWindow : Window
    {
            List<Fuvar> ListaFuvarok = File.ReadAllLines("fuvar.csv").Skip(1).Select(x => new Fuvar(x)).ToList();
        public MainWindow()
        {
            InitializeComponent();
            ListaFuvarok.DistinctBy(x=>x.TaxiAzonosito).ToList().ForEach(x=>CBAzonositok.Items.Add(x.TaxiAzonosito));

        }

        private void utazasokSzama(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("3. feladat: " + ListaFuvarok.Count() + " fuvar");
        }

        private void megtettUt(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("6. feladat: " + ListaFuvarok.Sum(x => x.MegtettTav) * 1.6 + " km");
        }

        private void LeghosszabbFuvar(object sender, RoutedEventArgs e)
        {
            LBhetes.Items.Add($"Fuvar hossza: {ListaFuvarok.Max(x => x.Idotartam)} másodperc");
            LBhetes.Items.Add($"Taxi azonosító: { ListaFuvarok.Find(x => x.Idotartam == ListaFuvarok.Max(x => x.Idotartam)).TaxiAzonosito}");
            LBhetes.Items.Add($"Megtett távolság: {ListaFuvarok.Find(x => x.Idotartam == ListaFuvarok.Max(x => x.Idotartam)).MegtettTav * 1.6} km");
            LBhetes.Items.Add($" Viteldíj: {ListaFuvarok.Find(x => x.Idotartam == ListaFuvarok.Max(x => x.Idotartam)).VitelDij}");
        }

        private void Hibak(object sender, RoutedEventArgs e)
        {
            ListaFuvarok.Where(x => x.Idotartam > 0 && x.VitelDij > 0 && x.MegtettTav==0).ToList().ForEach(y => File.AppendAllText("Hibak.txt", $"{y.TaxiAzonosito};{y.IndulasIdopont};{y.Idotartam};{y.MegtettTav};{y.VitelDij};{y.Borravalo};{y.FizetesiMod}"));

        }

        private void FizetesiModok(object sender, RoutedEventArgs e)
        {

        }

        private void Bevetel(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"ListaFuvarok.Count(x=>x.TaxiAzonosito==Convert.ToInt32(CBAzonositok.SelectedIndex))" fuvar alatt: ListaFuvarok.Where(x=>x.TaxiAzonosito==Convert.ToInt32(CBAzonositok.SelectedIndex)).Sum(x=> x.viteldij));

        }
    }
}
