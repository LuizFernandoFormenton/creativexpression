using System;
using Microsoft.Maui.Controls;
    
namespace creativexpression
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Evento acionado ao clicar no botão "Entrar"
        private async void OnEntrarClicked(object sender, EventArgs e)
        {
            // Exemplo de navegação para a página de listagem de usuários
            await Navigation.PushAsync(new ListagemUsuarios());
        }
    }
}

