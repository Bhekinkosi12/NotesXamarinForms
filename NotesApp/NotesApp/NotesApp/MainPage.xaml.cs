using System;
using System.IO;
using Xamarin.Forms;

namespace NotesApp
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NotesApp.txt");
       public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }

        } 
        void SalvarAoClicar (object sander,EventArgs eventArgs)
        {
            File.WriteAllText(_fileName, editor.Text);
        }
        void DeletarAoClicar(object sander, EventArgs eventArgs)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }
    }
}