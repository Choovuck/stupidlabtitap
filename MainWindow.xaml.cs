using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TILab1WPF.Model;
using TILab1WPF.ViewModel;

namespace TILab1WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LabViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
            _viewModel = new LabViewModel(new UniverEntities());
            }
            catch (Exception ex)
            {
                int a = 0;
                throw;
            }
            main.DataContext = _viewModel;
            cBox.ItemsSource = _viewModel.Criterions;
            aBox.ItemsSource = _viewModel.Alternatives;
            mBox.ItemsSource = _viewModel.Marks;
            LPRSelect.DataContext = _viewModel;
            LPRSelect.SelectedIndex = 0;
            _rankings = new Dictionary<LPRViewModel, List<AlternativeViewModel>>();
              UpdateNotVoted();
        }

        private void OnBeginEdit(object sender, RoutedEventArgs e)
        {
            var control = sender as Button;
            var entity = control?.DataContext as UINotifyPropertyChangedBase;
            if (entity != null)
            {
                entity.IsEdited = true;
            }
        }

        private void OnEndEditLPR(object sender, RoutedEventArgs e)
        {
            var control = sender as Button;
            var entity = control?.DataContext as LPRViewModel;
            if (entity != null)
            {
                LPR originalEntity = _viewModel.Context.LPRs.Find(entity.LNum);
                if (originalEntity == null) throw new Exception("Database changed");

                entity.LName = originalEntity.LName;
                entity.LRange = originalEntity.LRange;
                entity.IsEdited = false;
            }
        }

        private void OnEndEditAlternative(object sender, RoutedEventArgs e)
        {
            var control = sender as Button;
            var entity = control?.DataContext as AlternativeViewModel;
            if (entity != null)
            {
                Alternative originalEntity = _viewModel.Context.Alternatives.Find(entity.ANum);
                if(originalEntity == null) throw new Exception("Database changed");

                entity.AName = originalEntity.AName;
                entity.IsEdited = false;
            }
        }

        private void OnEndEditCriterion(object sender, RoutedEventArgs e)
        {
            var control = sender as Button;
            var entity = control?.DataContext as CriterionViewModel;
            if (entity != null)
            {
                Criterion originalEntity = _viewModel.Context.Criteria.Find(entity.CNum);
                if (originalEntity == null) throw new Exception("Database changed");

                entity.CName = originalEntity.CName;
                entity.CRange = originalEntity.CRange;
                CriterionTypes ctype;
                OptimType optimType;
                ScaleTypes scaleType;
                Enum.TryParse(originalEntity.CType, out ctype);
                Enum.TryParse(originalEntity.OptimType, out optimType);
                Enum.TryParse(originalEntity.ScaleType, out scaleType);
                entity.CType = ctype;
                entity.OptimType = optimType;
                entity.ScaleType = scaleType;
                entity.EdIzmer = originalEntity.EdIzmer;
                entity.IsEdited = false;
            }
        }

        private void OnEndEditMark(object sender, RoutedEventArgs e)
        {
            var control = sender as Button;
            var entity = control?.DataContext as MarkViewModel;
            if (entity != null)
            {
                Mark originalEntity = _viewModel.Context.Marks.Find(entity.MNum);
                if(originalEntity == null) throw new Exception("Database changed");

                entity.MName = originalEntity.MName;
                entity.Criterion = _viewModel.Criterions.FirstOrDefault(c => c.CNum == originalEntity.CNum);
                entity.MRange = originalEntity.MRange;
                entity.NumMark = originalEntity.NumMark;
                entity.NormMark = originalEntity.NormMark;
                entity.IsEdited = false;
            }
        }

        private void OnEndEditVector(object sender, RoutedEventArgs e)
        {
            var control = sender as Button;
            var entity = control?.DataContext as VectorViewModel;
            if (entity != null)
            {
                Model.Vector originalEntity = _viewModel.Context.Vectors.Find(entity.VNum);
                if (originalEntity == null) throw new Exception("Database changed");

                entity.Alternative = _viewModel.Alternatives.FirstOrDefault(a => a.ANum == originalEntity.ANum);
                entity.Mark = _viewModel.Marks.FirstOrDefault(m => m.MNum == originalEntity.MNum);
                entity.IsEdited = false;
            }
        }

        private void AddLpr(object sender, RoutedEventArgs e)
        {
            var newLpr = new LPR
            {
                LName = _viewModel.NewLPR.LName,
                LRange = _viewModel.NewLPR.LRange
            };

            _viewModel.Context.LPRs.Add(newLpr);
            _viewModel.Context.SaveChanges();
            _viewModel.NewLPR.LNum = newLpr.LNum;
            _viewModel.LPRs.Add(_viewModel.NewLPR);
            _viewModel.NewLPR = new LPRViewModel();
        }

        private void AddAlternative(object sender, RoutedEventArgs e)
        {
            var newAlternative = new Alternative
            {
                AName = _viewModel.NewAlternative.AName
            };

            _viewModel.Context.Alternatives.Add(newAlternative);
            _viewModel.Context.SaveChanges();
            _viewModel.NewAlternative.ANum = newAlternative.ANum;
            _viewModel.Alternatives.Add(_viewModel.NewAlternative);
            _viewModel.NewAlternative = new AlternativeViewModel();
        }

        private void AddCriterion(object sender, RoutedEventArgs e)
        {
            var newCriterion = new Criterion
            {
                CName = _viewModel.NewCriterion.CName,
                CRange = _viewModel.NewCriterion.CRange,
                CWeight = _viewModel.NewCriterion.CWeight,
                CType = _viewModel.NewCriterion.CType.ToString(),
                OptimType = _viewModel.NewCriterion.OptimType.ToString(),
                ScaleType = _viewModel.NewCriterion.ScaleType.ToString(),
                EdIzmer = _viewModel.NewCriterion.EdIzmer
            };

            _viewModel.Context.Criteria.Add(newCriterion);
            _viewModel.Context.SaveChanges();
            _viewModel.NewCriterion.CNum = newCriterion.CNum;
            _viewModel.Criterions.Add(_viewModel.NewCriterion);
            _viewModel.NewCriterion = new CriterionViewModel();
        }

        private void AddMark(object sender, RoutedEventArgs e)
        {
            var newMark = new Mark
            {
                MName = _viewModel.NewMark.MName,
                MRange = _viewModel.NewMark.MRange,
                NumMark = _viewModel.NewMark.NumMark,
                NormMark = _viewModel.NewMark.NormMark,
                CNum = _viewModel.NewMark.Criterion.CNum
            };

            _viewModel.Context.Marks.Add(newMark);
            _viewModel.Context.SaveChanges();
            _viewModel.NewMark.MNum = newMark.MNum;
            _viewModel.Marks.Add(_viewModel.NewMark);
            _viewModel.NewMark = new MarkViewModel();
        }

        private void AddVector(object sender, EventArgs e)
        {
            var newVector = new Model.Vector
            {
                MNum = _viewModel.NewVector.Mark.MNum,
                ANum = _viewModel.NewVector.Alternative.ANum
            };

            _viewModel.Context.Vectors.Add(newVector);
            _viewModel.Context.SaveChanges();
            _viewModel.NewVector.VNum = newVector.VNum;
            _viewModel.Vectors.Add(_viewModel.NewVector);
            _viewModel.NewVector = new VectorViewModel();
        }

        private void OnCalculate(object sender, RoutedEventArgs e)
        {
            var gachiThinker = new DecisionMaker(_viewModel.Context);
            var results = gachiThinker.GetSortedDecisions();
            var theBestBoyNextDoor = results.First();

            string concated = "";
            foreach (var r in results)
                concated += r.Alternative.AName + "\r\n";

            textBox.Text = concated;
        }


        private Dictionary<LPRViewModel, List<AlternativeViewModel>> _rankings;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            LPRViewModel SelectedLPR = LPRSelect.SelectedItem as LPRViewModel;
            _rankings[SelectedLPR] = AlternativesOrder.Items.Cast<AlternativeViewModel>().ToList();

            UpdateNotVoted();
            UpdateMultupleLPRResults();
        }

        private void UpdateNotVoted()
        {
            var notvoted = _viewModel.LPRs.Where(lpr => !_rankings.Keys.Contains(lpr));
            var names = notvoted.Select(lpr => lpr.LName);
            var str = names.Count() > 0 ? names.Aggregate((x, y) => x + ", " + y) : "";
            notVotedText.Text = str;
        }

        private void ClearVotes_Click(object sender, RoutedEventArgs e)
        {
            _rankings.Clear();
            UpdateNotVoted();
            UpdateMultupleLPRResults();
        }

        private void UpdateMultupleLPRResults()
        {
            if (_rankings.Keys.Count() != _viewModel.LPRs.Count())
            {
                BordResults.Text = "Vote now";
                SimpsonResults.Text = "Vote now";

                return;
            }

            CalculateBord();
            CalculateSimpsons();
        }

        private void CalculateBord()
        {
            var scores = new Dictionary<AlternativeViewModel, int>();
            foreach (var pair in _rankings)
            {
                for (int i = 0; i < pair.Value.Count(); ++i)
                {
                    var alternative = pair.Value[i];
                    var score = pair.Value.Count - i - 1;

                    if (!scores.Keys.Contains(alternative))
                        scores[alternative] = score;
                    else
                        scores[alternative] += score;
                }
            }

            string result = scores.OrderByDescending(pair => pair.Value)
                                  .Select(pair => pair.Key.AName + ": " + pair.Value.ToString())
                                  .Aggregate((x, y) => x + "\r\n" + y);

            BordResults.Text = result;
        }

        private void CalculateSimpsons()
        {

        }
    }
}
