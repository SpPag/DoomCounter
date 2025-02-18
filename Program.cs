using System;
using System.IO;
using DoomCounter.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("~~~~~Terrible no-remote work policy counter~~~~~");
        if (!Directory.Exists("E:\\Coding\\DoomCounter\\Data")) //change path for your computer
        {
            Directory.CreateDirectory("E:\\Coding\\DoomCounter\\Data"); //change path for your computer
        }
        UserInteraction.ConverseWithUser();
        string[] newArray = { };
    }
}