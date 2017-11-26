using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace EasyChecker.injector
{
    class Injector
    {
        private String File;
        private int Count;
        private Stack Instances;


        public Injector(String F, Stack I)
        {
            this.File = F;
            this.Instances = I;
            this.Count = I.Count;
        }

        public void Iteration()
        {
            Console.Clear();
            Console.WriteLine("Starting...");
            Console.WriteLine(" ");
            while (Count > 0)
            {
                open();
                Count--;
            }
        }

        private void open()
        {
            foreach(Instance o in Instances)
            {

                var proc = new Process();

                proc.StartInfo.FileName = this.File;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;

                proc.Start();
            
                input(proc, o);
            }
        }

        private void input(Process P,Instance o)
        {
            var inp = P.StandardInput;
            foreach (String commands in o.getCommands())
            {
                inp.WriteLine(commands);
            }
        }

        private void writeOutput(Process P)
        {
            String outp = P.StandardOutput.ReadLine();
            Console.WriteLine("O/S For Instance Number " + Instances + ": " + outp.ToString());
        }



    }
}
