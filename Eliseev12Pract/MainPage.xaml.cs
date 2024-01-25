using Newtonsoft.Json;

namespace Eliseev12Pract
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        bool isEdit = false;
        int indexOfCountry = -1;

        private void OnSaveClicked(object sender, EventArgs e)
        {
            if (isEdit)
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "countriess.json");
                string updatejson = File.ReadAllText(filePath);
                List<Country> existingCountries = new List<Country>();
                existingCountries = JsonConvert.DeserializeObject<List<Country>>(updatejson);
                Country editedCountry = existingCountries[indexOfCountry];

                //Student editedStudent = existingStudents[existingStudents.IndexOf(student)];
                editedCountry.Name = entrNameCountry.Text;
                editedCountry.Сurrency = entrCurrency.Text;
                editedCountry.Population = int.Parse(entrPopulation.Text);
                editedCountry.Capital = entrCapital.Text;


                string updatedJson = JsonConvert.SerializeObject(existingCountries);
                File.WriteAllText(filePath, updatedJson);
                isEdit = false;
            }
            else
            {
                // Создайте нового студента
                Country newCountry = new Country
                {
                    Capital = entrCapital.Text,
                    Name = entrNameCountry.Text,
                    Population = int.Parse(entrPopulation.Text),

                    Сurrency = entrCurrency.Text,
                };

                // Проверьте, существует ли файл JSON
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "countriess.json");
                List<Country> existingCountries = new List<Country>();

                if (File.Exists(filePath))
                {
                    // Если файл существует, загрузите существующие данные
                    string json = File.ReadAllText(filePath);
                    existingCountries = JsonConvert.DeserializeObject<List<Country>>(json);
                }

                // Добавьте нового студента к существующим данным
                existingCountries.Add(newCountry);

                // Сохраните обновленные данные в файл JSON
                string updatedJson = JsonConvert.SerializeObject(existingCountries);
                File.WriteAllText(filePath, updatedJson);

                // Очистите поля ввода
                entrCapital.Text = string.Empty;
                entrNameCountry.Text = string.Empty;
                entrPopulation.Text = string.Empty;
                //myPhoto.IsToggled = false; 

                entrCurrency.Text = string.Empty;
            }
        }

        private void goToListViewClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListViewPage());
        }

        public void Edit(Country country, int index)
        {
            entrNameCountry.Text = country.Name;
            entrPopulation.Text = Convert.ToString(country.Population);
            entrCurrency.Text = Convert.ToString(country.Сurrency);
            entrCapital.Text = Convert.ToString(country.Capital);
            isEdit = true;
            indexOfCountry = index;
        }



    }

    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Сurrency { get; set; }
        public int Population { get; set; }

    }
}


