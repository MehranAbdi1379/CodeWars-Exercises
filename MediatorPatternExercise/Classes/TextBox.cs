using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExercise.Classes
{
    public class TextBox : UIControl
    {
        protected readonly DialogBox owner;
        public TextBox(DialogBox owner) : base(owner)
        {
            this.owner = owner;
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value;
                owner.Changed(this);
            }
        }

    }
}
