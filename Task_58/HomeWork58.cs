// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


Console.Clear();
int rows1 = GetNumberFromUser("Введите число строк первой матрицы: ", "Ошибка ввода!");
int columns1 = GetNumberFromUser("Введите число столбцов первой матрицы: ", "Ошибка ввода!");

int rows2 = GetNumberFromUser("Введите число строк второй матрицы: ", "Ошибка ввода!");
int columns2 = GetNumberFromUser("Введите число столбцов второй матрицы: ", "Ошибка ввода!");

int[,] array1 = GetArray(rows1, columns1, 0, 10);
int[,] array2 = GetArray(rows2, columns2, 0, 10);

Console.WriteLine("Исходные матрицы:");
Console.WriteLine("Матрица A:");
PrintArray(array1);
Console.WriteLine();
Console.WriteLine("Матрица B:");
PrintArray(array2);
Console.WriteLine();

if (columns1 == rows2)
{
    Console.WriteLine("Результирующая матрица: ");
    PrintArray(GetProduct(rows1, columns2, array1, array2));
}
else Console.Write("Ошибка умножения - Число столбцов первой матрицы не равно числу строк второй матрицы.");

//////////////////////// Methods///////////////////////////

int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect)
            return userNumber;
        Console.WriteLine(errorMessage);
    }
}

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue);
        }
    }
    return result;
}

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

int[,] GetProduct(int rows, int columns, int[,] matrix1, int[,] matrix2)
{ 
    int[,] ProductMatrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)                  
    {
        for (int j = 0; j < columns; j++)        
        { 
            int SumProductElemets = 0; 
            for (int j1 = 0; j1 < columns; j1++)      
            {
                SumProductElemets = SumProductElemets + matrix1[i, j1] * matrix2[j1, j];            
            }
            ProductMatrix[i, j] = SumProductElemets;
        }
    }
    return ProductMatrix;
}