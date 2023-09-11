using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExercise.Classes
{
    public class UIControl
    {
        protected readonly DialogBox owner;

        public UIControl(DialogBox owner)
        {
            this.owner = owner;
        }
    }
}
