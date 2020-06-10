using CollectionViewEx.Sample.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CollectionViewEx.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //writing binding errors to output window
            //https://blog.verslu.is/xamarin/xamarin-forms-xamarin/binding-errors-output-window/
            //todo: maybe create derived implementation in utils that has this on by default
            Xamarin.Forms.Internals.Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine(arg2)));

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
