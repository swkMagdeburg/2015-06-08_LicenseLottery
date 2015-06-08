using System;
using System.Globalization;
using System.Windows.Data;
using LicenseLottery.Core.Entities;

namespace LicenseLottery.UI.Wpf.Converters
{
    public class ParticipantToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var participant = value as Participant;
            if (participant == null)
            {
                return string.Empty;
            }

            return string.Format("{0} {1}", participant.Firstname, participant.Lastname);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
