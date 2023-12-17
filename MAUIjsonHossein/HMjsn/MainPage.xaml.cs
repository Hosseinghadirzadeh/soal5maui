using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace HMjsn
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<TodoItem> todoItems;

        public MainPage()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            string apiUrl = "https://jsonplaceholder.typicode.com/todos";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(apiUrl);
            todoItems = JsonSerializer.Deserialize<ObservableCollection<TodoItem>>(json);
            todoCollectionView.ItemsSource = todoItems;
        }
    }

    public class TodoItem
    {
        [JsonPropertyName("userId")]
        public int PostId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("completed")]
        public Boolean Completed { get; set; }
    }
}
