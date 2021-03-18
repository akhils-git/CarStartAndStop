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
            presentCarState = PresentCarStatus();

            while (1 == 1)
            {
                Console.Clear();
                Console.Write(Messages.UserMessage);
                userCommand = Console.ReadLine().ToUpper();

                if (userCommand == "START")
                {

                    command = true;
                    if (PresentCarStatus() == command)
                    {
                        Console.WriteLine(Messages.AlreadyStartMessage);

                    }
                    else
                    {
                        Console.WriteLine(Messages.StartMessage);
                        MarkStatusToFile(command);
                    }
                }
                else if (userCommand == "STOP")
                {

                    command = false;
                    if (PresentCarStatus() == command)
                    {
                        Console.WriteLine(Messages.AlreadyStopMessage);

                    }
                    else
                    {
                        Console.WriteLine(Messages.StopMessage);
                        MarkStatusToFile(command);
                    }
                }
                else if (userCommand == "EXIT")
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();
            }

        }
        static private void MarkStatusToFile(bool status)
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
        static private bool PresentCarStatus()
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
