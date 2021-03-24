using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Tworzenie_Drzew_Zaliczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            //generowanie macierzy wag
            var tab = new MacierzWag();
            tab.TworzenieMacierzyWag();
            //LOSOWOSC
            var rand = new Random();

            
            //tablice wierzchołków 
            ArrayList T = new ArrayList();
            ArrayList R = new ArrayList ();
            //tablica drzew
            var tabDrzew = new Drzewo[100];
            //wierzchołek poczatkowy,dlugosc r,dlugosc t ,vierzcholek koncowy,wartosc poczatkowa,wartosc koncowa
            int vp , NR,NT,vk,wartoscP,wartoscK;
            //start petli 100!!!!!!!!!!!!!!!!!!!
            for (int i = 0; i < 100; i++)
            {


                tabDrzew[i] = new Drzewo { SumaWag = 0, WierzcholkiPoczatkowe = new int[9], WierzcholkiKoncowe = new int[9] };//zamien na i
                                                                                                                              
                R.Clear();
                T.Clear();
                //wypelnianie R
                for (int k = 0; k < 10; k++)
                {
                    R.Add(k);
                }

                //liczność poczatkowa
                NR = 10; NT = 0;

                //losujemy 1 wierzchołek
                vp = rand.Next(NR);
                wartoscP = (int)R[vp];
                R.RemoveAt(vp);                
                T.Add(wartoscP);
                NR--;
                NT++;
                tabDrzew[i].WierzcholkiPoczatkowe[0] = wartoscP;
                //losuje 2 wierzchołek
                vk = rand.Next(NR);
                wartoscK = (int)R[vk];
                R.RemoveAt(vk);
                T.Add(wartoscK);
                NR--;
                NT++;
                tabDrzew[i].WierzcholkiKoncowe[0] = wartoscK;

                //7 krawedzi
                for (int j = 1; j < 8; j++)
                {
                    vp = rand.Next(NT);
                    wartoscP = (int)T[vp];
                    vk = rand.Next(NR);
                    wartoscK = (int)R[vk];
                    R.RemoveAt(vk);
                    T.Add(wartoscP);
                    NR--;
                    NT++;
                    tabDrzew[i].WierzcholkiPoczatkowe[j] = wartoscP;
                    tabDrzew[i].WierzcholkiKoncowe[j] = wartoscK;
                }

                //ostatni krawedz
                vp = rand.Next(NT);
                wartoscP = (int)T[vp];
                wartoscK = (int)R[0];
                tabDrzew[i].WierzcholkiPoczatkowe[8] = wartoscP;
                tabDrzew[i].WierzcholkiKoncowe[8] = wartoscK;
                //koniec petli
            }
            //liczenie wag
            for (int x = 0; x < 100; x++)
            {
                tab.Licz(tabDrzew[x]);
            }
            //sortowanie po sumie wag
            var collection = tabDrzew.OrderBy(x => x.SumaWag).ToArray();

            //wypisanie kolekcji posortowanych drzew w konsoli
            //for (int x = 0; x < 100; x++)
            //{
            //    for (int i = 0; i < 9; i++)
            //    {
            //        Console.Write(collection[x].WierzcholkiPoczatkowe[i] + "->" + collection[x].WierzcholkiKoncowe[i]+'|');
            //    }
            //    Console.WriteLine(collection[x].SumaWag);
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            //zapis drzew w pliku txt
            var fullPath = @"C:\Users\48502\Documents\drzewa.txt";
            // Write file using StreamWriter  
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                for (int x = 0; x < 100; x++)
                {

                    writer.Write("D"+(x+1)+"|");
                    for (int i = 0; i < 9; i++)
                    {
                        writer.Write(collection[x].WierzcholkiPoczatkowe[i] + "->" + collection[x].WierzcholkiKoncowe[i] + '|');
                    }
                    writer.WriteLine(collection[x].SumaWag);
                }

            }
            // Read a file  
            string readText = File.ReadAllText(fullPath);
            Console.WriteLine(readText);


            //czytanie drzew nieposortowanych
            //for (int x = 0; x < 100; x++)
            //{
            //    for (int i = 0; i < 9; i++)
            //    {
            //        Console.WriteLine(tabDrzew[x].WierzcholkiPoczatkowe[i] + " " + tabDrzew[x].WierzcholkiKoncowe[i]);
            //    }
            //    tab.Licz(tabDrzew[x]);
            //    Console.WriteLine(tabDrzew[x].SumaWag);
            //}











        }
    }
}
