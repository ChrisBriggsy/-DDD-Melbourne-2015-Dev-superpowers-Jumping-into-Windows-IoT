using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IoTBackUp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Display();
        }

        private async void Display()
        {
            var data = await GetData();
            Temperature.Text = data.main.temp.ToString();
            Humdity.Text = data.main.humidity.ToString();
        }

        public async Task<OpenWeatherMapData> GetData()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=Melbourne&units=metric");
            return JsonConvert.DeserializeObject<OpenWeatherMapData>(await response.Content.ReadAsStringAsync());
        }
    }
}
