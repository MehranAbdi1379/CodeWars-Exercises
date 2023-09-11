using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern.MediatorPackageElements
{
    public class SpecialElementsPackage
    {
        public Button Button { get; set; }
        public TextBox TextBox { get; set; }
        public ListBox ListBox { get; set; }

        public SpecialElementsPackage(Button button, TextBox textBox, ListBox listBox)
        {
            Button = button;
            TextBox = textBox;
            ListBox = listBox;
            button.Enabled = false;
        }

        public void SelectListBox(string selected)
        {
                TextBox.Text = selected;
                Button.Enabled = true;
        }
    }
}
