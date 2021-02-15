using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;

namespace NotesApp
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var notes = new List<Note>();

        //    var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
        //    // Monta uma lista
        //    foreach (var filename in files)
        //    {
        //        notes.Add(new Note
        //        {
        //            FileName = filename,
        //            Text = File.ReadAllText(filename),
        //            Date = File.GetCreationTime(filename)
        //        });
        //    }
        //    listView.ItemsSource = notes.OrderBy(d => d.Date).ToList();
        //}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }
        async void OnNoteAddedClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs eventArgs)
        {
            if (eventArgs.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = eventArgs.SelectedItem as Note
                });
            }
        }

    }
}