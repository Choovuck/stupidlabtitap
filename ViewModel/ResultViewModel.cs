using System.Collections.Generic;
using System.Linq;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class ResultViewModel : UINotifyPropertyChangedBase
    {
        private int _rNum;
        private int _range;
        private int _aWeight;
        private LPRViewModel _lpr;
        private AlternativeViewModel _alternative;

        public int RNum
        {
            get { return _rNum; }
            set
            {
                if (value == _rNum) return;
                _rNum = value;
                OnPropertyChanged(nameof(RNum));
            }
        }

        public int Range
        {
            get { return _range; }
            set
            {
                if (value == _range) return;
                _range = value;
                OnPropertyChanged(nameof(Range));
            }
        }

        public int AWeight
        {
            get { return _aWeight; }
            set
            {
                if (value == _aWeight) return;
                _aWeight = value;
                OnPropertyChanged(nameof(AWeight));
            }
        }

        public LPRViewModel LPR
        {
            get { return _lpr; }
            set
            {
                if (Equals(value, _lpr)) return;
                _lpr = value;
                OnPropertyChanged(nameof(LPR));
            }
        }

        public AlternativeViewModel Alternative
        {
            get { return _alternative; }
            set
            {
                if (Equals(value, _alternative)) return;
                _alternative = value;
                OnPropertyChanged(nameof(Alternative));
            }
        }

        public ResultViewModel(Result result = null, IEnumerable<LPRViewModel> lprs = null, IEnumerable<AlternativeViewModel> alternatives = null)
        {
            if (result != null)
            {
                RNum = result.RNum;
                Range = result.Range;
                AWeight = result.AWeight;
                LPR = lprs?.FirstOrDefault(l => l.LNum == result.LNum);
                Alternative = alternatives?.FirstOrDefault(a => a.ANum == result.ANum);
            }
        }
    }
}
