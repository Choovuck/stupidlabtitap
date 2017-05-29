using System;
using System.Collections.Generic;
using System.Linq;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class MarkViewModel : UINotifyPropertyChangedBase
    {
        private int _mNum;
        private string _mName;
        private int _mRange;
        private int _numMark;
        private int _normMark;
        private CriterionViewModel _criterion;

        public string MDisplay { get { return String.Format("{0} - {1}", MNum, MName);} }

        public int MNum
        {
            get { return _mNum; }
            set
            {
                if (value == _mNum) return;
                _mNum = value;
                OnPropertyChanged(nameof(MNum));
                OnPropertyChanged(nameof(MDisplay));
            }
        }

        public string MName
        {
            get { return _mName; }
            set
            {
                if (value == _mName) return;
                _mName = value;
                OnPropertyChanged(nameof(MName));
                OnPropertyChanged(nameof(MDisplay));
            }
        }

        public int MRange
        {
            get { return _mRange; }
            set
            {
                if (value == _mRange) return;
                _mRange = value;
                OnPropertyChanged(nameof(MRange));
            }
        }

        public int NumMark
        {
            get { return _numMark; }
            set
            {
                if (value == _numMark) return;
                _numMark = value;
                OnPropertyChanged(nameof(NumMark));
            }
        }

        public int NormMark
        {
            get { return _normMark; }
            set
            {
                if (value == _normMark) return;
                _normMark = value;
                OnPropertyChanged(nameof(NormMark));
            }
        }

        public CriterionViewModel Criterion
        {
            get { return _criterion; }
            set
            {
                if (Equals(value, _criterion)) return;
                _criterion = value;
                OnPropertyChanged(nameof(Criterion));
            }
        }

        public MarkViewModel(Mark mark = null, IEnumerable<CriterionViewModel> criterions = null)
        {
            if (mark != null)
            {
                MNum = mark.MNum;
                MName = mark.MName;
                MRange = mark.MRange;
                NumMark = mark.NumMark;
                NormMark = mark.NormMark;
                Criterion = criterions?.FirstOrDefault(c => c.CNum == mark.CNum);
            }
        }
    }
}
