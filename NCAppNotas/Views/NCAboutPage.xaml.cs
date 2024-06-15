namespace NCAppNotas.Views;

public partial class NCAboutPage : ContentPage
{
    public NCAboutPage()
    {
        InitializeComponent();
    }
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is NCModels.NCAbout about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}