using System;
using System.Collections.Generic;
using System.IO;

namespace Notepad
{
    class Program
    {
        static void Main(string[] args)
        {
            Display display = new Display();
            display.displayMainMenu(); 
        }
    }

    class MakeFile
    {
        Display display = new Display();
        public void createFile(string filePath, string fileName)
        {
            string fullPathName = filePath + fileName + ".txt";
            Console.WriteLine(fullPathName);
            try
            {
                //create the directory if it it not exit
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                // Delete the file if it exists.
                if (File.Exists(fullPathName))
                {
                    Console.WriteLine("File is alrady exists please change name \n");
                    Console.Write("Enter file name : ");
                    fileName = Console.ReadLine();
                    fullPathName = filePath + fileName + ".txt";
                }

                Console.WriteLine("Write the file content");
                List<string> input = new List<string>();
                while (true)
                {
                    string userInput = Console.ReadLine();
                    input.Add(userInput);
                    if (userInput == "x")
                    {
                        input.Remove(userInput);
                        break;
                    }
                }
                File.WriteAllLines(fullPathName, input);
                Console.WriteLine("File Write Successfully.");
                display.displayMainMenu();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }


    class OpenFile
    {
        public void openExistingFile(string filePath,string filename)
        {
            Display display = new Display();
            string filePathName = filePath + filename;
            Console.WriteLine(filePathName);
            String line;
            try
            {
                if (File.Exists(filePathName))
                {
                    Console.WriteLine("File Contents\n");
                    StreamReader sr = new StreamReader(filePath + @"\" + filename);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                    Console.WriteLine("\n\n\n");
                    display.displayMainMenu();
                }
                else
                {
                    Console.WriteLine("404 File Not Found !\nExiting to main menu");        
                    display.displayMainMenu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void openExistingFileEdit(string filePath, string fileName)
        {
            string fullPathName = filePath + @"\"+fileName;
            Console.WriteLine("Write the file content");
            List<string> input = new List<string>();
            while (true)
            {
                string userInput = Console.ReadLine();
                input.Add(userInput);
                if (userInput == "x")
                {
                    input.Remove(userInput);
                    break;
                }
            }
            File.AppendAllLines(fullPathName, input);
            Console.WriteLine("File Write Successfully.");
        }
    }
        
    class Display
    {
        MakeFile makeFile = new MakeFile();
        public void displayMainMenu()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("***           Welcome to Notepad          ****");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("****       1. Create new text file        ****");
            Console.WriteLine("****       2. Open text file              ****");
            Console.WriteLine("****       3. Help(Make sure you read once)***");
            Console.WriteLine("****       4. Exit                        ****");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            while (true)
            {
                int selector = Int32.Parse(Console.ReadLine());
                switch (selector)
                {
                    case 1:
                        Console.Clear();
                        displayFileMenu();
                        break;

                    case 2:
                        Console.Clear();
                        displayOpenFileMenu();
                        break;

                    case 3:
                        displayHelp();
                        displayMainMenu();
                        break;
                        
                    case 4:
                        Console.WriteLine("Exiting....");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong option.");
                        break;
                }
            }
        }

        void displayOpenFileMenu()
        {
            int status;
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("***              Open a File              ****");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("****       1. Open Existing File          ****");
            Console.WriteLine("****       2. Edit Existing File          ****");
            Console.WriteLine("****       3. Find and Replace            ****");
            Console.WriteLine("****       4. Exit to main menu           ****");
            Console.WriteLine("****       5. Help                        ****");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            while (true)
            {
                int selector = Int32.Parse(Console.ReadLine());
                switch (selector)
                {
                    case 1:
                        Console.Clear();
                        status = 400;
                        checkFile(status);
                        break;

                    case 2:
                        Console.Clear();
                        status = 401;
                        checkFile(status);
                        break;

                    case 3:
                        //findAndReplace();
                        Console.WriteLine("ok");
                        break;

                    case 4:
                        Console.Clear();    
                        displayMainMenu();
                        break;

                    case 5:
                        displayHelp();
                        displayOpenFileMenu();
                        break;

                    default:
                        Console.WriteLine("Wrong option.");
                        break;
                }
            }
        }

        void checkFile(int status)
        {
            if (status==400)
            {
                int chk;
                string filepath;
                OpenFile op = new OpenFile();
                Console.WriteLine("1. C:\\TextFiles");
                Console.WriteLine("2. C:\\YourName");

                chk = Convert.ToInt32(Console.ReadLine());


                if (chk == 1)
                {
                    filepath = @"C:\TextFiles\";
                    string[] files = Directory.GetFiles(filepath);
                    Console.WriteLine("\n\nThese are the following files available to open.");
                    foreach (string file in files)
                        Console.WriteLine(Path.GetFileName(file));
                    Console.Write("Enter file name : ");
                    string fileName = Console.ReadLine();

                    op.openExistingFile(filepath, fileName + ".txt");
                }
                else if (chk == 2)
                {
                    Console.Write("Enter Folder Name : ");
                    string folderName = Console.ReadLine();
                    filepath = @"C:\" + folderName + @"\";
                    string[] files = Directory.GetFiles(filepath);
                    foreach (string file in files)
                        Console.WriteLine(Path.GetFileName(file));
                    Console.Write("Enter file name : ");
                    string fileName = Console.ReadLine();
                    op.openExistingFile(filepath, fileName + ".txt");
                }
                else
                {
                    Console.WriteLine("Wrong option.");
                    displayOpenFileMenu();
                }
                }else if(status==401)
                {
                int chk;
                string filepath;
                OpenFile op = new OpenFile();
                Console.WriteLine("1. C:\\TextFiles");
                Console.WriteLine("2. C:\\YourName");

                chk = Convert.ToInt32(Console.ReadLine());


                if (chk == 1)
                {
                    filepath = @"C:\TextFiles";
                    string[] files = Directory.GetFiles(filepath);
                    Console.WriteLine("\n\nThese are the following files available to open.");
                    foreach (string file in files)
                        Console.WriteLine(Path.GetFileName(file));
                    Console.Write("Enter file name : ");
                    string fileName = Console.ReadLine();

                    op.openExistingFileEdit(filepath, fileName + ".txt");
                }
                else if (chk == 2)
                {
                    Console.Write("Enter Folder Name : ");
                    string folderName = Console.ReadLine();
                    filepath = @"C:\" + folderName + @"\";
                    string[] files = Directory.GetFiles(filepath);
                    foreach (string file in files)
                        Console.WriteLine(Path.GetFileName(file));
                    Console.Write("Enter file name : ");
                    string fileName = Console.ReadLine();
                    op.openExistingFileEdit(filepath, fileName + ".txt");
                }
                else
                {
                    Console.WriteLine("Wrong option.");
                    displayOpenFileMenu();
                }
            } 
            
        }

        void displayHelp()
        {
            Console.Clear();
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("***                 Help                  ****");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" For saving the file write x and then press\n enter key");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public void displayFileMenu()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("***         Create New Text File          ****");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("****        Choose the Path               ****");
            Console.WriteLine("****        1. C:\\TextFiles               ****");
            Console.WriteLine("****        2. C:\\YourName                ****");
            Console.WriteLine("****        3. Back to main menu          ****");
            Console.WriteLine("****        4. Help                       ****");
            Console.WriteLine("----------------------------------------------");
            Console.Write("Choose Option : ");
            string filePath = @"C:\TextFiles\";
            while (true)
            {
                int option = Int32.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //Console.Clear();
                        Console.Write("Enter File Name : ");
                        string fileName = Console.ReadLine();
                        makeFile.createFile(filePath, fileName);
                        break;

                    case 2:
                       // Console.Clear();
                        Console.Write("Enter your folder name : ");
                        string filePath1 = @"C:\" + Console.ReadLine() + @"\";
                        Console.Write("Enter file name : ");
                        string fileName1 = Console.ReadLine();
                        makeFile.createFile(filePath1, fileName1);
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        displayMainMenu();
                        break;

                    case 4:
                        Console.Clear();
                        displayHelp();
                        displayFileMenu();
                        break;

                    default:
                        Console.WriteLine("Wrong option");
                        break;
                }
            }
        }
    }
}