namespace NCAppNotas.Views;

public partial class NCAllNotesPage : ContentPage
{
    public NCAllNotesPage()
    {
        InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}