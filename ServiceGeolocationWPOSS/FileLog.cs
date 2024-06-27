using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGeolocationWPOSS
{
    public class FileLog
    {
        public static void WriteLog(string msg)
        {
            string filePath = "C:/Users/aleja/logprueba.txt"; // Ruta del archivo que deseas modificar

            // Verificar si el archivo existe
            if (File.Exists(filePath))
            {
                // Lee el contenido actual del archivo
                string contenido = File.ReadAllText(filePath);

                // Modifica el contenido como desees
                contenido += "\n" + msg;

                // Sobrescribe el archivo con el contenido modificado
                File.WriteAllText(filePath, contenido);

                Console.WriteLine("Archivo modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }

        }

    }
}
