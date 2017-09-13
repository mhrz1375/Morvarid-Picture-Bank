using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Morvarid.CLS;

namespace Morvarid.CLS
{/*string DataSource = "";
            // return "Data Source=" + SrvName + "; initial catalog=" + DbName + "; user id=" + UsrName + "; password=" + Pasword + ";";//Build Connection String and Return
            try
            {
                DataSource = "Data Source=EVOLATION;Initial Catalog=MorvaridDB;Integrated Security=True";
            }
            catch
            {
                DataSource = @"Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Application.StartupPath + "\\MorvaridDB.mdf;Integrated Security=True;Connect Timeout=30;";
            }

            return DataSource;*/
    public class TestDataBaseConnection
    {
        string FileName = Application.StartupPath + "\\ConnctionFile.txt";
        string PhotoShopPath = Application.StartupPath + "\\PhotoshopPathFile.txt";
        string TempOfImages = Application.StartupPath + "\\TempOfImagesPathFile.txt";
        public string ReadTempOfImagesPathFromFile()
        {
            string text = System.IO.File.ReadAllText(TempOfImages);
            return text;
        }
        public void SetTempOfImagesPath(string TempOfImagesPath)
        {
            File.WriteAllText(TempOfImages, TempOfImagesPath);

        }
        public string ReadPhotoshopPathFromFile()
        {
            string text = System.IO.File.ReadAllText(PhotoShopPath);
            return text;
        }
        public void SetPhotoshopPath(string PhotoshopPath)
        {
            File.WriteAllText(PhotoShopPath, PhotoshopPath);
          
        }
        public string ReadDataBasePathFromFile()
        {
            string text = System.IO.File.ReadAllText(FileName);
            return text;
        }

     

        public void SetDataBasePath(string DataBasePath)
        {

            // These examples assume a "C:\Users\Public\TestFolder" folder on your machine.
            // You can modify the path if necessary. 

            // Example #1: Write an array of strings to a file. 
            // Create a string array that consists of three lines. 
            string[] lines = { "First line", "Second line", "Third line" };
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            System.IO.File.WriteAllLines(FileName, lines);


            // Example #2: Write one string to a text file. 
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            // WriteAllText creates a file, writes the specified string to the file, 
            // and then closes the file.
            //File.WriteAllText(FileName, @"Data Source=(LocalDB)\\v11.0;AttachDbFilename=|" +  DataBasePath + ";Integrated Security=True;Connect Timeout=30;");

          //  File.WriteAllText(FileName, @"Server=.\SQLExpress;AttachDbFilename=E:\MorvaridDB.mdf;Database=MorvaridDB;Trusted_Connection=Yes;");

            
        // Example #3: Write only some strings in an array to a file. 
        // The using statement automatically closes the stream and calls  
        // IDisposable.Dispose on the stream object. 
        /* using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName))
         {
             foreach (string line in lines)
             {
                 // If the line doesn't contain the word 'Second', write the line to the file. 
                 if (!line.Contains("Second"))
                 {
                     file.WriteLine(line);
                 }
             }
         }*/

        // Example #4: Append new text to an existing file. 
        // The using statement automatically closes the stream and calls  
        // IDisposable.Dispose on the stream object. 
        /*  using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, true))
          {
              file.WriteLine("Fourth line");
          }*/
    }
    }
    //Output (to WriteLines.txt): 
    //   First line 
    //   Second line 
    //   Third line 

    //Output (to WriteText.txt): 
    //   A class is the most powerful data type in C#. Like a structure, a class defines the data and behavior of the data type. 

    //Output to WriteLines2.txt after Example #3: 
    //   First line 
    //   Third line 

    //Output to WriteLines2.txt after Example #4: 
    //   First line 
    //   Third line 
    //   Fourth line


}

