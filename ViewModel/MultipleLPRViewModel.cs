using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TILab1WPF.Model;
using GongSolutions.Wpf.DragDrop;
using System.Collections.ObjectModel;
using System.Windows;

namespace TILab1WPF.ViewModel
{
    public class MultipleLPRViewModel : UINotifyPropertyChangedBase, IDropTarget
    {
        private ObservableCollection<Alternative>  _alternatives;

        public ObservableCollection<Alternative> Alternatives
        {
            get { return _alternatives; }
            set
            {
                if (value == _alternatives)
                    return;

                _alternatives = value;
                OnPropertyChanged(nameof(Alternatives));
            }
        }

        void IDropTarget.DragOver(DropInfo dropInfo)
        {
            if (dropInfo.Data is Alternative)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        void IDropTarget.Drop(DropInfo dropInfo)
        {
            var item = dropInfo.Data as Alternative;
            (dropInfo.DragInfo.SourceCollection as IList<Alternative>).Remove(item);
        }
    }
}
