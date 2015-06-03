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
        private Lottery _createdLottery;
        private string _newLotteryName;
        private Lottery _selectedLottery;

        public LotteriesViewModel(ICreateNewLottery createNewLottery, IReadLottery readLottery)
        {
            _createNewLottery = createNewLottery;
            _readLottery = readLottery;
            CreateNewLottery = new RelayCommand(CreateNewLotteryExecute, CreateNewLotteryCanExecute);
            Lotteries = new ObservableCollection<Lottery>();
        }

        public ICommand CreateNewLottery { get; private set; }

        public string NewLotteryName
        {
            get { return _newLotteryName; }
            set { Set(() => NewLotteryName, ref _newLotteryName, value); }
        }

        public Lottery CreatedLottery
        {
            get { return _createdLottery; }
            set { Set(() => CreatedLottery, ref _createdLottery, value); }
        }

        public ObservableCollection<Lottery> Lotteries { get; set; }

        public Lottery SelectedLottery
        {
            get { return _selectedLottery; }
            set { Set(() => SelectedLottery, ref _selectedLottery, value); }
        }

        private void CreateNewLotteryExecute()
        {
            CreatedLottery = _createNewLottery.WithName(NewLotteryName);
            NewLotteryName = string.Empty;
            ReadLotteries();
        }

        private bool CreateNewLotteryCanExecute()
        {
            return !string.IsNullOrWhiteSpace(NewLotteryName);
        }

        private void ReadLotteries()
        {
            _readLottery.All().Except(Lotteries).ToList().ForEach(Lotteries.Add);
        }

    }
}
