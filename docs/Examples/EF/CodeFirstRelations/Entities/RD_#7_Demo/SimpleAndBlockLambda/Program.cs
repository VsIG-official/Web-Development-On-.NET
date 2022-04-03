using System;

namespace SimpleAndBlockLambda
{
    delegate int LengthLogin(string s);
    delegate bool BoolPassword(string s1, string s2);
    delegate void Captha(string s1, string s2);

    class Program
    {
        static void Count(Func<int> counter)
        {
            for (int i = 0; i < 10; ++i)
                Console.Write("{0}, ", counter());
        }

        private static void SetLogin()
        {
            Console.Write("Введите логин (<= 25 char): ");
            string login = Console.ReadLine();

            // Используем лямбда-выражение
            LengthLogin lengthLoginDelegate = s => s.Length;

            int lengthLogin = lengthLoginDelegate(login);
            if (lengthLogin > 25)
            {
                Console.WriteLine("Слишком длинное имя\n");

                // Рекурсия на этот же метод, чтобы ввести заново логин
                SetLogin();
            }
        }

        static void Main()
        {
            SetLogin();

            Console.Write("Введите пароль: ");
            string password1 = Console.ReadLine();
            Console.Write("Повторите пароль: ");
            string password2 = Console.ReadLine();

            // Используем лямбда выражение
            BoolPassword bp = (s1, s2) => s1 == s2;

            if (bp(password1, password2))
            {
                Random ran = new Random();
                string resCaptha = "";
                for (int i = 0; i < 10; i++)
                    resCaptha += (char)ran.Next(98, 125);
                Console.WriteLine("Введите текст капчи: " + resCaptha);
                string resCode = Console.ReadLine();

                // Реализуем блочное лямбда-выражение
                Captha cp = (s1, s2) =>
                {
                    if (s1 == s2)
                        Console.WriteLine("Регистрация удалась!");
                    else
                        Console.WriteLine("Регистрация не удачна!");
                    return;
                };
                cp(resCaptha, resCode);
            }
            else
                Console.WriteLine("Регистрация провалилась. Пароли не совпадают");

            // замыкание
            int counter = 0;
            Count(() => counter++);
            Console.WriteLine(counter.ToString()); // ?

            counter = 0;
            Count(() => counter + 1);
            Console.WriteLine(counter.ToString()); // ?

            Console.ReadLine();
        }
    }
}
