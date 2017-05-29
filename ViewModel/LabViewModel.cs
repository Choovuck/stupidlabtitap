using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class LabViewModel : UINotifyPropertyChangedBase
    {
        private AlternativeViewModel _newAlternative;
        private CriterionViewModel _newCriterion;
        private LPRViewModel _newLpr;
        private MarkViewModel _newMark;
        private VectorViewModel _newVector;
        private ResultViewModel _newResult;
        public ObservableCollection<AlternativeViewModel> Alternatives { get; set; }
        
        public ObservableCollection<CriterionViewModel> Criterions { get; set; }
        
        public ObservableCollection<LPRViewModel> LPRs { get; set; }
        
        public ObservableCollection<MarkViewModel> Marks { get; set; }
        
        public ObservableCollection<VectorViewModel> Vectors { get; set; } 

        public ObservableCollection<ResultViewModel> Results { get; set; }

        public AlternativeViewModel NewAlternative
        {
            get { return _newAlternative; }
            set
            {
                if (Equals(value, _newAlternative)) return;
                _newAlternative = value;
                OnPropertyChanged(nameof(NewAlternative));
            }
        }

        public CriterionViewModel NewCriterion
        {
            get { return _newCriterion; }
            set
            {
                if (Equals(value, _newCriterion)) return;
                _newCriterion = value;
                OnPropertyChanged(nameof(NewCriterion));
            }
        }

        public LPRViewModel NewLPR
        {
            get { return _newLpr; }
            set
            {
                if (Equals(value, _newLpr)) return;
                _newLpr = value;
                OnPropertyChanged(nameof(NewLPR));
            }
        }

        public MarkViewModel NewMark
        {
            get { return _newMark; }
            set
            {
                if (Equals(value, _newMark)) return;
                _newMark = value;
                OnPropertyChanged(nameof(NewMark));
            }
        }

        public VectorViewModel NewVector
        {
            get { return _newVector; }
            set
            {
                if (Equals(value, _newVector)) return;
                _newVector = value;
                OnPropertyChanged(nameof(NewVector));
            }
        }

        public ResultViewModel NewResult
        {
            get { return _newResult; }
            set
            {
                if (Equals(value, _newResult)) return;
                _newResult = value;
                OnPropertyChanged(nameof(NewResult));
            }
        }

        public UniverEntities Context { get; set; }

        public LabViewModel(UniverEntities context)
        {
            Context = context;
            Alternatives =
                new ObservableCollection<AlternativeViewModel>(
                    context.Alternatives.ToList().Select(a => new AlternativeViewModel(a)));

            Criterions =
                new ObservableCollection<CriterionViewModel>(context.Criteria.ToList().Select(c => new CriterionViewModel(c)));

            LPRs = new ObservableCollection<LPRViewModel>(context.LPRs.ToList().Select(l => new LPRViewModel(l)));

            Marks = new ObservableCollection<MarkViewModel>(context.Marks.ToList().Select(m => new MarkViewModel(m, Criterions)));
            Vectors =
                new ObservableCollection<VectorViewModel>(
                    context.Vectors.ToList().Select(v => new VectorViewModel(v, Marks, Alternatives)));
            Results =
                new ObservableCollection<ResultViewModel>(
                    context.Results.ToList().Select(r => new ResultViewModel(r, LPRs, Alternatives)));

            NewAlternative = new AlternativeViewModel();
            NewCriterion = new CriterionViewModel();
            NewLPR = new LPRViewModel();
            NewMark = new MarkViewModel();
            NewVector = new VectorViewModel();
            NewResult = new ResultViewModel();
        }
    }
}
