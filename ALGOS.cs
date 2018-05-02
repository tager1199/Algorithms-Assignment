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
      double[] Sorted = new double[Unsorted.Length];
      int orient = Orientation();
      int SortChoice = SortSelection();
      int SearchChoice = SearchSelection();
      double value = SearchItem();

      if (SortChoice == 0){
        Sorted = BubbleSort.Sort(Unsorted, Unsorted.Length);
      }
      else if (SortChoice == 1){
        Sorted = InsertionSort.Sort(Unsorted, Unsorted.Length);
      }
      else if (SortChoice == 2){
        Sorted = QuickSort.Sort(Unsorted, 0, Unsorted.Length-1);
      }
      else if (SortChoice == 3){
        Sorted = HeapSort.Sort(Unsorted, Unsorted.Length);
      }
      else{
        System.Environment.Exit(1);
      }

      if (orient == 1)
      {
        PrintArrayReversed(Sorted);
      }
      else
      {
        PrintArray(Sorted);
      }


      if (SearchChoice == 0){
        Locations = LinearSearch.Search(Sorted);
      }
      if (SearchChoice == 1){
        Locations = BinarySearch.Search(Sorted);
      }
      if (SearchChoice == 2){
        System.Environment.Exit(1);
      }

    }

    static int SortSelection()
    {
      int option = 0;
      bool selected = false;
      Console.WriteLine("Which sorting algorithm would you like to use?");
      Console.WriteLine("1. Bubble Sort");
      Console.WriteLine("2. Insertion Sort");
      Console.WriteLine("3. Quick Sort");
      Console.WriteLine("4. Heap Sort");
      Console.WriteLine("5. Quit");
      while (selected==false){
        try{
          option = Convert.ToInt32(Console.ReadLine());

          while (option > 5 || option < 1)
          {
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine("Please select a number 1-5");
            option = Convert.ToInt32(Console.ReadLine());
          }
          selected = true;
        }
        catch{
          Console.WriteLine("Invalid selection, please try again");
          Console.WriteLine("Please select a number 1-5");
        }

      }
      return option-1;
    }

    static int Orientation()
    {
      int option = 0;
      bool selected = false;
      Console.WriteLine("Would you like the list in accending or deccending order?");
      Console.WriteLine("1. Accending");
      Console.WriteLine("2. Deccenting");
      Console.WriteLine("3. Quit");
      while (selected==false){
        try{
          option =  Convert.ToInt32(Console.ReadLine());

          while (option > 3 || option < 1)
          {
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine("Please select a number 1-3");
            option = Convert.ToInt32(Console.ReadLine());
          }
          selected = true;
        }
        catch{
          Console.WriteLine("Invalid selection, please try again");
          Console.WriteLine("Please select a number 1-3");
        }

      }
      return option-1;
    }

    static int SearchSelection()
    {
      int option = 0;
      bool selected = false;
      Console.WriteLine("Which sorting algorithm would you like to use?");
      Console.WriteLine("1. Linear Search");
      Console.WriteLine("2. Binary Search");
      Console.WriteLine("3. Quit");
      while (selected==false){
        try{
          option =  Convert.ToInt32(Console.ReadLine());

          while (option > 3 || option < 1)
          {
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine("Please select a number 1-3");
            option = Convert.ToInt32(Console.ReadLine());
          }
          selected = true;
        }
        catch{
          Console.WriteLine("Invalid selection, please try again");
          Console.WriteLine("Please select a number 1-3");
        }
      }
      return option-1;
    }

    static double SearchItem()
    {
      double item;
      bool selected = false;
      Console.WriteLine("What item would you like to search for?");
      while (selected==false){
        try{
          item =  Convert.ToInt32(Console.ReadLine());
          selected = true;
        }
        catch{
          Console.WriteLine("Invalid selection, please try again");
        }
      }
      return item;
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
        string file = "\\"+Name+".txt";
        string dir = Directory.GetCurrentDirectory();
        string[] readText = File.ReadAllLines(dir+file);
        double[] Numbers = Array.ConvertAll(readText, double.Parse);
        return Numbers;
      }


    static void PrintArray(double[] Array)
      {
        foreach(double i in Array){
          Console.WriteLine(i);
        }
      }

    static void PrintArrayReversed(double[] Array)
      {
        for(int i = Array.Length-1; i > -1; i--){
          Console.WriteLine(Array[i]);
        }
      }

      static class QuickSort
      {
        public static int Count = 0;
        public static double[] Sort(double[] Unsorted, int left, int right)
          {
            int i = left, j = right;
            double pivot = Unsorted[(left + right) / 2];

            while (i <= j)
            {
                while (Unsorted[i].CompareTo(pivot) < 0)
                {
                    i++;
                    Count++;
                }

                while (Unsorted[j].CompareTo(pivot) > 0)
                {
                    j--;
                    Count++;
                }

                if (i <= j)
                {
                    // Swap
                    double tmp = Unsorted[i];
                    Unsorted[i] = Unsorted[j];
                    Unsorted[j] = tmp;
                    Count++;
                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort.Sort(Unsorted, left, j);
            }
            if (i < right)
            {
                QuickSort.Sort(Unsorted, i, right);
            }
          return Unsorted;
        }
      }

      static class InsertionSort
      {
        public static int Count = 0;
        public static double[] Sort(double[] Unsorted, int Len)
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
              return Unsorted;
          }
      }

      static class BubbleSort
      {
        public static int Count = 0;
        public static double[] Sort(double[] Unsorted, int Len)
          {
            double temp = 0;
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
              Console.WriteLine("The number of steps for the bubble sort was {0}",Count);
              return Unsorted;
          }
      }

      static class HeapSort
      {
          public static int Count = 0;
          public static double[] Sort(double[] Unsorted, int heapSize)
            {
              for (int p = (heapSize - 1) / 2; p >= 0; p--)
              {
                MaxHeapify(Unsorted, heapSize, p);
              }

              for (int i = Unsorted.Length - 1; i > 0; i--)
              {
                  //Swap
                  double temp = Unsorted[i];
                  Unsorted[i] = Unsorted[0];
                  Unsorted[0] = temp;
                  Count++;
                  heapSize--;
                  MaxHeapify(Unsorted, heapSize, 0);
              }
              return Unsorted;
            }

          private static void MaxHeapify(double[] input, int heapSize, int index)
          {
              int left = (index + 1) * 2 - 1;
              int right = (index + 1) * 2;
              int largest = 0;

              if (left < heapSize && input[left] > input[index])
                  largest = left;
              else
                  largest = index;

              if (right < heapSize && input[right] > input[largest])
                  largest = right;

              if (largest != index)
              {
                  double temp = input[index];
                  input[index] = input[largest];
                  input[largest] = temp;
                  Count++;
                  MaxHeapify(input, heapSize, largest);
              }
          }
      }

      static class BinarySearch
      {
        public static bool found = false;
        public static int Count = 0;
        Search(Array, value) {
            list<int> loactions = new list<int>();
            low = Array[0];
            high = Array[(Array.Length-1)];
            while (low <= high) {
                mid = (low + high) / 2;
                if (A[mid] > value)
                {
                    high = mid - 1;
                }
                else if (A[mid] < value)
                {
                  low = mid + 1;
                }

                else
                {
                  return Convert.ToString(mid);
                }
            }
            return locations;
        }
      }

      static class LinearSearch
      {
        public static bool found = false;
        public static int Count = 0;
        Search(double[] Array, double value)
        {
          int i = 0;
          list<int> loactions = new list<int>();
          while (Array[i] <= value){
            if (Array[i] == value){
              locations.Add(i);
              found = true;
            }
            i++;
          }
          return locations;
        }
      }

  }
}
