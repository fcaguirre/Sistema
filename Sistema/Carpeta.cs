using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Carpeta
    {
        string nombre = @"\FACU_fer\labo";
        string carpeta;
        //TODO: verificar try/catch
        public Carpeta()
        {
            this.carpeta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + this.nombre;
        }
        public Boolean VerificarCarpeta()
        {
            if (!Directory.Exists(this.carpeta))
            {
                Console.WriteLine("No existe la carpeta {0}", this.carpeta);
                return false;
            }
            else
            {
                Console.WriteLine("Existe la carpeta {0}", this.carpeta);
                return true;
            }
        }

        public void CrearCarpeta()
        {
            if (this.VerificarCarpeta())
            {
                Console.WriteLine("Ya existe la carpeta {0}", this.carpeta);
                return;
            }
            DirectoryInfo di = Directory.CreateDirectory(this.carpeta);
            Console.WriteLine("{0} creado Ok", this.carpeta);
        }

        public void BorrarCarpeta()
        {
            if (!this.VerificarCarpeta()) // que devuelve Directory.Existe(..)? un booleano
            {
                Console.WriteLine("No existe la carpeta {0}", this.carpeta);
                return;
            }
            try
            {
                foreach (string file in Directory.GetFiles(this.carpeta))
                {
                    File.Delete(file);
                }
                Directory.Delete(this.carpeta); //no borra todo
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.WriteLine("{0} borrada Ok", this.carpeta);
        }
    }
}
