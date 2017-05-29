using System.ComponentModel;
using TILab1WPF.Annotations;

namespace TILab1WPF.ViewModel
{
    public abstract class UINotifyPropertyChangedBase : INotifyPropertyChanged
    {
        private bool _isEdited;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsEdited
        {
            get { return _isEdited; }
            set
            {
                if (value == _isEdited) return;
                _isEdited = value;
                OnPropertyChanged(nameof(IsEdited));
            }
        }
    }
}
