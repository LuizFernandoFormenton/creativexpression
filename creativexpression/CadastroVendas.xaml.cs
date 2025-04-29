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
		v.id_transacao = int.Parse(EntryId_transacao.Text);
		v.id_produto = int.Parse(EntryId_produto.Text);
		v.quantidade = int.Parse(EntryQuantidade.Text);
		v.Insere();

		EntryId_transacao.Text = "";
		EntryId_produto.Text = "";
		EntryQuantidade.Text = "";

		Shell.Current.GoToAsync("ListagemVendas");


    }
}