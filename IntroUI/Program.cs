#nullable disable
using System;
using System.Configuration;
using FoodLibrary;
using System.IO;

namespace IntroUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions ApplyFunction = new Functions();
            ApplyFunction.ReadFile();   
            ApplyFunction.MainMenu();          

           
        }
    }
}



