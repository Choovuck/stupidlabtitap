using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class VectorViewModel : UINotifyPropertyChangedBase
    {
        private int _vNum;
        private AlternativeViewModel _alternative;
        private MarkViewModel _mark;

        public int VNum
        {
            get { return _vNum; }
            set
            {
                if (value == _vNum) return;
                _vNum = value;
                OnPropertyChanged(nameof(VNum));
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

        public MarkViewModel Mark
        {
            get { return _mark; }
            set
            {
                if (Equals(value, _mark)) return;
                _mark = value;
                OnPropertyChanged(nameof(Mark));
            }
        }

        public VectorViewModel(Vector vector = null, IEnumerable<MarkViewModel> marks = null, IEnumerable<AlternativeViewModel> alternatives = null)
        {
            if (vector != null)
            {
                VNum = vector.VNum;
                Alternative = alternatives?.FirstOrDefault(a => a.ANum == vector.ANum);
                Mark = marks?.FirstOrDefault(m => m.MNum == vector.MNum);
            }
        }
    }
}
