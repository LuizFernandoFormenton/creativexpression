namespace creativexpression;

public partial class CadastroProdutos : ContentPage
{
	public CadastroProdutos()
	{
		InitializeComponent();
     
    }

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Produto p = new Produto();
        p.nome_do_produto = EntryNome.Text;
        p.preco = float.Parse(EntryPreco.Text);
        p.tamanho = EntryTamanho.Text;
        p.Insere();

        EntryNome.Text = "";
        EntryPreco.Text = "";
        EntryTamanho.Text = "";

         Shell.Current.GoToAsync("ListagemProdutos");
    }

   
}