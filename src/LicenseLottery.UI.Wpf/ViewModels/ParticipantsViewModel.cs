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
    public class ParticipantsViewModel : ViewModelBase
    {
        private readonly IAddParticipantToLottery _addParticipantToLottery;
        private readonly ICreateNewParticipant _createNewParticipant;
        private readonly IReadLottery _readLottery;
        private readonly IReadParticipant _readParticipant;
        private Guid _lotteryId;
        private string _newParticipantFirstname;
        private string _newParticipantLastname;
        private string _pageTitle;
        private Participant _toAddedParticipant;

        public ParticipantsViewModel(ICreateNewParticipant createNewParticipant, IReadParticipant readParticipant,
            IReadLottery readLottery, IAddParticipantToLottery addParticipantToLottery)
        {
            _createNewParticipant = createNewParticipant;
            _readParticipant = readParticipant;
            _readLottery = readLottery;
            _addParticipantToLottery = addParticipantToLottery;

            KnownParticipants = new ObservableCollection<Participant>();
            LotteryParticipants = new ObservableCollection<Participant>();

            CreateNewParticipant = new RelayCommand(CreateNewParticipantExecute, CreateNewParticipantCanExecute);
            AddParticipantToLottery = new RelayCommand(AddParticipantToLotteryExecute, AddParticipantToLotteryCanExecute);

            PropertyChanged += On_PropertyChanged;
        }

        public ObservableCollection<Participant> KnownParticipants { get; private set; }
        public ObservableCollection<Participant> LotteryParticipants { get; private set; }
        public ICommand CreateNewParticipant { get; private set; }
        public ICommand AddParticipantToLottery { get; private set; }

        public Guid LotteryId
        {
            get { return _lotteryId; }
            set { Set(() => LotteryId, ref _lotteryId, value); }
        }

        public string PageTitle
        {
            get { return _pageTitle; }
            set { Set(() => PageTitle, ref _pageTitle, value); }
        }

        public Participant ToAddedParticipant
        {
            get { return _toAddedParticipant; }
            set { Set(() => ToAddedParticipant, ref _toAddedParticipant, value); }
        }

        public string NewParticipantFirstname
        {
            get { return _newParticipantFirstname; }
            set { Set(() => NewParticipantFirstname, ref _newParticipantFirstname, value); }
        }

        public string NewParticipantLastname
        {
            get { return _newParticipantLastname; }
            set { Set(() => NewParticipantLastname, ref _newParticipantLastname, value); }
        }

        private bool CreateNewParticipantCanExecute()
        {
            return !string.IsNullOrWhiteSpace(NewParticipantFirstname) &&
                   !string.IsNullOrWhiteSpace(NewParticipantLastname);
        }

        private void CreateNewParticipantExecute()
        {
            _createNewParticipant.WithFirstAndLastname(NewParticipantFirstname, NewParticipantLastname);
            NewParticipantFirstname = string.Empty;
            NewParticipantLastname = string.Empty;
            ReadKnownParticipants();
        }

        private bool AddParticipantToLotteryCanExecute()
        {
            return LotteryId != Guid.Empty && ToAddedParticipant != null;
        }

        private void AddParticipantToLotteryExecute()
        {
            _addParticipantToLottery.WithIds(LotteryId, ToAddedParticipant.Id);
            ReadLotteryParticipants();
        }

        private void On_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GetPropertyName(() => LotteryId))
            {
                PageTitle = string.Format("Participants for Lottery {0}", _readLottery.WithId(LotteryId).Name);
                ReadLotteryParticipants();
            }
        }

        private void ReadKnownParticipants()
        {
            KnownParticipants.Clear();
            _readParticipant.All().ToList().ForEach(KnownParticipants.Add);
        }

        private void ReadLotteryParticipants()
        {
            LotteryParticipants.Clear();
            var lottery = _readLottery.WithId(LotteryId);
            lottery.Participants.ToList().ForEach(LotteryParticipants.Add);
        }
    }
}
