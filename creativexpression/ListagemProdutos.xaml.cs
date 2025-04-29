namespace creativexpression;

public partial class ListagemProdutos : ContentPage
{
	public ListagemProdutos()
	{
		InitializeComponent();

		

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Produto p = new Produto();
        Lista.ItemsSource = null;
        Lista.ItemsSource = p.BuscaTodos();

    }

}