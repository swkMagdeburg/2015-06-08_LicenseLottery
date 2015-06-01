using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;

namespace LicenseLottery.UI.Wpf
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICreateNewLottery _createNewLottery;
        private Lottery _createdLottery;
        private string _newLotteryName;

        public MainViewModel(ICreateNewLottery createNewLottery)
        {
            _createNewLottery = createNewLottery;
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
            CreatedLottery = _createNewLottery.WithName(NewLotteryName);
            NewLotteryName = string.Empty;
        }

        private bool CreateNewLotteryCanExecute()
        {
            return !string.IsNullOrWhiteSpace(NewLotteryName);
        }
    }
}
