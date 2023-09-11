using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExercise.Classes
{
    public class Button: UIControl
    {
        protected readonly DialogBox owner;
        public Button(DialogBox owner) : base(owner)
        {
            this.owner = owner;
        }

        private bool activated;

        public bool Activated
        {
            get { return activated;
                
            }
            set { activated = value; owner.Changed(this); }
        }


    }
}
