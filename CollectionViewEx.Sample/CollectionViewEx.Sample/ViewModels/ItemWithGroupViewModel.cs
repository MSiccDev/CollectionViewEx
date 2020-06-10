using CollectionViewEx.Sample.Controls;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewEx.Sample.ViewModels
{
    public class ItemWithGroupViewModel : ViewModelBase, IGroupScrollItem
    {
        public ItemWithGroupViewModel()
        {
            this.Config = new ScrollToConfiguration();
        }

        public object GroupValue { get; set; }

        public string Text { get; set; }

        public int Number { get; set; }

        public ScrollToConfiguration Config { get; set; }
    }
}
