using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using NCAppNotas.NCModels;

namespace NCAppNotas.NCViewModels
{
    internal class NCNotesViewModel
    {

        public ObservableCollection<NCViewModels.NCNoteViewModel> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }

        public NCNotesViewModel()
        {
            AllNotes = new ObservableCollection<NCViewModels.NCNoteViewModel>(NCModels.NCNote.LoadAll().Select(n => new NCNoteViewModel(n)));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<NCViewModels.NCNoteViewModel>(SelectNoteAsync);
        }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.NCNotePage1));
        }

        private async Task SelectNoteAsync(NCViewModels.NCNoteViewModel note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.NCNotePage1)}?load={note.Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                NCNoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                NCNoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                    matchedNote.Reload();

                // If note isn't found, it's new; add it.
                else
                    AllNotes.Add(new NCNoteViewModel(NCNote.Load(noteId)));
            }
        }
    }
}