using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExercise.Classes
{
    public class ListBox : UIControl
    {
        protected readonly DialogBox owner;
        public ListBox(DialogBox owner) : base(owner)
        {
            this.owner= owner;
        }

        private string selected;

        public string Selected
        {
            get { return selected; }
            set { selected = value; owner.Changed(this); }
        }

    }
}
