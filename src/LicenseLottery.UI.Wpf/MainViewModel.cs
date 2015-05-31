using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.UI.Wpf
{
    public class MainViewModel : ViewModelBase
    {
        private Lottery _createdLottery;
        private string _newLotteryName;

        public MainViewModel()
        {
            CreateNewLottery = new RelayCommand(CreateNewLotteryExecute, CreateNewLotteryCanExecute);
        }

        public RelayCommand CreateNewLottery { get; private set; }

        public string NewLotteryName
        {
            get { return _newLotteryName; }
            set { Set(() => NewLotteryName, ref _newLotteryName, value); }
        }

        public Lottery CreatedLottery
        {
            get { return _createdLottery; }
            set
            {
                Set(() => CreatedLottery, ref _createdLottery, value);
                CreateNewLottery.RaiseCanExecuteChanged();
            }
        }

        private void CreateNewLotteryExecute()
        {
        }

        private bool CreateNewLotteryCanExecute()
        {
            return !string.IsNullOrWhiteSpace(_newLotteryName);
        }
    }
}
