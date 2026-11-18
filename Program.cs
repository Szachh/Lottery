using System.Reflection.Metadata.Ecma335;
Console.Write("Ile losowań: ");
int iloscLosowan = int.Parse(Console.ReadLine());
int[,] liczby = new int[iloscLosowan, 6];
int[] losowanie()
{
    Random random = new Random();
    int[] lista = new int[6];
    for (int i = 0; i < 6; i++)
    {
        int los = random.Next(1, 50);
        for (int j = 0; j < 6; j++)
        {
            while (lista[j] == los)
            {
                los = random.Next(1, 50);
            }
        }
        lista[i] = los;
    }
    return lista;
}
int[,] przypisanie(int[,]tablica)
{
    for(int i = 0;i < liczby.GetLength(0); i++)
    {
        int[] wylosowane = losowanie();
        for (int j = 0; j < liczby.GetLength(1); j++)
        {
            tablica[i, j] = wylosowane[j];
        }
    }
    return tablica;
}
int[] zliczanie(int[,] tablicaZliczana)
{
    int[] zliczenie = new int[50];
    for (int q = 1; q <= 49; q++)
    {
        for (int i = 0; i < tablicaZliczana.GetLength(0); i++)
        {
            for (int j = 0; j < tablicaZliczana.GetLength(1); j++)
            {
                if (tablicaZliczana[i, j] == q)
                {
                    zliczenie[q]++;
                }
            }
        }
    }
    return zliczenie;
}
void wyswietlenie()
{
    int[,] tablicaWyswietlana = przypisanie(liczby);
    for (int i = 0; i < tablicaWyswietlana.GetLength(0); i++)
    {
        int[] wylosowane = losowanie();
        Console.Write($"Losowanie {i+1}: ");
        for (int j = 0; j < tablicaWyswietlana.GetLength(1); j++)
        {
            Console.Write($"{tablicaWyswietlana[i, j]} ");
        }
        Console.Write("\n");
    }
    int[] liczbyWystapien = zliczanie(tablicaWyswietlana);
    for (int i = 0; i < liczbyWystapien.Length; i++)
    {
        Console.WriteLine($"Wystąpienie liczby {i}: {liczbyWystapien[i]}");
    }
}
void wyswietlenieZliczenia(int[]zliczenieDoWyswietlenia)
{
    for(int i = 0; i < zliczenieDoWyswietlenia.Length; i++)
    {
        Console.WriteLine($"Wystąpienie liczby {i}: {zliczenieDoWyswietlenia[i]}");
    }
}
wyswietlenie();