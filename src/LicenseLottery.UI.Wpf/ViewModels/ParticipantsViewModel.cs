using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.UI.Wpf.ViewModels
{
    public class ParticipantsViewModel : ViewModelBase
    {
        private Lottery _lottery;
        private string _pageTitle;
        private Participant _toAddedParticipant;

        public ParticipantsViewModel()
        {
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

        public Lottery Lottery
        {
            get { return _lottery; }
            set { Set(() => Lottery, ref _lottery, value); }
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

        public string NewParticipantFirstname { get; set; }
        public string NewParticipantLastname { get; set; }

        private bool CreateNewParticipantCanExecute()
        {
            return !string.IsNullOrWhiteSpace(NewParticipantFirstname) &&
                   !string.IsNullOrWhiteSpace(NewParticipantLastname);
        }

        private void CreateNewParticipantExecute()
        {
        }

        private bool AddParticipantToLotteryCanExecute()
        {
            return ToAddedParticipant != null;
        }

        private void AddParticipantToLotteryExecute()
        {
        }

        private void On_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == GetPropertyName(() => Lottery))
            {
                PageTitle = string.Format("Participants for Lottery {0}", Lottery.Name);
            }
        }
    }
}
