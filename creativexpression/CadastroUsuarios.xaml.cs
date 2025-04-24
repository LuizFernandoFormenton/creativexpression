using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace creativexpression;

public partial class CadastroUsuarios : ContentPage
{
	public CadastroUsuarios()
	{
		InitializeComponent();
	}

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Usuario u = new Usuario();
        u.nome = EntryNome.Text;
        u.data_nascimento = string.Join("-", EntryDataNascimento.Date.ToString().Split(" ")[0].Split("/").Reverse());
        u.sexo = int.Parse(EntrySexo.Text);
        u.senha = EntrySenha.Text;
        u.email = EntryEmail.Text;
        u.cpf = EntryCpf.Text;
        u.telefone = EntryTelefone.Text;
        u.cep = EntryCep.Text;
        u.Insere();

        EntryNome.Text = "";
        //EntryDataNascimento.Date = "";
        EntrySexo.Text = "";
        EntrySenha.Text = "";
        EntryEmail.Text = "";
        EntryCpf.Text = "";
        EntryTelefone.Text = "";
        EntryCep.Text = "";

    }
}