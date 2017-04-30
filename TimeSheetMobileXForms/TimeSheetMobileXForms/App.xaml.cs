using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TimeSheetMobileXForms
{
    public partial class  App : Application
    {
        public App()
        {
            //InitializeComponent();
            // The root page of your application
            //Mahdollistetaan siirtyminen toiselle sivulle
            //Video 3./4
            MainPage = new NavigationPage(new EmployeePage());
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
