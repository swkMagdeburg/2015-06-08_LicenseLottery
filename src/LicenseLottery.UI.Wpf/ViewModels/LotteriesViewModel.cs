using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;

namespace LicenseLottery.UI.Wpf.ViewModels
{
    public class LotteriesViewModel : ViewModelBase
    {
        private readonly ICreateNewLottery _createNewLottery;
        private readonly IReadLottery _readLottery;
        private string _newLotteryName;
        private Lottery _selectedLottery;

        public LotteriesViewModel(ICreateNewLottery createNewLottery, IReadLottery readLottery)
        {
            _createNewLottery = createNewLottery;
            _readLottery = readLottery;
            CreateNewLottery = new RelayCommand(CreateNewLotteryExecute, CreateNewLotteryCanExecute);
            Lotteries = new ObservableCollection<Lottery>();
        }

        public ObservableCollection<Lottery> Lotteries { get; set; }
        public ICommand CreateNewLottery { get; private set; }

        public string NewLotteryName
        {
            get { return _newLotteryName; }
            set { Set(() => NewLotteryName, ref _newLotteryName, value); }
        }

        public Lottery SelectedLottery
        {
            get { return _selectedLottery; }
            set { Set(() => SelectedLottery, ref _selectedLottery, value); }
        }

        private void CreateNewLotteryExecute()
        {
            _createNewLottery.WithName(NewLotteryName);
            NewLotteryName = string.Empty;
            ReadLotteries();
        }

        private bool CreateNewLotteryCanExecute()
        {
            return !string.IsNullOrWhiteSpace(NewLotteryName);
        }

        private void ReadLotteries()
        {
            Lotteries.Clear();
            _readLottery.All().ForEach(Lotteries.Add);
        }

    }
}
