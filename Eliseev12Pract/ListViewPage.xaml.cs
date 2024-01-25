using Newtonsoft.Json;

namespace Eliseev12Pract;

public partial class ListViewPage : ContentPage
{
    private List<Country> countries;
    public ListViewPage()
    {
        InitializeComponent();
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "countriess.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            countries = JsonConvert.DeserializeObject<List<Country>>(json);
            CountriesListView.ItemsSource = countries;
        }
    }

    private void Load_Clicked(object sender, EventArgs e)
    {
        Refresh();
    }

    private void Remove_Clicked(object sender, EventArgs e)
    {
        if (CountriesListView.SelectedItem != null)
        {
            countries.Remove(CountriesListView.SelectedItem as Country);
        }
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "countriess.json");
        string json = JsonConvert.SerializeObject(countries);
        File.WriteAllText(filePath, json);
        Refresh();
    }

    private void Refresh()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "countriess.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            countries = JsonConvert.DeserializeObject<List<Country>>(json);
            CountriesListView.ItemsSource = countries;
        }
    }

    private void Edit_Clicked(object sender, EventArgs e)
    {
        if (CountriesListView.SelectedItem != null)
        {
            MainPage mainPage = new MainPage();
            mainPage.Edit(CountriesListView.SelectedItem as Country, countries.IndexOf(CountriesListView.SelectedItem as Country));
            Navigation.PushAsync(mainPage);
        }
    }

}