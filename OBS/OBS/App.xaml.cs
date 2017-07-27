﻿using OBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OBS
{
    public partial class App : Application
    {
        public static Student User { get; set; } = null;
        public App()
        {
            InitializeComponent();

            MainPage = new OBS.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
