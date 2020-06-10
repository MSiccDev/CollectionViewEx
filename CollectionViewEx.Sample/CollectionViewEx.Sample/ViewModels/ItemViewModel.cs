using CollectionViewEx.Sample.Controls;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewEx.Sample.ViewModels
{
    public class ItemViewModel : ViewModelBase, IScrollItem
    {
        public ItemViewModel()
        {
            this.Config = new ScrollToConfiguration();
        }

        public string Text { get; set; }

        public int Number { get; set; }

        public ScrollToConfiguration Config { get; set; }
    }
}
