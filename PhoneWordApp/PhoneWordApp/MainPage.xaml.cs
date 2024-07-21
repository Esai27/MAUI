namespace PhoneWordApp
{
    public partial class MainPage : ContentPage
    {
        string translatedString;

        public MainPage()
        {
            InitializeComponent();
        }

        private void transalteButton_Clicked(object sender, EventArgs e)
        {
            var enteredString = phoneWordEntry.Text;
            translatedString = PhoneWordTranslator.ToNumber(enteredString);
            phoneWordEntry.Text = translatedString;

            if (!string.IsNullOrEmpty(translatedString))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedString;
            }
            else
            {
                callButton.Text = "Call";
            }

        }

        async void callButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                "would you like to call " + translatedString,
                "OK",
                "Cancel"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(translatedString);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid", "Ok");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing failing", "Ok");
                }

            }

            phoneWordEntry.Text = string.Empty;
            callButton.Text = "Call";
        }

    }
}
