using front_note.Models;
using front_note.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace front_note
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ApiService _apiService;
		private Note _selectedNote;

		public MainWindow()
		{
			InitializeComponent();
			_apiService = new ApiService();
			LoadNotes();
		}

		private async void LoadNotes()
		{
			var notes = await _apiService.GetNotesAsync();
			NotesListBox.ItemsSource = notes;
		}

		private void NotesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			_selectedNote = NotesListBox.SelectedItem as Note;
			if (_selectedNote != null)
			{
				TitleTextBox.Text = _selectedNote.Title;
				ContentTextBox.Text = _selectedNote.Content;
			}
		}

		private async void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedNote == null)
			{
				var newNote = new Note
				{
					Title = TitleTextBox.Text,
					Content = ContentTextBox.Text,
				};
				await _apiService.CreateNoteAsync(newNote);
			}
			else
			{
				_selectedNote.Title = TitleTextBox.Text;
				_selectedNote.Content = ContentTextBox.Text;
				await _apiService.UpdateNoteAsync(_selectedNote);
			}
			LoadNotes();
		}

		private async void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			if (_selectedNote != null)
			{
				await _apiService.DeleteNoteAsync(_selectedNote.Id);
				LoadNotes();
			}
		}
	}
}
