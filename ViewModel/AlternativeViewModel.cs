using System;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class AlternativeViewModel : UINotifyPropertyChangedBase
    {
        private int _aNum;
        private string _aName;

        public string ADisplay { get { return String.Format("{0} - {1}", ANum, AName);} }

        public int ANum
        {
            get { return _aNum; }
            set
            {
                if (value == _aNum) return;
                _aNum = value;
                OnPropertyChanged(nameof(ANum));
                OnPropertyChanged(nameof(ADisplay));
            }
        }

        public string AName
        {
            get { return _aName; }
            set
            {
                if (value == _aName) return;
                _aName = value;
                OnPropertyChanged(nameof(AName));
                OnPropertyChanged(nameof(ADisplay));
            }
        }

        public AlternativeViewModel(Alternative alternative = null)
        {
            if (alternative != null)
            {
                ANum = alternative.ANum;
                AName = alternative.AName;
            }
        }
    }
}
