using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class LPRViewModel : UINotifyPropertyChangedBase
    {
        private int _lNum;
        private string _lName;
        private int _lRange;

        public int LNum
        {
            get { return _lNum; }
            set
            {
                if (value == _lNum) return;
                _lNum = value;
                OnPropertyChanged(nameof(LNum));
            }
        }

        public string LName
        {
            get { return _lName; }
            set
            {
                if (value == _lName) return;
                _lName = value;
                OnPropertyChanged(nameof(LName));
            }
        }

        public int LRange
        {
            get { return _lRange; }
            set
            {
                if (value == _lRange) return;
                _lRange = value;
                OnPropertyChanged(nameof(LRange));
            }
        }

        public LPRViewModel(LPR lpr = null)
        {
            if (lpr != null)
            {
                LNum = lpr.LNum;
                LName = lpr.LName;
                LRange = lpr.LRange;
            }
        }
    }
}
