using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewEx.Sample.ViewModels
{
    public class IocManager
    {
        private static IocManager _instance;

        public static IocManager Current => _instance ?? (_instance = new IocManager());

        public IocManager()
        {
           
        }

        public void Init()
        {
            RegisterViewModels();

            this.MainVm.InitWithoutGroup();
            this.MainVm.InitWithGroup();
        }

        public void RegisterViewModels()
        {
            if (!SimpleIoc.Default.IsRegistered<MainViewModel>())
                SimpleIoc.Default.Register<MainViewModel>(true);
        }

        public MainViewModel MainVm => SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}
