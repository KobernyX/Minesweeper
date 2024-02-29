namespace Minesweeper
{
    internal class Program
    {
        static int x;
        static int y;
        static void Main(string[] args)
        {
            int[,] hracipole = new int[10, 10];
            int[,] hracipole2 = new int[10, 10];
            char[] pismena = new char[10];
            NaplnPismena(pismena);
            VypisPismena(pismena);
            NaplnPole(hracipole, hracipole2);
            VypisPole2(hracipole2);
            hra(hracipole, pismena, hracipole2);
        }
        static void hra(int[,] hracipole, char[] pismena, int[,] hracipole2)
        {
            int zbyvajicipole = 100;

            while (zbyvajicipole > 10) // skonci cyklus kdyz odkryjete 90 policek na kterych neni mina
            {
                int cislo = 0;
                for (int r = 0; r < hracipole.GetLength(0); r++)
                {

                    for (int s = 0; s < hracipole.GetLength(1); s++) // overeni kolik bomb je vedle policka
                    {
                        if (s < 9 && hracipole[r, s + 1] == 11)
                        {
                            cislo++;

                        }
                        if (s > 0 && hracipole[r, s - 1] == 11)
                        {
                            cislo++;

                        }
                        if (s > 0 && r > 0 && hracipole[r - 1, s - 1] == 11)
                        {
                            cislo++;

                        }
                        if (r > 0 && hracipole[r - 1, s] == 11)
                        {
                            cislo++;

                        }
                        if (r > 0 && s < 9 && hracipole[r - 1, s + 1] == 11)
                        {
                            cislo++;

                        }
                        if (r < 9 && s > 0 && hracipole[r + 1, s - 1] == 11)
                        {
                            cislo++;

                        }
                        if (r < 9 && hracipole[r + 1, s] == 11)
                        {
                            cislo++;

                        }
                        if (r < 9 && s < 9 && hracipole[r + 1, s + 1] == 11)
                        {
                            cislo++;

                        }
                        if (hracipole[r, s] != 11)
                        {

                            hracipole[r, s] = cislo;
                        }
                        cislo = 0;
                    }
                }
                Console.WriteLine("Zadej souřandnice kam chceš vystřelit(např.: 7 pak G): "); //zadavání souřadnic
                Console.Write("řádek:  ");
                int radek = Parse();
                Console.Write("sloupec:  ");
                string pismenka = Console.ReadLine().ToUpper();
                int sloupec = PrevestNaChar(pismenka);

                if (radek < 1 || radek > 10 || sloupec < 1 || sloupec > 10) // ověření vstupu
                {
                    Console.Clear();
                    Console.Write("\n    ");
                    VypisPismena(pismena);
                    VypisPole2(hracipole2);
                    Console.WriteLine("Neplatné souřadnice. Zadej souřadnice znovu.");
                    continue;
                }


                if (hracipole[radek - 1, sloupec - 1] == 11) // kdyz mina
                {
                    Console.Clear();
                    Console.WriteLine("Prohrál jsi! zasáhl jsi minu!");
                    Console.Write("\n    ");
                    VypisPismena(pismena);
                    KonecPole(hracipole);
                    Console.WriteLine(" ");
                    zbyvajicipole = 10;
                }
                else //kdyz neni mina
                {
                    hracipole2[radek - 1, sloupec - 1] = hracipole[radek - 1, sloupec - 1]; // přiřadí hodnotu z pole ktere je naplneno hodnotami do prazdneho pole a vypise je to
                    Console.Clear();
                    Console.Write("    ");
                    VypisPismena(pismena);
                    VypisPole2(hracipole2);
                    zbyvajicipole--;
                }
            }
        }
        static void KonecPole(int[,] hracipole2) 
        {
            Console.WriteLine("");
            for (int radek = 0; radek < hracipole2.GetLength(0); radek++)
            {
                if (radek + 1 < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" {radek + 1}| ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{radek + 1}| ");
                    Console.ResetColor();
                }
                for (int sloupec = 0; sloupec < hracipole2.GetLength(1); sloupec++)
                {
                    int hodnota = hracipole2[radek, sloupec];
                    //vypis cisel po skončení hry
                    if (hracipole2[radek, sloupec] == 10)
                    {
                        Console.Write("■ ");
                    }
                    else if (hracipole2[radek, sloupec] == 11)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("♦ ");
                        Console.ResetColor();
                    }
                    else
                    {
                       /* if (hodnota > 0)
                        {*/
                            Console.Write(hodnota + " ");
                      //  }
                       /* else
                        {
                            Console.Write("■ ");
                        }*/
                    }
                }
                Console.WriteLine();
            }
        }
        static void VypisPole2(int[,] hracipole2)    // vypise pole a čísílka vlevo + zasahy  
        {
            Console.WriteLine("");
            for (int radek = 0; radek < hracipole2.GetLength(0); radek++)
            {
                if (radek + 1 < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($" {radek + 1}| ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{radek + 1}| ");
                    Console.ResetColor();
                }
                for (int sloupec = 0; sloupec < hracipole2.GetLength(1); sloupec++)
                {
                    int hodnota = hracipole2[radek, sloupec]; // Zde získáme hodnotu z pole hracipole na aktuální pozici
                    if (hodnota == 10)
                    {
                        Console.Write("■ ");
                    }
                    else if (hodnota == 11)
                    {
                        Console.Write("■ ");
                    }
                    else
                    {
                        Console.Write(hodnota + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void NaplnPole(int[,] hracipole, int[,] hracipole2) // naplni oba pole
        {
            Random random = new Random();

            int i = 10;
            for (int radek = 0; radek < hracipole.GetLength(0); radek++)
            {
                for (int sloupec = 0; sloupec < hracipole.GetLength(1); sloupec++)
                {
                    hracipole2[radek, sloupec] = 10;
                    hracipole[radek, sloupec] = 10;
                }
            }
            while (i > 0)
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
                for (int radek = 0; radek < hracipole.GetLength(0); radek++)
                {
                    for (int sloupec = 0; sloupec < hracipole.GetLength(1); sloupec++)
                    {

                        if (radek == x && sloupec == y)
                        {
                            hracipole[radek, sloupec] = 11;
                            Console.Write($"| {x + 1};{y + 1} | ");
                            i--;
                        }
                    }
                }

            }
        }
        static void VypisPismena(char[] pismena) // tohle vypiše pismena
        {
            foreach (var item in pismena)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(item + " ");
                Console.ResetColor();
            }
        }
        static void NaplnPismena(char[] pismena) // ty písmena nad hracim polem
        {
            Console.Write("    ");
            for (int i = 0; i < pismena.Length; i++)
            {
                pismena[i] = (char)('A' + i);
            }
        }
        static int PrevestNaChar(string pismenka) // převádí písmena na čisla
        {
            int sloupec = 0;
            switch (pismenka)
            {
                case "A":
                    sloupec = 1;
                    break;
                case "B":
                    sloupec = 2;
                    break;
                case "C":
                    sloupec = 3;
                    break;
                case "D":
                    sloupec = 4;
                    break;
                case "E":
                    sloupec = 5;
                    break;
                case "F":
                    sloupec = 6;
                    break;
                case "G":
                    sloupec = 7;
                    break;
                case "H":
                    sloupec = 8;
                    break;
                case "I":
                    sloupec = 9;
                    break;
                case "J":
                    sloupec = 10;
                    break;
                default:
                    Console.WriteLine("Špatně zadané hodnoty.");
                    //  sloupec = -1;
                    break;
            }
            return sloupec;
        }
        static int Parse() //tryparse metoda
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("špatně zadané hodnoty");
            }
            return num;
        }
    }
}