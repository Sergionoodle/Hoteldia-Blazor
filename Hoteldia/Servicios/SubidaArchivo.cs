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
                //Para que no repitamos el nombre + la extension del file
                var fileName = Guid.NewGuid().ToString() + info.Extension;
                var folderDirectory = $"{_webHostEnviroment.WebRootPath}\\Imagenes";
                var path = Path.Combine(_webHostEnviroment.WebRootPath, "Imagenes", fileName);

                var memory = new MemoryStream();

                await browserFile.OpenReadStream().CopyToAsync(memory);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memory.WriteTo(fs);
                }

                var url = $"{_configuration.GetValue<string>("ServerUrl")}";
                var fullPath = $"{url}Imagenes/{fileName}";

                return fullPath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
