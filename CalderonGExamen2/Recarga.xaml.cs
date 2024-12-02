namespace CalderonGExamen2;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class Recarga : ContentPage
{
    public string ItemId
    {
        set { CargarRecargas(value); }
    }
    string _fileNameNombres = Path.Combine(FileSystem.AppDataDirectory, "GabrielCalderon2.txt");
    public Recarga()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.GabrielCalderon2.txt";

        CargarRecargas(Path.Combine(appDataPath, randomFileName));
        
    }
    
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Recarga recarga)
        {
            File.WriteAllText(recarga.Filename, GabrielC_editor1.Text +" \n " + GabrielC_editor2.Text);
           
        }
            
        await Shell.Current.GoToAsync("..");
    }
   

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Recarga recarga)
        {
            // Delete the file.
            if (File.Exists(recarga.Filename))
                File.Delete(recarga.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void CargarRecargas(string fileName)
    {
        Models.Recarga recargaModelo = new Models.Recarga();
        recargaModelo.Filename = fileName;

        if (File.Exists(fileName))
        {
            recargaModelo.Date = File.GetCreationTime(fileName);
            recargaModelo.nombre = File.ReadAllText(fileName);
        }

        BindingContext = recargaModelo;
    }
    private void irARecargas(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TodasLasRecargas());
    }


}