namespace creativexpression;

public partial class ListagemVendas : ContentPage
{
    public ListagemVendas()
    {
        InitializeComponent();



    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Venda v = new Venda();
        Lista.ItemsSource = null;
        Lista.ItemsSource = v.BuscaTodos();

    }

}