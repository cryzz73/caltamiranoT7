using System.Net;

namespace caltamiranoT7.Vista;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();

            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            cliente.UploadValues("http://192.168.2.2/moviles/appmovil/post.php", "POST", parametros);
            Navigation.PushAsync(new Vista.vHome());
        }
        catch (Exception ex)
        {

            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }
}