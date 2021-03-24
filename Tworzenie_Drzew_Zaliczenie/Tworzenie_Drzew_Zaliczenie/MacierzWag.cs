using System;
using System.Collections.Generic;
using System.Text;

namespace Tworzenie_Drzew_Zaliczenie
{
    class MacierzWag
    {
        public int[,] Macierz { get; set; }
        //zwraca wypełnioną macierz wag
        public void TworzenieMacierzyWag()
        {
            int[,] W = new int[10, 10];
            int L = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = i+1; j < 10; j++)
                {
                    L = L + 1;
                    W[i, j] = L;
                    W[j, i] = L;
                }
            }
            for (int i = 1; i < 10; i++)
            {
                W[i, i] = 0;
            }

            Macierz = W;
        }
        //liczby wagi podając tablice wierzchołków poczatkowych i koncowych
         public void Licz(Drzewo d)
        {
             
            for (int i = 0; i < 9; i++)
            {
                d.SumaWag += Macierz[d.WierzcholkiPoczatkowe[i],d.WierzcholkiKoncowe[i]];
            }
        }

       

    }
}
