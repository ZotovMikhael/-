using System.ComponentModel;

namespace Kursovaya;

public partial class ProfilePage : ContentPage
{
    private static string? currentUser;
    public static string? CurrentUser
    {
        get => currentUser;
        private set
        {
            if (currentUser != value)
            {
                currentUser = value;
                OnCurrentUserChanged?.Invoke(value);
            }
        }
    }

    public static event Action<string?>? OnCurrentUserChanged;

    public ProfilePage()
    {
        InitializeComponent();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (string.IsNullOrEmpty(CurrentUser))
        {
            // Показываем форму входа
            LoginForm.IsVisible = true;
            UserInfoPanel.IsVisible = false;
        }
        else
        {
            // Показываем информацию о пользователе
            LoginForm.IsVisible = false;
            UserInfoPanel.IsVisible = true;
            UserNameLabel.Text = $"Пользователь: {CurrentUser}";
        }
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Ошибка", "Введите имя пользователя", "OK");
            return;
        }

        CurrentUser = NameEntry.Text;
        UpdateUI();
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        CurrentUser = null;
        UpdateUI();
    }
} 