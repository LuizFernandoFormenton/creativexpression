namespace creativexpression;

public partial class ListagemUsuarios : ContentPage
{
	public ListagemUsuarios()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Usuario u = new Usuario();
        Lista.ItemsSource = null;
        Lista.ItemsSource = u.BuscaTodos();

    }

}