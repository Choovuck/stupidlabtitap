using System;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class CriterionViewModel : UINotifyPropertyChangedBase
    {
        private int _cNum;
        private string _cName;
        private int _cRange;
        private int _cWeight;
        private CriterionTypes _cType;
        private OptimType _optimType;
        private string _edIzmer;
        private ScaleTypes _scaleType;

        public string CDisplay { get { return String.Format("{0} - {1}", CNum, CName); } }

        public int CNum
        {
            get { return _cNum; }
            set
            {
                if (value == _cNum) return;
                _cNum = value;
                OnPropertyChanged(nameof(CNum));
                OnPropertyChanged(nameof(CDisplay));
            }
        }

        public string CName
        {
            get { return _cName; }
            set
            {
                if (value == _cName) return;
                _cName = value;
                OnPropertyChanged(nameof(CName));
                OnPropertyChanged(nameof(CDisplay));
            }
        }

        public int CRange
        {
            get { return _cRange; }
            set
            {
                if (value == _cRange) return;
                _cRange = value;
                OnPropertyChanged(nameof(CRange));
            }
        }

        public int CWeight
        {
            get { return _cWeight; }
            set
            {
                if (value == _cWeight) return;
                _cWeight = value;
                OnPropertyChanged(nameof(CWeight));
            }
        }

        public CriterionTypes CType
        {
            get { return _cType; }
            set
            {
                if (value == _cType) return;
                _cType = value;
                OnPropertyChanged(nameof(CType));
            }
        }

        public OptimType OptimType
        {
            get { return _optimType; }
            set
            {
                if (value == _optimType) return;
                _optimType = value;
                OnPropertyChanged(nameof(OptimType));
            }
        }

        public string EdIzmer
        {
            get { return _edIzmer; }
            set
            {
                if (value == _edIzmer) return;
                _edIzmer = value;
                OnPropertyChanged(nameof(EdIzmer));
            }
        }

        public ScaleTypes ScaleType
        {
            get { return _scaleType; }
            set
            {
                if (value == _scaleType) return;
                _scaleType = value;
                OnPropertyChanged(nameof(ScaleType));
            }
        }

        public CriterionViewModel(Criterion criterion = null)
        {
            if (criterion != null)
            {
                CNum = criterion.CNum;
                CName = criterion.CName;
                CWeight = criterion.CWeight;
                CRange = criterion.CRange;
                EdIzmer = criterion.EdIzmer;

                CriterionTypes type;
                Enum.TryParse(criterion.CType, out type);
                CType = type;

                OptimType optimType;
                Enum.TryParse(criterion.OptimType, out optimType);
                OptimType = optimType;

                ScaleTypes scaleType;
                Enum.TryParse(criterion.ScaleType, out scaleType);
                ScaleType = scaleType;
            }
        }
    }
}
