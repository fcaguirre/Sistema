using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Archivo
    {
        public Archivo() { }
        public void AgregarPersonaArchivo(int id, string nombre, string apellido, string documento, char sexo, DateTime nacimiento)
        {
            String Sid = id.ToString();
            String Snacimiento = nacimiento.ToString();

            String archivo = @"\FACU_fer\labo\personas.txt";
            FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo, FileMode.Append);
            //TODO acceder al nombre de la carpeta por clase, no directamente
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(Sid.ToString()), 0, Sid.ToString().Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes("; "), 0, ("; ").Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(nombre), 0, nombre.Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes("; "), 0, ("; ").Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(apellido), 0, apellido.Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes("; "), 0, ("; ").Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(documento), 0, documento.Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes("; "), 0, ("; ").Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(Snacimiento), 0, Snacimiento.Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes("; "), 0, ("; ").Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(sexo.ToString()), 0, sexo.ToString().Length);
            fileStream.Write(ASCIIEncoding.ASCII.GetBytes(Environment.NewLine), 0, (Environment.NewLine).Length);
            
            fileStream.Close();

        }
    }
}
