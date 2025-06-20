using Microsoft.AspNetCore.Components.Forms;

namespace Hoteldia.Servicios
{
    public interface ISubida
    {

        Task<string> SubirArchivo(IBrowserFile browserFile);

        bool BorrarArchivo(string nombreArchivo);
    }
}
