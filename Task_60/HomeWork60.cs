// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.Clear();
Console.WriteLine("Введите размерность массива по осям X, Y, Z: ");

int xAxis = GetNumberFromUser("Введите X: ", "Ошибка ввода!");
int yAxis = GetNumberFromUser("Введите Y: ", "Ошибка ввода!");
int zAxis = GetNumberFromUser("Введите Z: ", "Ошибка ввода!");
if (xAxis * yAxis * zAxis <= 90)
{
    int[,,] ThreeDMatrix = GetArray(xAxis, yAxis, zAxis, 10, 100);
    Console.WriteLine("Элементы массива: ");
    PrintArray(ThreeDMatrix);
}
else
{
    Console.WriteLine("По введенным данным невозможно сформировать массив, состоящий из неповторяющихся двузначных чисел.");
}

//////////////////////// Methods///////////////////////////

int[,,] GetArray(int x, int y, int z, int minValue, int maxValue)
{
    int number;
    int[] temp = new int[x * y * z];
    for (int c = 0; c < temp.GetLength(0); c++)
    {
        temp[c] = new Random().Next(minValue, maxValue);
        number = temp[c];
        if (c >= 1)
        {
            for (int k = 0; k < c; k++)
            {
                while (temp[c] == temp[k])
                {
                    temp[c] = new Random().Next(minValue, maxValue);
                    k = 0;
                    number = temp[c];
                }
                number = temp[c];
            }
        }
    }

    int index = 0;
    int[,,] result = new int[x, y, z];

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                result[i, j, k] = temp[index];
                index++;
            }
        }
    }
    return result;
}

void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int k = 0; k < inArray.GetLength(2); k++)
            {
                Console.WriteLine($"{inArray[i, j, k]} ({i}, {j}, {k})");
            }
        }
    }
}

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