using System.Text;

namespace ConversiiBaze
{
    internal class Program
    {
        static string ConvertesteParteaIntreagaDinBaza10(int parteIntreaga, int b2)
        {
            StringBuilder rezultat = new StringBuilder();

            do
            {
                int rest = parteIntreaga % b2;
                if (rest < 10)
                {
                    rezultat.Insert(0, (char)(rest + '0')); 
                }
                else
                {
                    rezultat.Insert(0, (char)(rest - 10 + 'A')); 
                }
                parteIntreaga /= b2;
            } while (parteIntreaga > 0);

            return rezultat.ToString();
        }

        
        static string ConvertesteParteaFractionaraDinBaza10(double parteFractionara, int b2, int precizie = 5)
        {
            StringBuilder rezultat = new StringBuilder();
            for (int i = 0; i < precizie; i++)
            {
                parteFractionara *= b2;
                int cifra = (int)parteFractionara;
                if (cifra < 10)
                {
                    rezultat.Append((char)(cifra + '0'));
                }
                else
                {
                    rezultat.Append((char)(cifra - 10 + 'A')); 
                }

                parteFractionara -= cifra;

                if (parteFractionara == 0)
                {
                    break;
                }
            }
            return rezultat.ToString();
        }

        
        static int ConvertesteParteaIntreagaInBaza10(string parteIntreaga, int b1)
        {
            return Convert.ToInt32(parteIntreaga, b1);
        }


        static double ConvertesteParteaFractionaraInBaza10(string parteFractionara, int b1)
        {
            double valoareFinala = 0;
            double factorDeImpartire = 1.0 / b1;

            foreach (char cifra in parteFractionara)
            {
                int valoareCifra;
                if (cifra >= '0' && cifra <= '9')
                {
                    valoareCifra = cifra - '0';
                }
                else
                {
                    valoareCifra = char.ToUpper(cifra) - 'A' + 10;
                }

                valoareFinala += valoareCifra * factorDeImpartire;
                factorDeImpartire /= b1;
            }
            return valoareFinala;
        }

        static void Main(string[] args)
        {
            Console.Write("Introduceti numarul pe care doriti sa il convertiti: ");
            string numar = Console.ReadLine();

            Console.Write("Introduceti baza in care se afla numarul (2-16): ");
            int b1 = int.Parse(Console.ReadLine());

            Console.Write("Introduceti baza in care doriti sa convertiti numarul (2-16): ");
            int b2 = int.Parse(Console.ReadLine());

            if (b1 < 2 || b1 > 16 || b2 < 2 || b2 > 16)
            {
                Console.WriteLine("Baza trebuie sa fie intre 2 si 16.");
                return;
            }

            string[] parti = numar.Split('.');

            int parteaIntreagaInDecimal = ConvertesteParteaIntreagaInBaza10(parti[0], b1);
            string parteaIntreagaInB2 = ConvertesteParteaIntreagaDinBaza10(parteaIntreagaInDecimal, b2);

            string rezultatFinal = parteaIntreagaInB2;

            if (parti.Length > 1)
            {
                double parteaFractionaraInDecimal = ConvertesteParteaFractionaraInBaza10(parti[1], b1);
                string parteaFractionaraInB2 = ConvertesteParteaFractionaraDinBaza10(parteaFractionaraInDecimal, b2);
                rezultatFinal += "." + parteaFractionaraInB2;
            }

            Console.WriteLine($"Numarul {numar} in baza {b1} este reprezentat sub forma {rezultatFinal} in baza {b2}");
        }
    }
}
