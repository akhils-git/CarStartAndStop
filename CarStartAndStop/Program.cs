﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStartAndStop
{
    class Program
    {

        static bool presentCarState;
        static string statusStorageFilePath = @"c:/status.txt";
        static bool command;
        static void Main(string[] args)
        {
            string userCommand = string.Empty;
            presentCarState = PresentStatus();

            while (1 == 1)
            {
                Console.Clear();
                Console.Write("Enter Command: ");
                userCommand = Console.ReadLine().ToUpper();
                if (userCommand == "START")
                {

                    command = true;
                    if (PresentStatus() == command)
                    {
                        Console.WriteLine("Its allready started !");

                    }
                    else
                    {
                        Console.WriteLine("Started");
                        MarkStatus(command);
                    }
                }
                else if (userCommand == "STOP")
                {

                    command = false;
                    if (PresentStatus() == command)
                    {
                        Console.WriteLine("Its allready Stopped !");

                    }
                    else
                    {
                        Console.WriteLine("Stoped");
                        MarkStatus(command);
                    }
                }
                else if (userCommand == "EXIT")
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();
            }

        }
        static private void MarkStatus(bool status)
        {
            if (!File.Exists(statusStorageFilePath) && status == true)
            {
                File.WriteAllText(statusStorageFilePath, "Started");
            }
            else
            {
                File.WriteAllText(statusStorageFilePath, "Stopped");
            }
        }
        static private bool PresentStatus()
        {
            if (File.Exists(statusStorageFilePath))
            {
                if (File.ReadAllText(statusStorageFilePath) == "Started")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
