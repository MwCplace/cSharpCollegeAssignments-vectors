using System.Numerics;
using static System.Console;

class HelloWorld
{
    static string tryAgainMessage = "Такой опции нет. Попробуйте еще раз";

    static int GetUserInputAsInt(string text) // проверка ввода пользователя
    {
        int num;

        WriteLine(text);
        while (true)
        {
            string str = ReadLine();
            if (int.TryParse(str, out num))
            {
                break;
            }
            else
            {

                WriteLine("Введено не число, попробуйте ещё раз: ");
            }
        }
        return num;
    }

    static float GetVectorProduct(List<float> v1, List<float> v2)
    {
        return v1[0] * v2[1] - v2[0] * v1[1];// возвращено векторное произведение двух 2д векторов;
    }

    static float GetScalarProduct(List<float> v1, List<float> v2)
    {
        return v1[0] * v2[0] + v1[1] * v2[1];// скалярное векторное произведение двух 2д векторов;
    }

    static Vector2 GetNormal(List<float> v)
    {
        Vector2 vector = new Vector2(v[0], v[1]);// создан 2д вектор
        return Vector2.Normalize(vector);// возвращена нормаль 2д вектора
    }

    static float GetVectorLength(List<float> v)
    {
        return Math.Abs(v[0] * v[0] + v[1] * v[1]);//одна сторона вектора в квадрате плюс другая сторона вектора в квадрате и всё это без знака
    }

    static Vector2 GetVectorSum(List<float> v1, List<float> v2)
    {
        Vector2 vector1 = new Vector2(v1[0], v1[1]);// создан 2д вектор
        Vector2 vector2 = new Vector2(v2[0], v2[1]);// создан 2д вектор
        return vector1 + vector2;
    }

    static void start()
    {
        WriteLine("Введите для 1-ого вектора");
        WriteLine("Начало вектора");
        int vectorStart1 = GetUserInputAsInt("Введите число: ");
        WriteLine("Конец вектора");
        int vectorEnd1 = GetUserInputAsInt("Введите число: ");

        WriteLine("Введите для 2-ого вектора");
        WriteLine("Начало вектора");
        int vectorStart2 = GetUserInputAsInt("Введите число: ");
        WriteLine("Начало вектора");
        int vectorEnd2 = GetUserInputAsInt("Введите число: ");

        // добавить элементы в список, способ 1
        List<float> vector1 = new List<float>(2)
        {
            vectorStart1,
            vectorEnd1
        };

        // добавить элементы в список, способ 2
        List<float> vector2 = new List<float>(2);
        vector2.Add(vectorStart2);
        vector2.Add(vectorEnd2);

        WriteLine("Выберите опцию: ");// вывод
        WriteLine("\t0 - завершить программу");// \t - табуляция
        WriteLine("\t1 - векторное произведение");
        WriteLine("\t2 - скалярное произведение");
        WriteLine("\t3 - нормаль к вектору в n мерном пространстве");
        WriteLine("\t4 - длину вектора");
        WriteLine("\t5 - сумму векторов");

        int option = 1;

        while (option > 0)// пока опция не 0
        {
            option = GetUserInputAsInt("Введите число: ");// получить (в виде числа) опцию, которую выбрал пользователь
            switch (option)
            {
                case 0:
                    break;
                case 1:
                    WriteLine($"\tBекторное произведение векторов ({vector1[0]}, {vector1[1]}) и ({vector2[0]}, {vector2[1]}): {GetVectorProduct(vector1, vector2)}");// вывод
                    break;// прервать/завершить case
                case 2:
                    WriteLine($"\tСкалярное произведение векторов ({vector1[0]}, {vector1[1]}) и ({vector2[0]}, {vector2[1]}): {GetScalarProduct(vector1, vector2)}");// вывод
                    break;
                case 3:
                    WriteLine("Выберите опцию: \n\t1 - 1-ый вектор\n\t2 - 2-ой вектор");// вывод
                    int secondOption = 0;
                    while (secondOption < 1 || secondOption > 2)
                    {
                        secondOption = GetUserInputAsInt("Введите число: ");// присвоить данные, возвращаемые функцией, переменной
                        switch (secondOption) //дополнительное заветвление (выбор вектора для операции)
                        {
                            case 1:
                                WriteLine($"\tНормаль к вектору ({vector1[0]}, {vector1[1]}) в n мерном пространстве: {GetNormal(vector1)}");// вывод
                                break;
                            case 2:
                                WriteLine($"\tНормаль к вектору ({vector2[0]}, {vector2[1]}) в n мерном пространстве: {GetNormal(vector2)}");// вывод
                                break;
                            default:
                                WriteLine(tryAgainMessage);// вывод
                                break;
                        }
                    }
                    break;
                case 4:
                    WriteLine("Выберите опцию: \n\t1 - 1-ый вектор\n\t2 - 2-ой вектор");// вывод
                    secondOption = 0;
                    while (secondOption < 1 || secondOption > 2)
                    {
                        secondOption = GetUserInputAsInt("Введите число: ");
                        switch (secondOption) //дополнительное заветвление (выбор вектора для операции)
                        {
                            case 1:
                                WriteLine($"\tДлина вектора ({vector1[0]}, {vector1[1]}): {GetVectorLength(vector1)}");// вывод
                                break;
                            case 2:
                                WriteLine($"\tДлина вектора ({vector2[0]}, {vector2[1]}): {GetVectorLength(vector2)}");// вывод
                                break;
                            default:
                                WriteLine(tryAgainMessage);// вывод
                                break;
                        }
                    }
                    break;
                case 5:
                    WriteLine($"\tСумма векторов ({vector1[0]}, {vector1[1]}) и ({vector2[0]}, {vector2[1]}): {GetVectorSum(vector1, vector2)}");// вывод
                    break;
                default:
                    WriteLine(tryAgainMessage);
                    break;
            }
        }
    }

    static void Main()
    {
        start();
    }
}