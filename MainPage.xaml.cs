using Assignment_12._3._2.Data;
using Assignment_12._3._2.Models;
using Assignment_12._3._2.Services;
using System.Collections.ObjectModel;
using Assignment_12._3._2.ViewModels;

namespace Assignment_12._3._2
{
    public partial class MainPage : ContentPage
    {
        public MainPage(BookViewModel bookViewModel)
        {
            InitializeComponent();
            BindingContext = bookViewModel;
        }

        private async void OnSaveBook(object sender, EventArgs e)
        {
            // bookContext.Books.Add(data bound book);
            await DisplayAlert("Save Book", $"Books saved!", "OK");
        }

        private async void OnDeleteBook(object sender, EventArgs e)
        {
            // bookContext.Books.Remove(data bound book);
            await DisplayAlert("Delete Book", "Book deleted!", "OK");
        }

        private async void OnFindBook(object sender, EventArgs e)
        {
            // get books from OpenLibrary API
            await DisplayAlert("Find Book", "Book found!", "OK");
        }
    }

}
