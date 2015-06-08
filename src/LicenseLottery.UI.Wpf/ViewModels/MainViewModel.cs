using System;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace LicenseLottery.UI.Wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private const int PageCount = 3;
        private int _activePageIndex;

        public MainViewModel(LotteriesViewModel lotteriesViewModel, ParticipantsViewModel participantsViewModel, RunViewModel runViewModel)
        {
            LotteriesViewModel = lotteriesViewModel;
            ParticipantsViewModel = participantsViewModel;
            RunViewModel = runViewModel;

            GotoNextPage = new RelayCommand(GotoNextPageExecute, GotoNextPageCanExecute);
            GotoPreviousPage = new RelayCommand(GotoPreviousPageExecute, GotoPreviousPageCanExecute);
            ActivePageIndex = 0;

            LotteriesViewModel.PropertyChanged += LotteriesViewModel_PropertyChanged;
        }

        public ICommand GotoNextPage { get; private set; }
        public ICommand GotoPreviousPage { get; private set; }

        public int ActivePageIndex
        {
            get { return _activePageIndex; }
            set { Set(() => ActivePageIndex, ref _activePageIndex, value); }
        }

        public LotteriesViewModel LotteriesViewModel { get; private set; }
        public ParticipantsViewModel ParticipantsViewModel { get; private set; }
        public RunViewModel RunViewModel { get; private set; }

        private void GotoNextPageExecute()
        {
            ActivePageIndex = ActivePageIndex + 1;
        }

        private bool GotoNextPageCanExecute()
        {
            return ActivePageIndex < PageCount - 1;
        }

        private void GotoPreviousPageExecute()
        {
            ActivePageIndex = ActivePageIndex - 1;
        }

        private bool GotoPreviousPageCanExecute()
        {
            return ActivePageIndex > 0;
        }

        private void LotteriesViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GetPropertyName(() => LotteriesViewModel.SelectedLottery))
            {
                ParticipantsViewModel.LotteryId = LotteriesViewModel.SelectedLottery == null ? Guid.Empty : LotteriesViewModel.SelectedLottery.Id;
                RunViewModel.LotteryId = ParticipantsViewModel.LotteryId;
            }
        }
    }
}
