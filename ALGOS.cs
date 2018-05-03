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
      //Get The choice from other method
      string Data = DataSelection();
      //load array via other method
      double[] Unsorted = LoadData(Data);
      //create the array for the sorted array for later
      double[] Sorted = new double[Unsorted.Length];
      //get the values needed from the other methods
      int orient = Orientation();
      int SortChoice = SortSelection();

      //call the correct sorting algorithm based on search
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
        //exit if they chose to
        System.Environment.Exit(1);
      }
      //Print array either accending or deccending based on choice
      if (orient == 1)
      {
        PrintArrayReversed(Sorted);
      }
      else
      {
        PrintArray(Sorted);
      }
      //switch statement to print correct statement
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
      //get search algorithm choice from other method
      int SearchChoice = SearchSelection();
      double value = SearchItem();
      //run everything for linear search
      if (SearchChoice == 0){
        List<int> Locations = LinearSearch.Search(Sorted,value);
        //if the requested value isnt found
        if (LinearSearch.Linearfound == false){
          Console.WriteLine("The number {0} was not found.", value);
          Console.WriteLine("It took {0} steps to confirm the number was not present.",LinearSearch.LinearCount);
          Console.WriteLine("The closest number was:");
          Console.WriteLine("{0} at position {1}",LinearSearch.LinearNearest,Locations[0]);
        }
        //if requested value is found
        else{
          Console.WriteLine("The number {0} was found at these positions:",value);

        //print all locations value was found at
        foreach(int i in Locations){
          Console.Write("{0} ",i);
        }
        Console.WriteLine();
        Console.WriteLine("It took {0} steps to find the number.",LinearSearch.LinearCount);
      }
    }
      //run everything for binary search
      if (SearchChoice == 1){
        List<int> Locations = BinarySearch.Search(Sorted,value);
        //if the requested value isnt found
        if (BinarySearch.Binaryfound == false){
          Console.WriteLine("The number {0} was not found.",value);
          Console.WriteLine("It took {0} steps to confirm the number was not present.",BinarySearch.BinaryCount);
          Console.WriteLine("The closest number was:");
          Console.WriteLine("{0} at position {1}",BinarySearch.BinaryNearest ,Locations[0]);
        }
        //if requested value is found
        else{
          Console.WriteLine("The number {0} was found at these positions:",value);
        //print all locations value was found at
        foreach(int i in Locations){
          Console.Write("{0} ",i);
        }
        Console.WriteLine();
        Console.WriteLine("It took {0} steps to find the number.",BinarySearch.BinaryCount);
      }
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
        //making sure an acceptable input is entered
        try{
          option = Convert.ToInt32(Console.ReadLine());
          //make sure valid number is entered
          while (option > 5 || option < 1)
          {
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine("Please select a number 1-5");
            option = Convert.ToInt32(Console.ReadLine());
          }
          selected = true;
        }
        //error message
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
      //print menu
      Console.WriteLine("Would you like the list in accending or deccending order?");
      Console.WriteLine("1. Accending");
      Console.WriteLine("2. Deccenting");
      Console.WriteLine("3. Quit");
      //make sure valid number is entered
      while (selected==false){
        try{
          option =  Convert.ToInt32(Console.ReadLine());
          //make sure number is a valid one
          while (option > 3 || option < 1)
          {
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine("Please select a number 1-3");
            option = Convert.ToInt32(Console.ReadLine());
          }
          selected = true;
        }
        //printing error message
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
      //print menu
      Console.WriteLine("Which searching algorithm would you like to use?");
      Console.WriteLine("1. Linear Search");
      Console.WriteLine("2. Binary Search");
      Console.WriteLine("3. Quit");
      //make sure valid number is entered
      while (selected==false){
        try{
          option =  Convert.ToInt32(Console.ReadLine());
          //make sure number is a valid one
          while (option > 3 || option < 1)
          {
            Console.WriteLine("Invalid selection, please try again");
            Console.WriteLine("Please select a number 1-3");
            option = Convert.ToInt32(Console.ReadLine());
          }
          selected = true;
        }
        //print error message
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
      //make sure valid value is entered
      while (selected==false){
        try{
          item =  Convert.ToDouble(Console.ReadLine());
          selected = true;
        }
        //print error message
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
      //print all options for menu
      foreach (string choice in Options)
      {
      	Console.WriteLine(Convert.ToString(i)+". "+choice);
      	i++;
      }

      bool selected = false;
      int Selection = 0;
      while (selected == false)
      {
        //error handling, make sure valid input is entered
      	try
      	{
      		Selection = Convert.ToInt32(Console.ReadLine());
          //make sure number is between 1-15
      		while ( 1 > Selection || Selection > 15)
      		{
        		Console.WriteLine("Invalid Selection, please try again");
        		Console.WriteLine("Please select a number between 1 and 15");
        		Selection = Convert.ToInt32(Console.ReadLine());
      		}
      		selected = true;
      	}
        //print error message
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
        //load the data
        string file = "\\"+Name+".txt";
        //use current director
        string dir = Directory.GetCurrentDirectory();
        //read eachline into an array
        string[] readText = File.ReadAllLines(dir+file);
        //convert all strings into doubles
        double[] Numbers = Array.ConvertAll(readText, double.Parse);
        //return the array
        return Numbers;
      }


    static void PrintArray(double[] Array)
      {
        //print all values in Array
        foreach(double i in Array){
          Console.WriteLine(i);
        }
      }

    static void PrintArrayReversed(double[] Array)
      {
        //print all values in Array, backwards
        for(int i = Array.Length-1; i > -1; i--){
          Console.WriteLine(Array[i]);
        }
      }

      static class QuickSort
      {
        public static int QuickCount = 0;
        public static double[] Sort(double[] Unsorted, int left, int right)
          {
            //define the intial variables
            int i = left;
            int j = right;
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
                    //swap values
                    double tmp = Unsorted[i];
                    Unsorted[i] = Unsorted[j];
                    Unsorted[j] = tmp;
                    QuickCount++;
                    i++;
                    j--;
                }
            }

            //recursive calls
            if (left < j)
            {
                QuickSort.Sort(Unsorted, left, j);
            }
            if (i < right)
            {
                QuickSort.Sort(Unsorted, i, right);
            }
          //return sorted array
          return Unsorted;
        }
      }

      static class InsertionSort
      {
        public static int InsertionCount = 0;
        public static double[] Sort(double[] Unsorted, int Len)
          {
            for (int i = 0; i < Unsorted.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    //if the previous number is larger than the current
                    if (Unsorted[j - 1] > Unsorted[j])
                    {
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
            //looping iterations
            for (int i = 0; i < Len; i++) {
                for (int j = 0; j < Len - 1; j++) {
                    BubbleCount++;
                    //if the next number is less than the current
                    if (Unsorted[j] > Unsorted[j + 1]) {
                        //swap numbers
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
              //iterations
              for (int p = (heapSize - 1) / 2; p >= 0; p--)
              {
                //call other method
                MaxHeapify(Unsorted, heapSize, p);
              }
              //iterations
              for (int i = Unsorted.Length - 1; i > 0; i--)
              {
                  //Swap numbers
                  double temp = Unsorted[i];
                  Unsorted[i] = Unsorted[0];
                  Unsorted[0] = temp;
                  //increase count, decrease heapsize
                  HeapCount++;
                  heapSize--;
                  //call other method
                  MaxHeapify(Unsorted, heapSize, 0);
              }
              return Unsorted;
            }

          private static void MaxHeapify(double[] input, int heapSize, int index)
          {
              int left = (index + 1) * 2 - 1;
              int right = (index + 1) * 2;
              int largest = 0;

              if (left < heapSize && input[left] > input[index]){
                  largest = left;
                }
              else{
                  largest = index;
                }

              if (right < heapSize && input[right] > input[largest]){
                largest = right;
              }

              //iterations
              if (largest != index)
              {
                  double temp = input[index];
                  input[index] = input[largest];
                  input[largest] = temp;
                  HeapCount++;
                  //call own method
                  MaxHeapify(input, heapSize, largest);
              }
          }
      }

      static class BinarySearch
      {
        public static bool Binaryfound = false;
        public static int BinaryCount = 0;
        public static double BinaryNearest;
        public static List<int> Search(double[] Array, double value) {
            List<int> locations = new List<int>();
            int min = 0;
            int max = (Array.Length);
            //while a number hasnt been found and all values not searched
            while(max >= min && Binaryfound == false){
              BinaryCount++;
              double mid = ((max+min)/2);
              int guess = Convert.ToInt32(Math.Floor(mid));
              //if value found
              if(Array[guess] == value) {
                locations.Add(guess+1);
                int a = guess+1;
                int b = guess-1;
                //while value found search values above it to check for multiple values
                while(Array[a] == value) {
                  locations.Add(a+1);
                  a++;
                }
                //while value found search values below it to check for multiple values
                while(Array[b] == value) {
                  locations.Add(b+1);
                  b--;
                }
                //set found to true, escape loop
                Binaryfound = true;
              }
              //if guess is greater than value, decrease max
              else if (Array[guess] > value){
                max = guess -1;
              }
              //if guess is less than value, increase max
              else{
                min = guess + 1;
              }
            }
            //if no items found find closest value
            if (locations.Count==0){
                if (min==Array.Length-1){
                  min--;
                }
                if (min==0){
                  min++;
                }
                //search up and down of current value
                int a = min-1;
                int b = min+1;
                double aDiff = Math.Abs(value - Array[a]);
                double iDiff = Math.Abs(value - Array[min]);
                double bDiff = Math.Abs(value - Array[b]);
                //work out which value is closest
                if (aDiff < iDiff && aDiff < bDiff){
                  BinaryNearest = Array[a];
                  locations.Add(a+1);
                }
                else if (iDiff < aDiff && iDiff < bDiff){
                  BinaryNearest = Array[min];
                  locations.Add(min+1);
                }
                else{
                  BinaryNearest = Array[b];
                  locations.Add(b+1);
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
          //search all values in array until go past value
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
          //if not found find closest value
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
