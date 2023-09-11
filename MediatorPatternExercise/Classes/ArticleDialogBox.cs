using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExercise.Classes
{
    public class ArticleDialogBox : DialogBox
    {
        private readonly Button button;
        private readonly TextBox textBox;
        private readonly ListBox listBox;

        public ArticleDialogBox()
        {
            button = new Button(this);
            textBox = new TextBox(this);
            listBox = new ListBox(this);
        }

        public void simulateUserInteraction()
        {
            listBox.Selected = "New Selection";
            Console.WriteLine($"Button: {button.Activated} TextBox:{textBox.Content} ListBox:{listBox.Selected}");
            listBox.Selected = "";
            Console.WriteLine($"Button: {button.Activated} TextBox:{textBox.Content} ListBox:{listBox.Selected}");
        }

        public override void Changed(UIControl control)
        {
            if (control == textBox)
                TextBoxChanged();
            else if (control == listBox)
                ListBoxChanged();
        }

        private void ListBoxChanged()
        {
            if(listBox.Selected !="")
            {
                textBox.Content = listBox.Selected;
                button.Activated = true;
            }
            else
            {
                textBox.Content = listBox.Selected;
                button.Activated = false;
            }
        }

        private void TextBoxChanged()
        {
            if (textBox.Content != "")
                button.Activated = true;
        }
    }
}
