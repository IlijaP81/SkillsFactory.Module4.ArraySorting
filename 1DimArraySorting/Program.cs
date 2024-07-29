using System;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

class MainClass
{
    static int[] arr1Dim = { 5, 6, 9, 1, 2, 3, 4 };
    static int[,] arr2Dim = { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };
    
    public static void Main(string[] args)
    {
        // 1-Dim Array
        arr1Dim = DoArraySorting(arr1Dim);

        // 2-Dim Array
        List<int> arr2DimList = arr2Dim.Cast<int>().ToList();
        int[] interimArray = ConvertMultiDimArrayToOneDimArray(arr2DimList);
        interimArray = DoArraySorting(interimArray);
        ConvertOneDimArrayToTwoDimArray(interimArray);
        
        WritingToConsole();
    }

    /// <summary>
    /// Rewriting of initial 2-Dimensional Array by sorted 1-Dimension Array
    /// </summary>
    /// <param name="interimArray"></param>
    private static void ConvertOneDimArrayToTwoDimArray(int[] interimArray)
    {
        int rank = arr2Dim.Rank, k = 0;

        for (int i = 0; i < rank; i++)
        {
            for (int j = 0; j < interimArray.Length / rank; j++)
            {
                arr2Dim[i, j] = interimArray[k];
                k++;
            }
        }
    }

    /// <summary>
    /// Convert 2-Dimension Array to 1-Dimension Array
    /// </summary>
    private static int[] ConvertMultiDimArrayToOneDimArray(List<int> arr2DimList)
    {
        int size = arr2DimList.Count();
        int[] interimArray = new int[size];
        interimArray = arr2DimList.ToArray();
        return interimArray;
    }

    /// <summary>
    /// Sorting of 1-Dimension Array
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    private static int[] DoArraySorting(int[] arr)
    {
        int max, i = 0, j = arr.Length - 1;
        bool arrayIsSorted = false;

        do
        {
            if (j == 0) arrayIsSorted = true;
            if (i >= 0 & i < arr.Length - 1)
            {
                if (arr[i] > arr[i + 1])
                {
                    max = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = max;
                    arrayIsSorted = false;
                }
                else j--; //  array traversing counter
            }
            else
            {
                i = -1;
                j = arr.Length - 1;
            }
            i++;
        }
        while (!arrayIsSorted);
        return arr;
    }

    private static void WritingToConsole()
    {
        foreach (var item in arr1Dim)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        foreach (var item in arr2Dim)
        {
            Console.Write(item + " ");
        }
    }
}
