using System;
using System.Collections.Generic;
using System.Net.Mail;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialEntryPage : ContentPage
    {
        public MaterialEntryPage()
        {
            InitializeComponent();

            this.emailField.TextChanged += EmailField_TextChanged;
        }

        private void EmailField_TextChanged(object sender, EventArgs e)
        {
            this.emailField.AssistiveText = this.IsValid(this.emailField.Text) ? string.Empty : "The Email Address is in an invalid format.";
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
