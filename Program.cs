using System.Net;
using System.Diagnostics;

namespace RepasoHilos
{
    internal class Program
    {

        static void Main()
        {
            int opcion = -1;
            string urlDownload;
            bool downloadCompleted;
            Dictionary<string, bool> urlsUsadas = new Dictionary<string, bool>();
            while (opcion != 0)
            {
                Console.WriteLine("1- Añadir descargas \n");
                Console.WriteLine("2- Listar descargas \n");
                Console.WriteLine("3- Limpiar descargas completadas \n");
                Console.WriteLine("0- Salir \n");
                opcion = Int32.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("URL? \n");
                        urlDownload = Console.ReadLine();
                        Download(urlDownload);
                        //Añadir hilo para descarga en segundo plano
                        break;

                    case 2:
                        Console.WriteLine("Mostrar estado de la descarga y tiempo o progreso");
                        foreach (var item in urlsUsadas)
                        {
                            Console.WriteLine($"URL: {item.Key}, STATE: {item.Value}");
                        }
                        break;

                    case 3:
                        Console.WriteLine("eliminar listado de descrgas");
                        urlsUsadas.Clear();
                        break;
                }
            }
            void Download(string url)
            {
                Console.WriteLine("Downloading: " + url);
                WebClient client = new WebClient();
                byte[] data = client.DownloadData(url);
                string filename = Path.GetFileName(url);
                bool downloadStarted = true;
                if (isDownloading(downloadStarted))
                {
                    urlsUsadas.Add(url, true);
                }
                File.WriteAllBytes(filename, data);
                Console.WriteLine("Saved file: " + filename);

            }
            bool isDownloading(bool downloadStarted)
            {
                return true;
            }
        }

    }
}
