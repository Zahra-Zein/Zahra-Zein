using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testConsole.DataAccess;

namespace testConsole.Controller
{
    public class ExportDataController
    {
        public ExportDataController()
        {

        }

        public void ExportData()
        {
            ReadDataManager readDataManager = new ReadDataManager();
            var data = readDataManager.ReadData();
            Console.WriteLine("read data successfully!");

            int recordSize = 500;
            var mapCount = data.Count();
            int fileCounts = (mapCount / recordSize + 1);

            for (int i = 0; i < fileCounts; i++)
            {
                Console.WriteLine("file"+(i+1));
                var fileData = data.Skip(i * recordSize).Take(recordSize).ToList();

                Utilities.FileUtility fileUtility = new Utilities.FileUtility();
                fileUtility.MakeFile(fileData, $"file{i}");
            }


        }
    }
}