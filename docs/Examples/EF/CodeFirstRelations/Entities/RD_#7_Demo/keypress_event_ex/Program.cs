using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace keypress_event_ex
{
    class Program
    {
        static void Main()
        {
            KeyEvent kevt = new KeyEvent();
            ConsoleKeyInfo key;
            int count = 0;

            // Use a lambda expression to display the keypress.  
            kevt.KeyPress += (source, arg) =>
              Console.WriteLine(" Received keystroke: " + arg.ch);

            // Use a lambda expression to count keypresses. 
            kevt.KeyPress += (source, arg) =>
              count++; // count is an outer variable 

            Console.WriteLine("Enter some characters...('.' - exit)");
            do
            {
                key = Console.ReadKey();
                kevt.OnKeyPress(key.KeyChar);
            } while (key.KeyChar != '.');

            Console.WriteLine(count + " keys pressed.");

        }
    }
}
