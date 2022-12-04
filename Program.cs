while (true)
{
    Console.WriteLine("Введите номер задания: (1-3) | Закончить программу (4)");
    int choise = 0;
    bool exit = false;
    do
    {
        try
        {
            choise = Convert.ToInt32(Console.ReadLine()); //Преобразуем данные из строки в число и проверяем, что ввели число
        }
        catch (Exception)
        {
            Console.WriteLine("Вы ввели не число");
        }

        if (choise > 3 || choise < 1)//Проверяем что ввели правильный диапозон
            Console.WriteLine("Нет такого задания");
    } while (choise > 4 || choise < 1);

    switch (choise) //Просим выбрать какое задание выполнить
    {
        case 1:
            Console.WriteLine("Задание 1");
            Zadanie1();
            break;

        case 2:
            Console.WriteLine("Задание 2");
            Zadanie2();
            break;

        case 3:
            Console.WriteLine("Задание 3");
            Zadanie3();
            break;

        case 4:
            Console.WriteLine("Выход");
            exit = true;
            break;
        default:
            break;
    }

    if (exit)
    {
        break;
    }
}


static void Zadanie1()
{
    Console.WriteLine("Нажмите 1, чтобы заполнить массив ВРУЧНУЮ '0' и '1' или введите любое число, чтобы заполнить массив РАНДОМНО '0' и '1': ");

    int choise = 0;
    int[] arr = new int[8];

    try
    {
        choise = Convert.ToInt32(Console.ReadLine()); //Преобразуем данные из строки в число и проверяем, что ввели число
    }
    catch (Exception)
    {
        Console.WriteLine("Вы ввели не число");
        return;
    }

    if (choise == 1)
    {
        FillArrayManual(arr); //Заполняем массив ручками
    }
    else
    {
        FillArrayRandom(arr); //Заполнение массива Рандомными числами
    }

    Console.Write("8-ми разрядный массив");

    PrintArr(arr);

    FindOnes(arr);
}

static void Zadanie2()
{
    int x = 0;
    int y = 0;
    Console.WriteLine("Введите номер разряда от 0 до 7: ");
    try
    {
        x = Convert.ToInt32(Console.ReadLine());
        if (x < 0 || x > 7)
        {
            Console.WriteLine("Число не входит в допустимый диапазон!");
            return;
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Вы ввели не число");
        return;
    }

    Console.WriteLine("Введите номер разряда от 0 до 7: ");
    try
    {
        y = Convert.ToInt32(Console.ReadLine());
        if (y < 0 || y > 7)
        {
            Console.WriteLine("Число не входит в допустимый диапазон!");
            return;
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Вы ввели не число");
        return;
    }

    Console.WriteLine("Нажмите 1, чтобы заполнить массив ВРУЧНУЮ '0' и '1' или введите любое число, чтобы заполнить массив РАНДОМНО '0' и '1': ");
    int choise = 0;
    int[] arr = new int[8];
    try
    {
        choise = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Вы ввели не число");
        return;
    }

    if (choise == 1)
    {
        FillArrayManual(arr);
    }
    else
    {
        FillArrayRandom(arr);
    }

    Console.Write("8-ми разрядный массив");

    PrintArr(arr);

    Search1Tetrad(arr, x, y);


}

static void Zadanie3()
{
    Console.WriteLine("Введите размер массива:");
    int size = 0;
    try
    {
        size = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception)
    {
        Console.WriteLine("Вы ввели не число");
        return;
    }

    int[] arr = new int[size];

    Random random = new Random();

    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = random.Next(0, 256);
        Console.Write("{0:X}, ", arr[i]);
    }
    Console.WriteLine("\n");

    int P1 = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] == 255)
        {
            P1 = 1;
            break;
        }
    }

    if (P1 == 1)
    {
        Console.WriteLine("P1 = " + P1);
    }
    else
    {
        Console.WriteLine("Ни в одной ячейке не было FFh");
    }
}

static void FillArrayRandom(int[] arr)
{
    Random random = new Random();

    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = random.Next(0, 2);
    }
}

static void FillArrayManual(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.WriteLine("Введите 0 или 1: ");
        int num = 0;
        try
        {
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 0 || num == 1)
            {
                arr[i] = num;
            }
            else
            {
                Console.WriteLine("Число не входит в допустимый диапазон!");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Вы ввели не число");
            return;
        }
    }
}

static void PrintArr(int[] arr)
{
    Console.Write("\n");

    for (int i = arr.Length - 1; i >= 0; i--)
    {
        Console.Write(arr[i]);
    }

    Console.Write("\n");
}

static void FindOnes(int[] arr)
{
    Console.WriteLine("Номера разрядов содержащих 1\n");
    for (int i = arr.Length - 1; i >= 0; i--)
    {
        if (arr[i] == 1)
        {
            Console.Write(i + ", ");
        }
    }
    Console.WriteLine("\n");
}

static void Search1Tetrad(int[] arr, int x, int y)
{
    if (arr[x] == 1)
    {
        Console.WriteLine("В ячейке " + x + " находится 1");
    }
    else
    {
        Console.WriteLine("В ячейке " + x + " находится 0");
    }

    if (arr[y] == 1)
    {
        Console.WriteLine("В ячейке " + y + " находится 1");
    }
    else
    {
        Console.WriteLine("В ячейке " + y + " находится 0");
    }
}
