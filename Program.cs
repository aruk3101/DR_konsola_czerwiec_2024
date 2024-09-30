
namespace ConsoleApp1
{
    internal class Program
    {
        public static void Losuj(int liczbaKostek, out List<int> rzutyKostka)
        {
            Random generatorLiczbLosowych = new Random();
            rzutyKostka = new List<int>();
            for (int i = 0; i < liczbaKostek; i++)
            {
                int wynikRzutu = generatorLiczbLosowych.Next(1, 7); ;
                rzutyKostka.Add(wynikRzutu);
                Console.WriteLine($"Kostka {i + 1}: {wynikRzutu}");
            }
        }

        /****************
            nazwa:                 LiczPunkty
            opis:                  funkcja zlicza liczbę uzyskanych punktów w losowaniu
            parametry:             rzutyKostka - Lista elementów typu całkowitego z zakresu 1-6 która zawiera zbiór wylosowanych liczb
            zwracany typ i opis:   liczba całkowita, liczba uzyskanych punktów w losowaniu
            autor:                 PESEL   
         **************/
        public static int LiczPunkty(List<int> rzutyKostka)
        {
            return rzutyKostka
                    .GroupBy(rzut => rzut)
                    .Where(grupaRzutow => grupaRzutow.Count() >= 2)
                    .SelectMany(grupaRzutow => Enumerable.Repeat(grupaRzutow.Key, grupaRzutow.Count()))
                    .ToList()
                    .Sum();

            //int iloscOczek = 0;
            //for (int i = 1; i <= 6; i++)
            //{
            //    int liczbaPowtorzen = 0;
            //    foreach (int wynik in rzutyKostka)
            //    {
            //        if (wynik == i)
            //        {
            //            liczbaPowtorzen++;
            //        }
            //    }
            //    if (liczbaPowtorzen >= 2)
            //    {
            //        iloscOczek += i * liczbaPowtorzen;
            //    }
            //}

            //return iloscOczek;
        }
    


        static void Main(string[] args)
        {

            int liczbaKostek = 0;
            do
            {
                Console.WriteLine("Ile kostek chcesz rzucić?(3 - 10)");
            }
            while (int.TryParse(Console.ReadLine(), out liczbaKostek) == false || liczbaKostek < 3 || liczbaKostek > 10);

            bool koniec = false;
            do
            {
                Losuj(liczbaKostek, out List<int> rzutyKostka); 

                int liczbaPunktow = LiczPunkty(rzutyKostka);

                Console.WriteLine($"Liczba uzyskanych punktów : {liczbaPunktow}");

                Console.WriteLine("Jeszcze raz? (t/n)");
                koniec = (Console.ReadKey().Key == ConsoleKey.T);
                Console.WriteLine();
            }
            while (koniec);
        }
    }
}
