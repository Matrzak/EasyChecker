using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using EasyChecker.injector;

namespace EasyChecker.checker
{
    class Checker
    {
        public static void start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("EasyChecker by Matrzak | https://github.com/Matrzak/EasyChecker");
            Console.ResetColor();
            Console.WriteLine(" ");

            Console.WriteLine("Hello there, please input your program name with the extension");
            Console.WriteLine("Make sure your program is in the same dir. Else checker will have a crash ;(");
            String file = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Awesome, now just type how many instances you want to run");
            int instances = 0;
            while(instances <= 0)
            {
                String a = Console.ReadLine();
                instances = int.Parse(a);
            }
            Stack ilist = new Stack();
            Stack commands = new Stack();

            Instance instance = new Instance();
            Console.WriteLine("Cool, Now type commands for instance number: 1");
            int count = 1;
            while(count <= instances)
            {
                String command = Console.ReadLine();
                if (command.Equals("ECskip"))
                {
                    count++;
                    instance.setCommands(commands);
                    ilist.Push(instance);
                    commands.Clear();
                    Console.Clear();
                    if(count > instances){break;}
                    Console.WriteLine("Cool, Now type commands for instance number: "+count);
                    continue;

                }
                commands.Push(command);
                Console.WriteLine("Command "+command+" added for instnace number: "+count);
                Console.WriteLine("If you want skip to the next instance type: ECskip");
            }

            Injector inject = new Injector(file,ilist);
            inject.Iteration();



        }
    }
}
