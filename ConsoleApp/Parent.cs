using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Parent
    {
        public Parent()
        {
            Console.WriteLine("Welcome in Parent");

        }

        public Parent(string name)
        {
            Console.WriteLine("Welcome " + name);
        }


    }
}
