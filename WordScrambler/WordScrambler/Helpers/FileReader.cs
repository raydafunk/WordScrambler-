using System;
using System.IO;

namespace WordScrambler.Helpers
{
    class FileReader
    {
        public string[] Read(string fileName)
        {
            // initalize the arrary 
            string[] fileContent;
            try
            {
               fileContent = File.ReadAllLines(fileName); 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileContent;
           
        }
    }
}
