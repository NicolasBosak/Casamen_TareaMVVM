namespace NCAppNotas.Views;

public partial class NCAllNotesPage : ContentPage
{
    public NCAllNotesPage()
    {
        InitializeComponent();

        BindingContext = new NCModels.NCAllNotes();
    }

    protected override void OnAppearing()
    {
        ((NCModels.NCAllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NCNotePage1));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (NCModels.NCNote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NCNotePage1)}?{nameof(NCNotePage1.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}