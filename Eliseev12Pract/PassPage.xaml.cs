using System.Text;

namespace Eliseev12Pract
{
    public partial class PassPage : ContentPage
    {
        private StringBuilder codeBuilder = new StringBuilder();

        public PassPage()
        {
            InitializeComponent();
        }

        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (codeBuilder.Length < 4)
                {
                    codeBuilder.Append(button.Text);
                    UpdatePasswordLabel();
                }
            }
        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            codeBuilder.Clear();
            UpdatePasswordLabel();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            if (codeBuilder.Length == 4)
            {
                string enteredCode = codeBuilder.ToString();

                if (enteredCode == "2534")
                {
                    // ������� �� ��������� �������� ��� ���������� ������ ��������
                    Navigation.PushAsync(new MainPage());
                    DisplayAlert("�����", "���� �������� �������!", "OK");
                }
                else
                {
                    DisplayAlert("������", "�������� ������", "OK");
                }
            }
            else
            {
                DisplayAlert("������", "����������, ������� 4 �����", "OK");
            }
        }

        private void UpdatePasswordLabel()
        {
            PasswordLabel.Text = new string('*', codeBuilder.Length);
        }
    }
}
