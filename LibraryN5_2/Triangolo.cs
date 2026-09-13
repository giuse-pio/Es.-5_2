using System.Globalization;

namespace LibraryN5_2
{
    public class Triangolo
    {
        private readonly double _lato;

        public double Lato => _lato;

        public Triangolo(double lato)
        {
            if (lato < 0)
            {
                throw new ArgumentException("Il lato del triangolo non può essere negativo.");
            }
            _lato = lato;
        }

        // Rappresentazione in stringa
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Tv{0}", Lato);
        }


        public static Triangolo operator +(Triangolo t1, Triangolo t2)
        {
            if (t1 == null || t2 == null)
                throw new ArgumentNullException("Impossibile sommare triangoli nulli.");
            double areat1 = (Math.Sqrt(3) / 4) * Math.Pow(t1.Lato, 2);
            double areat2 = (Math.Sqrt(3) / 4) * Math.Pow(t1.Lato, 2);
            double areatot = areat1 + areat2;
            double nuovoLato = Math.Sqrt((4 * areatot) / Math.Sqrt(3));
            return new Triangolo(nuovoLato);
        }

        public static bool operator ==(Triangolo t1, Triangolo t2)
        {
            if (ReferenceEquals(t1, t2)) return true;
            if (ReferenceEquals(t1, null) || ReferenceEquals(t2, null)) return false;
            return t1.Lato == t2.Lato;
        }

        public static bool operator !=(Triangolo t1, Triangolo t2)
        {
            return !(t1 == t2);
        }

        public static bool operator >(Triangolo t1, Triangolo t2)
        {
            if (ReferenceEquals(t1, t2)) return false;
            if (ReferenceEquals(t1, null)) return false;
            if (ReferenceEquals(t2, null)) return true;
            return t1.Lato > t2.Lato;
        }

        public static bool operator <(Triangolo t1, Triangolo t2)
        {
            if (!ReferenceEquals(t1, t2)) return false;
            if (ReferenceEquals(t1, null)) return true;
            if (ReferenceEquals(t2, null)) return false;
            return t1.Lato < t2.Lato;
        }

        public override bool Equals(object obj)
        {
            if (obj is Triangolo triangolo)
                return this == triangolo;
            return false;
        }

        public override int GetHashCode()
        {
            return Lato.GetHashCode();
        }

        public static bool TryParse(string s, out Triangolo result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            string inputPulito = s.Trim();

            if (!inputPulito.StartsWith("Tv"))
            {
                return false;
            }

            string valoreTesto = inputPulito.Substring(2).Trim();

            if (double.TryParse(valoreTesto, out double lato))
            {
                if (lato >= 0)
                {
                    result = new Triangolo(lato);
                    return true;
                }
            }

            return false;

        }
    }
}
