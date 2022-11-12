// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.Clear();
int rows = 4;
int columns = 4;

int[,] nums = new int[rows, columns];

int num = 1;
int i = 0;
int j = 0;

while (num <= rows * columns)
{
    nums[i, j] = num;
    if (i <= j + 1 && i + j < rows - 1)
        ++j;
    else if (i < j && i + j >= rows - 1)
        ++i;
    else if (i >= j && i + j > rows - 1)
        --j;
    else
        --i;
    ++num;
}

PrintArray(nums);

//////////////////////// Methods///////////////////////////

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}
