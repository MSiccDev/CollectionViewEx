using CollectionViewEx.Sample.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CollectionViewEx.Sample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ItemViewModel _scrollToViewModel;
        private RelayCommand _scrollToItemCommand;
        private int _scrollToItemNumber;
        private bool _isItemsRadioButtonChecked = true;
        private bool _isGroupsRadioButtonChecked;
        private int _scrollToGroupNumber;
        private RelayCommand _scrollToGroupCommand;
        private ItemWithGroupViewModel _scrollToGroupVm;
        private IConfigurableScrollItem _selectedItemVm;

        public MainViewModel()
        {
            this.ScrollableItems = new ObservableCollection<ItemViewModel>();
            this.ScrollableItemsGroups = new ObservableCollection<ItemsGroupViewModel>();
        }

        public void InitWithoutGroup()
        {
            for (int i = 0; i <= 25; i++)
            {
                var vm = new ItemViewModel() { Config = new Controls.ScrollToConfiguration(), Number = i, Text = $"Item {i}" };
                this.ScrollableItems.Add(vm);
            }
        }

        public void InitWithGroup()
        {
            for (int gi = 0; gi <= 5; gi++)
            {
                var groupItems = new List<ItemWithGroupViewModel>();
                for (int i = 0; i <= 10; i++)
                {
                    var vm = new ItemWithGroupViewModel() { Config = new Controls.ScrollToConfiguration(), Number = i, Text = $"Item {i}" };
                    groupItems.Add(vm);
                }

                var giVm = new ItemsGroupViewModel($"Group {gi}", groupItems);
                this.ScrollableItemsGroups.Add(giVm);
            }
        }

        private void ExcuteScrollToItem()
        {
            this.ScrollToVm = this.ScrollableItems.SingleOrDefault(vm => vm.Number == this.ScrollToItemNumber);
            this.SelectedItemVm = (IScrollItem)this.ScrollToVm;
        }

        private bool CanExecuteScrollToItem()
        {
            return this.ScrollableItems.Any(vm => vm.Number == this.ScrollToItemNumber);
        }




        private void ExcuteScrollToGroup()
        {
            var groupsVm = this.ScrollableItemsGroups.SingleOrDefault(vm => vm.GroupName.Contains(this.ScrollToGroupNumber.ToString()) && vm.Any(vmi => vmi.Number == ScrollToItemNumber));
            var itemInGroup = groupsVm.SingleOrDefault(vm => vm.Number == ScrollToItemNumber);

            this.ScrollToGroupVm = itemInGroup;
            this.SelectedItemVm = itemInGroup;
        }

        private bool CanExecuteScrollToGroup()
        {
            return this.ScrollableItemsGroups.Any(vm => vm.GroupName.Contains(this.ScrollToGroupNumber.ToString()) && vm.Any(vmi => vmi.Number == ScrollToItemNumber));
        }


        public int ScrollToItemNumber
        {
            get => _scrollToItemNumber;
            set
            {
                Set(ref _scrollToItemNumber, value);
                this.ScrollToItemCommand.RaiseCanExecuteChanged();
                this.ScrollToGroupCommand.RaiseCanExecuteChanged();
            }
        }

        public int ScrollToGroupNumber
        {
            get => _scrollToGroupNumber;
            set
            {
                Set(ref _scrollToGroupNumber, value);
                this.ScrollToGroupCommand.RaiseCanExecuteChanged();
            }
        }



        public ObservableCollection<ItemViewModel> ScrollableItems { get; set; }
        public ObservableCollection<ItemsGroupViewModel> ScrollableItemsGroups { get; set; }
        public ItemViewModel ScrollToVm { get => _scrollToViewModel; set => Set(ref _scrollToViewModel, value); }
        public ItemWithGroupViewModel ScrollToGroupVm { get => _scrollToGroupVm; set => Set(ref _scrollToGroupVm, value); }

        public IConfigurableScrollItem SelectedItemVm { get => _selectedItemVm; set => Set (ref _selectedItemVm, value); }


        public bool IsItemsRadioButtonChecked
        {
            get => _isItemsRadioButtonChecked;
            set
            {
                Set(ref _isItemsRadioButtonChecked, value);
                this.ScrollToItemNumber = 0;
                this.ScrollToGroupNumber = 0;
                this.SelectedItemVm = this.ScrollableItems.FirstOrDefault();
                this.ScrollToVm = this.ScrollableItems.FirstOrDefault();
            }
        }

        public bool IsGroupsRadioButtonChecked
        {
            get => _isGroupsRadioButtonChecked;
            set
            {
                Set(ref _isGroupsRadioButtonChecked, value);
                this.ScrollToItemNumber = 0;

                this.SelectedItemVm = this.ScrollableItemsGroups.FirstOrDefault().FirstOrDefault();
            }
        }


        public RelayCommand ScrollToItemCommand => _scrollToItemCommand ?? (_scrollToItemCommand = new RelayCommand(() => ExcuteScrollToItem(), () => CanExecuteScrollToItem()));

        public RelayCommand ScrollToGroupCommand => _scrollToGroupCommand ?? (_scrollToGroupCommand = new RelayCommand(() => ExcuteScrollToGroup(), () => CanExecuteScrollToGroup()));

    }
}



