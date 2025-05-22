namespace creativexpression;

public partial class CadastroVendas : ContentPage
{
	public CadastroVendas()
	{
		InitializeComponent();
	}

    private void Salvar_Clicked(object sender, EventArgs e)
    {
		Venda v = new Venda();
		v.id = int.Parse(EntryId.Text);
		v.usuario_id = int.Parse(EntryUsuario_id.Text);
		v.Insere();

		EntryId.Text = "";
		EntryUsuario_id.Text = ""; 

		Shell.Current.GoToAsync("ListagemVendas");


    }
}