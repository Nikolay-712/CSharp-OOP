﻿using System;

namespace _02.CreateAttribute
{
    [Author("Ventsi")]
    class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }


    }
}