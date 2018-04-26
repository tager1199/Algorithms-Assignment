using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{

  static class Assign
  {
    public static int QuickCount = 0;
  }

  class Program
  {
    static void Main(string[] args)
    {
      string Data = DataSelection();
      double[] Unsorted = LoadData(Data);
      double[] Sorted = BubbleSort(Unsorted, Unsorted.Length);
      InsertionSort(Unsorted, Unsorted.Length);
      QuickSort(Unsorted, 0, Unsorted.Length-1);
      Console.WriteLine("The number of steps for the quick sort was {0}",Assign.QuickCount);
      HeapSort(Unsorted, Unsorted.Length);
    }

    static string DataSelection()
    {
      string[] Options = new string[15];
      Options[0] = "Change_128";
      Options[1] = "Change_256";
      Options[2] = "Change_1024";
      Options[3] = "Close_128";
      Options[4] = "Close_256";
      Options[5] = "Close_1024";
      Options[6] = "High_128";
      Options[7] = "High_256";
      Options[8] = "High_1024";
      Options[9] = "Low_128";
      Options[10] = "Low_256";
      Options[11] = "Low_1024";
      Options[12] = "Open_128";
      Options[13] = "Open_256";
      Options[14] = "Open_1024";

      Console.WriteLine("Please select which file you would like to use:");
      int i = 1;
      foreach (string choice in Options)
      {
      	Console.WriteLine(Convert.ToString(i)+". "+choice);
      	i++;
      }

      bool selected = false;
      int Selection = 0;
      while (selected == false)
      {
      	try
      	{
      		Selection = Convert.ToInt32(Console.ReadLine());
      		while ( 1 > Selection || Selection > 15)
      		{
        		Console.WriteLine("Invalid Selection, please try again");
        		Console.WriteLine("Please select a number between 1 and 15");
        		Selection = Convert.ToInt32(Console.ReadLine());
      		}
      		selected = true;
      	}
      	catch
      	{
      		Console.WriteLine("Invalid Selection, please try again");
      		Console.WriteLine("Please select a number between 1 and 15");
      	}
      }
      return Options[Selection -1];
    }

    static double[] LoadData(string Name)
      {
        string[] readText = File.ReadAllLines(@"D:\\Documents\\algos\\Algorithms-Assignment\\"+Name+".txt");
        double[] Numbers = Array.ConvertAll(readText, double.Parse);
        return Numbers;
      }

      static double[] BubbleSort(double[] Unsorted, int Len)
        {
          double temp = 0;
          int Count = 0;
          for (int i = 0; i < Len; i++) {
              for (int j = 0; j < Len - 1; j++) {
                  Count++;
                  if (Unsorted[j] > Unsorted[j + 1]) {
                      Count++;
                      temp = Unsorted[j + 1];
                      Unsorted[j + 1] = Unsorted[j];
                      Unsorted[j] = temp;
                  }
              }
          }
            PrintArray(Unsorted);
            Console.WriteLine("The number of steps for the bubble sort was {0}",Count);
            return Unsorted;
        }

        static void InsertionSort(double[] Unsorted, int Len)
          {
            int Count = 0;
            for (int i = 0; i < Len - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    Count++;
                    if (Unsorted[j - 1] > Unsorted[j])
                    {
                        Count++;
                        double temp = Unsorted[j - 1];
                        Unsorted[j - 1] = Unsorted[j];
                        Unsorted[j] = temp;
                    }
                }
            }
              Console.WriteLine("The number of steps for the insertion sort was {0}",Count);
          }

          static void QuickSort(double[] Unsorted, int left, int right)
            {
              int i = left, j = right;
              double pivot = Unsorted[(left + right) / 2];

              while (i <= j)
              {
                  while (Unsorted[i].CompareTo(pivot) < 0)
                  {
                      i++;
                      Assign.QuickCount++;
                  }

                  while (Unsorted[j].CompareTo(pivot) > 0)
                  {
                      j--;
                      Assign.QuickCount++;
                  }

                  if (i <= j)
                  {
                      // Swap
                      double tmp = Unsorted[i];
                      Unsorted[i] = Unsorted[j];
                      Unsorted[j] = tmp;
                      Assign.QuickCount++;
                      i++;
                      j--;
                  }
              }

              // Recursive calls
              if (left < j)
              {
                  QuickSort(Unsorted, left, j);
              }

              if (i < right)
              {
                  QuickSort(Unsorted, i, right);
              }
          }

            static void HeapSort(double[] Unsorted, int Len)
              {

              }


      static void PrintArray(double[] Array)
        {
          foreach(double i in Array){
            Console.WriteLine(i);
          }
        }
  }
}
