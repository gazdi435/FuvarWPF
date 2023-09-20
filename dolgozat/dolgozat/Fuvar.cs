using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozat
{
    internal class Fuvar
    {
        int taxiAzonosito;
        string indulasIdopont;
        int idotartam;
        double megtettTav;
        double vitelDij;
        double borravalo;
        string fizetesiMod;

        public Fuvar(string sor)
        {
            this.taxiAzonosito = Convert.ToInt32(sor.Split(';')[0]);
            this.indulasIdopont = sor.Split(';')[1];
            this.idotartam = Convert.ToInt32(sor.Split(';')[2]);
            this.megtettTav = Convert.ToDouble(sor.Split(';')[3]);
            this.vitelDij = Convert.ToDouble(sor.Split(';')[4]);
            this.borravalo = Convert.ToDouble(sor.Split(';')[5]);
            this.fizetesiMod = sor.Split(';')[6];
        }

        public int TaxiAzonosito { get => taxiAzonosito; }
        public string IndulasIdopont { get => indulasIdopont; }
        public int Idotartam { get => idotartam; }
        public double MegtettTav { get => megtettTav; }
        public double VitelDij { get => vitelDij; }
        public double Borravalo { get => borravalo; }
        public string FizetesiMod { get => fizetesiMod; }

        
    }
}
