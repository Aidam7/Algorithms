using System.Reflection.Metadata.Ecma335;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = CreateBaseArray(30);
            int[] arrayB = CreateBaseArray(30);
            

        }
        static int[] CreateBaseArray(int length)
        {
            int[] array = new int[length];
            Random rnd = new();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(100);
            }
            return array;
        }
        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
            Console.Write($"\n");
        }
        static void PrintArray(int[,] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item}, ");
            }
            Console.Write($"\n");
        }
        static int[] AddToPositionInArray(int[] oldArray, int value, int index)
        {
            if (index > oldArray.Length)
                throw new IndexOutOfRangeException();
            int[] newArray = new int[oldArray.Length + 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = oldArray[i];
            }
            newArray[index] = value;
            for (int i = index; i < oldArray.Length; i++)
            {
                newArray[i + 1] = oldArray[i];
            }
            return newArray;
        }
        static int[] RemoveFromPositionInArray(int[] oldArray, int index)
        {
            int[] newArray = new int[oldArray.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = oldArray[i];
            }
            for (int i = index; i < oldArray.Length; i++)
            {
                newArray[i - 1] = oldArray[i];
            }
            return newArray;
        }
        static int[,] MergeArrays(int[] A, int[] B)
        {
            int longerArrayLength;
            if (A.Length > B.Length)
                longerArrayLength = A.Length;
            else
                longerArrayLength = B.Length;
            int[,] mergedArray = new int[longerArrayLength,2];
            for (int i = 0; i < A.Length; i++)
            {
                mergedArray[i, 0] = A[i];
            }
            for (int i = 0; i < B.Length; i++)
            {
                mergedArray[i, 1] = B[i];
            }
            return mergedArray;
        }
        static (int[] oddArray, int[] evenArray) SplitArray(int[] array)
        {
            int[] oddArray = new int[array.Length/2];
            int[] evenArray = new int[array.Length/2];
            int oddPosition = 0;
            int evenPosition = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0)
                {
                    evenArray[evenPosition] = array[i];
                    evenPosition++;
                }
                else
                {
                    oddArray[oddPosition] = array[i];
                    oddPosition++;
                }
            }
            return (oddArray,evenArray);
        }
    }
}