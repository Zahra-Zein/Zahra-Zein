using System;
using System.Linq;
using testConsole.Controller;
using testConsole.DataAccess;

namespace testConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Start Program");

                ExportDataController exportDataController = new ExportDataController();
                exportDataController.ExportData();



                Console.WriteLine("Program Finished SuccessFully!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
