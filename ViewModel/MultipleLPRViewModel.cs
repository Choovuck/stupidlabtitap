using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TILab1WPF.Model;

namespace TILab1WPF.ViewModel
{
    public class MultipleLPRViewModel : UINotifyPropertyChangedBase
    {
        private Dictionary<LPR, List<Alternative>> _rankings;

        public MultipleLPRViewModel()
        {
            
        }
    }
}
