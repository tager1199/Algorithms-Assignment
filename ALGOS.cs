using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      string Data = DataSelection();
      double[] Unsorted = LoadData(Data);

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

      static double[] BubbleSort(double[] Unsorted)
        {
            double[] Sorted = new double[Unsorted.Length];
            return Sorted;
        }

  }
}
