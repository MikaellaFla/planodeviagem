using System;
using Microsoft.Maui.Controls;
using SQLite;

namespace PlanejamentoDeViagem
{
    public partial class RegisterPage : ContentPage
    {
        SQLiteConnection conexao;

        public RegisterPage()
        {
            InitializeComponent();
            string caminhoBD = System.IO.Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, "usuarios.db3");
            conexao = new SQLiteConnection(caminhoBD);
            conexao.CreateTable<Usuario>();  // Cria��o da tabela de usu�rios
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;

            if (IsValidRegistration(username))
            {
                string pin = GeneratePin();
                Usuario usuario = new Usuario { Username = username, Pin = pin };
                conexao.Insert(usuario);

                await DisplayAlert("Sucesso", $"Cadastro realizado com sucesso! Seu PIN �: {pin}", "OK");
                await Navigation.PopAsync(); // Voltar para a p�gina de boas-vindas
            }
            else
            {
                await DisplayAlert("Erro", "Usu�rio j� existe ou dados inv�lidos.", "OK");
            }
        }

        private bool IsValidRegistration(string username)
        {
            // Verifica se o usu�rio j� existe no banco de dados
            var user = conexao.Table<Usuario>().FirstOrDefault(u => u.Username == username);
            return user == null && username.Length > 3;
        }

        private string GeneratePin()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();  // Gera um PIN aleat�rio de 6 d�gitos
        }
    }
}
