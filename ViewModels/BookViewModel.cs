using Assignment_12._3._2.Data;
using Assignment_12._3._2.Models;
using Assignment_12._3._2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12._3._2.ViewModels
{
    public partial class BookViewModel : ObservableObject
    {
        public ObservableCollection<Book> QueriedBooks { get; set; }
        public ObservableCollection<Book> SavedBooks { get; set; }
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private string author;

        private readonly BookContext bookContext;
        private readonly BookRetrievalService bookRetrievalService;

        public BookViewModel(BookContext context, BookRetrievalService service)
        {
            bookRetrievalService = service;
            bookContext = context;
            QueriedBooks = [];
            SavedBooks = [];

            QueriedBooks.Add(new Book() { key = "123654", author_name = ["Isaac Asimov"], title = "I robot" });

            foreach (var book in bookContext.Books)
            {
                SavedBooks.Add(book);
            }
        }
        [RelayCommand]
        private async void QueryBook()
        {
            if (QueriedBooks.Count > 0) QueriedBooks.Clear();
            //get book from OpenLibrary API
            var books = await bookRetrievalService.FindBookAsync(title: Title, author: Author);
            foreach (var book in books)
            {
                QueriedBooks.Add(book);
            }
        }
        [RelayCommand]
        private async void AddBook(Book book)
        {
            //add to SavedBooks
            //add to bookContext.books

            if (bookContext.Books.Contains(book))
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Cannot add: Database already contains book with primary key {book.key}!", "OK");
                return;
            }

            try
            {
                SavedBooks.Add(book);
                QueriedBooks.Remove(book);
                await bookContext.Books.AddAsync(book);
                await bookContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
        }
        [RelayCommand]
        private async void EditBook(Book book)
        {
            try
            {
                var index = SavedBooks.IndexOf(book);
                var title = await App.Current.MainPage.DisplayPromptAsync("Edit", "Edit title", initialValue: book.title);
                if (!string.IsNullOrWhiteSpace(title))
                {
                    book.title = title;
                    bookContext.Books.Update(book);
                    bookContext.SaveChanges();
                    SavedBooks[index] = book;
                }
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
        }
        [RelayCommand]
        private async void DeleteBook(Book book)
        {
            //remove from SavedBooks
            //remove from bookContext.Books

            SavedBooks.Remove(book);
            bookContext.Books.Remove(book);
            await bookContext.SaveChangesAsync();
        }
    }
}
