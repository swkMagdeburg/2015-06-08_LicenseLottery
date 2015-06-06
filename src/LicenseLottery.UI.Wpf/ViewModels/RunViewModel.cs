using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LicenseLottery.Core.Entities;
using LicenseLottery.Core.UseCases;

namespace LicenseLottery.UI.Wpf.ViewModels
{
    public class RunViewModel : ViewModelBase
    {
        private readonly IReadLottery _readLottery;
        private readonly IRunLottery _runLottery;
        private Guid _lotteryId;
        private string _roundName;

        public RunViewModel(IRunLottery runLottery, IReadLottery readLottery)
        {
            _runLottery = runLottery;
            _readLottery = readLottery;

            Games = new ObservableCollection<Game>();
            Winners = new ObservableCollection<Participant>();

            CreateNextRound = new RelayCommand(CreateNextRoundExecute);
            PlayNextRound = new RelayCommand(PlayNextRoundExecute);

            PropertyChanged += On_PropertyChanged;
        }

        public ObservableCollection<Game> Games { get; private set; }
        public ObservableCollection<Participant> Winners { get; private set; }
        public ICommand CreateNextRound { get; private set; }
        public ICommand PlayNextRound { get; private set; }

        public string RoundName
        {
            get { return _roundName; }
            private set { Set(() => RoundName, ref _roundName, value); }
        }

        public Guid LotteryId
        {
            get { return _lotteryId; }
            set { Set(() => LotteryId, ref _lotteryId, value); }
        }

        private void On_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GetPropertyName(() => LotteryId))
            {
                ReadRound();
            }
        }

        private void PlayNextRoundExecute()
        {
            _runLottery.PlayNextRound(LotteryId);
            ReadRound();
        }

        private void CreateNextRoundExecute()
        {
            _runLottery.CreateNextRound(LotteryId);
            ReadRound();
        }

        private void ReadRound()
        {
            var lottery = _readLottery.WithId(LotteryId);

            RoundName = string.Format("Round #{0}", lottery.Rounds.Count);
            Games.Clear();
            Winners.Clear();

            if (lottery.Rounds.Count == 0)
            {
                return;
            }

            var currentRound = lottery.Rounds.Last();
            currentRound.Games.ForEach(Games.Add);
            currentRound.Winners.ForEach(Winners.Add);
        }
    }
}
