using System;

class MainClass
{
    public static void Main(string[] args)
    {
        var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 };
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
                else j--; //  счетчик обходов массива
            }
            else
            {
                i = -1;
                j = arr.Length - 1;
            }
            i++;
        } 
        while (!arrayIsSorted);

        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
    }
}
