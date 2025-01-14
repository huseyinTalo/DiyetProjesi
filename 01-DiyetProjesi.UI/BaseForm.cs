using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DiyetProjesi.UI
{
    public class BaseForm : Form
    {
        protected readonly UIMetotlari _uiMetotlari;

        protected BaseForm()
        {
            _uiMetotlari = new UIMetotlari();
        }

        protected string GetUserEmailFromOwner()
        {
            foreach (Control ctrl in Owner?.Controls ?? Array.Empty<Control>())
            {
                if (ctrl is GroupBox gb)
                {
                    var emailTextBox = gb.Controls.OfType<TextBox>()
                        .FirstOrDefault(tb => tb.Name == "tbEmail");
                    if (emailTextBox != null)
                        return emailTextBox.Text;
                }
            }
            return string.Empty;
        }

        protected void HandleFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
