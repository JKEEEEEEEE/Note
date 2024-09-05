using front_note.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace front_note.Services
{
	public class ApiService
	{
		private readonly HttpClient _httpClient;

		public ApiService()
		{
			_httpClient = new HttpClient
			{
				BaseAddress = new System.Uri("https://localhost:7231/api/")
			};
		}

		public async Task<List<Note>> GetNotesAsync()
		{
			var response = await _httpClient.GetStringAsync("notes");
			return JsonConvert.DeserializeObject<List<Note>>(response);
		}

		public async Task<Note> GetNoteByIdAsync(int id)
		{
			var response = await _httpClient.GetStringAsync($"notes/{id}");
			return JsonConvert.DeserializeObject<Note>(response);
		}

		public async Task CreateNoteAsync(Note note)
		{
			var content = new StringContent(JsonConvert.SerializeObject(note), System.Text.Encoding.UTF8, "application/json");
			await _httpClient.PostAsync("notes", content);
		}

		public async Task UpdateNoteAsync(Note note)
		{
			var content = new StringContent(JsonConvert.SerializeObject(note), System.Text.Encoding.UTF8, "application/json");
			await _httpClient.PutAsync($"notes/{note.Id}", content);
		}

		public async Task DeleteNoteAsync(int id)
		{
			await _httpClient.DeleteAsync($"notes/{id}");
		}
	}
}
