using caltamiranoT7.Models;
using System.Net;
using System.Text;
namespace caltamiranoT7.Vista;
public partial class vActualizarEliminar : ContentPage
{
    private Estudiantes objectestudiante;
    public vActualizarEliminar(Estudiantes datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }
    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            // Construye los datos a enviar para la actualización
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            // Construye la URL incluyendo el código del estudiante
            string url = $"http://192.168.2.2/moviles/appmovil/post.php?codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad.Text}";
            // Realiza la solicitud PUT con los datos actualizados
            byte[] respuesta = cliente.UploadValues(url, "PUT", parametros);
            // Convierte la respuesta a una cadena (opcional, dependiendo de tus necesidades)
            string respuestaString = System.Text.Encoding.UTF8.GetString(respuesta);

            // Una vez actualizado, regresa a la página principal
            Navigation.PushAsync(new Vista.vHome());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }
     private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            // Construye la URL incluyendo el código del estudiante
            string url = $"http://192.168.2.2/moviles/appmovil/post.php?codigo={txtCodigo.Text}";
            // Realiza la solicitud DELETE
            cliente.UploadString(url, "DELETE", "");
            // Una vez eliminado, regresa a la página principal
            Navigation.PushAsync(new Vista.vHome());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }
}
