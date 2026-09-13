using LibraryN5_2;
namespace Es._5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Inserisci il primo triangolo (es. Tv5): ");
            string input1 = Console.ReadLine();
            Console.Write("Inserisci il secondo triangolo (es. Tv3): ");
            string input2 = Console.ReadLine();
            bool t1Valido = Triangolo.TryParse(input1, out Triangolo t1);
            bool t2Valido = Triangolo.TryParse(input2, out Triangolo t2);

            if (t1Valido && t2Valido)
            {
                Triangolo sommaTriangolo = t1 + t2;
                Console.WriteLine($"Primo triangolo: {t1}");
                Console.WriteLine($"Secondo triangolo: {t2}");
                Console.WriteLine($"Somma aree: {sommaTriangolo}");
                Console.WriteLine($"t1>t2? {t1 > t2}");
                Console.WriteLine($"Uguaglianza {t1 == t2}");
            }
            else
            {
                Console.WriteLine("\nErrore: Uno o entrambi i valori inseriti non sono rappresentazioni valide di un triangolo (devono iniziare con 'Tv').");
            }
        }
    }
}
