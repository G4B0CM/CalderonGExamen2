namespace CalderonGExamen2;

public partial class TodasLasRecargas : ContentPage
{
	public TodasLasRecargas()
	{
		InitializeComponent();
        BindingContext = new Models.TodasRecargas();
    }
    protected override void OnAppearing()
    {
        ((Models.TodasRecargas)BindingContext).cargarRecarga();
    }
}