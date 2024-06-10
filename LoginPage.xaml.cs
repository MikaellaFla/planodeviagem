using SQLite;

namespace PlanejamentoDeViagem
{
    public partial class LoginPage : ContentPage
    {
        SQLiteConnection conexao;

        public LoginPage()
        {
            InitializeComponent();
            string caminhoBD = System.IO.Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, "usuarios.db3");
            conexao = new SQLiteConnection(caminhoBD);
            conexao.CreateTable<Usuario>();  // Certifica-se de que a tabela de usu�rios exista
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string pin = TxtPin.Text;

            if (IsValidLogin(username, pin))
            {
                await DisplayAlert("Sucesso", "Login bem-sucedido!", "OK");
                // Navega para a p�gina principal ou outra p�gina ap�s login bem-sucedido
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Erro", "Nome de usu�rio ou PIN incorretos", "OK");
            }
        }

        private bool IsValidLogin(string username, string pin)
        {
            // Verifica se o usu�rio e PIN existem no banco de dados
            var user = conexao.Table<Usuario>().FirstOrDefault(u => u.Username == username && u.Pin == pin);
            return user != null;
        }
    }
}
