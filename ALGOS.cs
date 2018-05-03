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
      switch (SortChoice)
        {
          case 0:
              Console.WriteLine("The number of steps for the bubble sort was {0}",BubbleSort.BubbleCount);
              break;
          case 1:
              Console.WriteLine("The number of steps for the insertion sort was {0}",InsertionSort.InsertionCount);
              break;
          case 2:
              Console.WriteLine("The number of steps for the quick sort was {0}",QuickSort.QuickCount);
              break;
          case 3:
              Console.WriteLine("The number of steps for the heap sort was {0}",HeapSort.HeapCount);
              break;
        }

      int SearchChoice = SearchSelection();
      double value = SearchItem();
      if (SearchChoice == 0){
        Console.WriteLine("Linear");
        List<int> Locations = LinearSearch.Search(Sorted,value);
        if (LinearSearch.Linearfound == false){
          Console.WriteLine("The number {0} was not found.", value);
          Console.WriteLine("It took {0} steps to confirm the number was not present.",LinearSearch.LinearCount);
          Console.WriteLine("The closest number was:");
          Console.WriteLine("{0} at position {1}",LinearSearch.LinearNearest,Locations[0]);
        }
        else{
          Console.WriteLine("The number {0} was found at these positions:",value);
        }
        foreach(int i in Locations){
          Console.Write("{0} ",i);
        }
        Console.WriteLine();
        Console.WriteLine("It took {0} steps to find the number.",LinearSearch.LinearCount);
      }

      if (SearchChoice == 1){
        Console.WriteLine("Binary");
        List<int> Locations = BinarySearch.Search(Sorted,value);
        if (BinarySearch.Binaryfound == false){
          Console.WriteLine("The number {0} was not found.",value);
          Console.WriteLine("It took {0} steps to confirm the number was not present.",BinarySearch.BinaryCount);
          Console.WriteLine("The closest number was:");
          //Console.WriteLine("{0} at position {1}",BinarySearch.BinaryNearest ,Locations[0]);
        }
        else{
          Console.WriteLine("The number {0} was found at these positions:",value);
        }
        foreach(int i in Locations){
          Console.Write("{0} ",i);
        }
        Console.WriteLine();
        Console.WriteLine("It took {0} steps to find the number.",BinarySearch.BinaryCount);
      }
      else{
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
      Console.WriteLine("Which searching algorithm would you like to use?");
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
      double item=0;
      bool selected = false;
      Console.WriteLine("What item would you like to search for?");
      while (selected==false){
        try{
          item =  Convert.ToDouble(Console.ReadLine());
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
        public static int QuickCount = 0;
        public static double[] Sort(double[] Unsorted, int left, int right)
          {
            int i = left, j = right;
            double pivot = Unsorted[(left + right) / 2];

            while (i <= j)
            {
                while (Unsorted[i].CompareTo(pivot) < 0)
                {
                    i++;
                    QuickCount++;
                }

                while (Unsorted[j].CompareTo(pivot) > 0)
                {
                    j--;
                    QuickCount++;
                }

                if (i <= j)
                {
                    // Swap
                    double tmp = Unsorted[i];
                    Unsorted[i] = Unsorted[j];
                    Unsorted[j] = tmp;
                    QuickCount++;
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
        public static int InsertionCount = 0;
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
              return Unsorted;
          }
      }

      static class BubbleSort
      {
        public static int BubbleCount = 0;
        public static double[] Sort(double[] Unsorted, int Len)
          {
            double temp = 0;
            for (int i = 0; i < Len; i++) {
                for (int j = 0; j < Len - 1; j++) {
                    BubbleCount++;
                    if (Unsorted[j] > Unsorted[j + 1]) {
                        BubbleCount++;
                        temp = Unsorted[j + 1];
                        Unsorted[j + 1] = Unsorted[j];
                        Unsorted[j] = temp;
                    }
                }
            }
              return Unsorted;
          }
      }

      static class HeapSort
      {
          public static int HeapCount = 0;
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
                  HeapCount++;
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
                  HeapCount++;
                  MaxHeapify(input, heapSize, largest);
              }
          }
      }

      static class BinarySearch
      {
        public static bool Binaryfound = false;
        public static int BinaryCount = 0;
        public static List<int> Search(double[] Array, double value) {
            List<int> locations = new List<int>();
            int min = 0;
            int max = (Array.Length);
            while(max > min && Binaryfound == false){
              BinaryCount++;
              double mid = ((max+min)/2);
              int guess = Convert.ToInt32(Math.Floor(mid));
              if(Array[guess] == value) {
                locations.Add(guess+1);
                int a = guess+1;
                int b = guess-1;
                while(Array[a] == value) {
                  locations.Add(a+1);
                  a++;
                }
                while(Array[b] == value) {
                  locations.Add(b+1);
                  b--;
                }
                Binaryfound = true;
              }
              else if (Array[guess] > value){
                max = guess -1;
              }
              else{
                min = guess + 1;
              }
            }
            return locations;
          }
        }

      static class LinearSearch
      {
        public static bool Linearfound = false;
        public static int LinearCount = 0;
        public static double LinearNearest;
        public static List<int> Search(double[] Array, double value)
        {
          int i = 0;
          List<int> locations = new List<int>();
          while (i < Array.Length && Array[i] <= value){
            if (Array[i] == value){
              locations.Add(i+1);
              Linearfound = true;
            }
            i++;
            if(Linearfound==false){
              LinearCount++;
            }
          }
          LinearCount++;

          if (locations.Count==0){
              if (i==Array.Length-1){
                i--;
              }
              if (i==0){
                i++;
              }
              int a = i-1;
              int b = i+1;
              double aDiff = Math.Abs(value - Array[a]);
              double iDiff = Math.Abs(value - Array[i]);
              double bDiff = Math.Abs(value - Array[b]);
              if (aDiff < iDiff && aDiff < bDiff){
                LinearNearest = Array[a];
                locations.Add(a+1);
              }
              else if (iDiff < aDiff && iDiff < bDiff){
                LinearNearest = Array[i];
                locations.Add(i+1);
              }
              else{
                LinearNearest = Array[b];
                locations.Add(b+1);
              }

          }
          return locations;
        }
      }

  }
}
