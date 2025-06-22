using Microsoft.AspNetCore.Components.Forms;

namespace Hoteldia.Servicios
{
    public class SubidaArchivo : ISubida
    {
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly IConfiguration _configuration;

        public SubidaArchivo(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnviroment = webHostEnvironment;
            _configuration = configuration;
        }

        public bool BorrarArchivo(string nombreArchivo)
        {
            try
            {
                //Vamos a pillar el directorio raiz, el nombre de la carpeta de imgs y pasamos el nombre del archivo
                var path = $"{_webHostEnviroment.WebRootPath}\\Imagenes\\{nombreArchivo}";
                //Si existe el path
                if (File.Exists(path))
                {
                    //Borramos el archivo
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SubirArchivo(IBrowserFile browserFile)
        {
            try
            {
                FileInfo info = new FileInfo(browserFile.Name);
                var fileName = Guid.NewGuid().ToString() + info.Extension;

                var folderDirectory = Path.Combine(_webHostEnviroment.WebRootPath, "Imagenes");
                var path = Path.Combine(folderDirectory, fileName);

                // Asegúrate de que el directorio exista
                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                var memory = new MemoryStream();

                // IMPORTANTE: aumentar tamaño permitido
                await browserFile.OpenReadStream(maxAllowedSize: 1024 * 1024 * 15)
                    .CopyToAsync(memory);

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memory.WriteTo(fs);
                }

                var url = _configuration.GetValue<string>("ServerUrl");
                var fullPath = $"{url}Imagenes/{fileName}";

                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al subir archivo: {ex.Message}");
                throw;
            }
        }

    }
}
