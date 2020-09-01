using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    class Persona
    {
        int id;
        string nombre;
        string apellido;
        string documento;
        char sexo;
        DateTime nacimiento;

        public Persona() { }
        public void IngresarPersona()
        {
            //Persona persona = new Persona();
            Console.Write("ID:");
            while (!int.TryParse(Console.ReadLine(), out this.id)) { 
                Console.Write("Error, vuelva a ingresar ID:"); 
            }
            Console.Write("Nombre:");
            this.nombre = Console.ReadLine();
            Console.Write("Apellido:");
            this.apellido = Console.ReadLine();
            Console.Write("Documento:");
            this.documento = Console.ReadLine();
            Console.Write("Sexo(M/F):");
            while(!char.TryParse(Console.ReadLine(), out this.sexo)) //TODO: verificar sexo
            {
                Console.Write("Error, vuelva a ingresar sexo(M/F):");
            }
            Console.Write("Fecha de nacimiento:");
            while(!DateTime.TryParse(Console.ReadLine(),out this.nacimiento)){ //TODO: arreglar formato fecha --> pag 257
                Console.Write("Error, vuelva a ingresar fecha de nacimiento:");
            }

            Archivo archivo = new Archivo();
            archivo.AgregarPersonaArchivo(this.id,this.nombre,this.apellido,this.documento,this.sexo,this.nacimiento); //TODO: ver el pasaje de argumentos

            Console.WriteLine("Persona ingresada con exito..");

            
        }

        public void BorrarPersona()
        {
            String archivo = @"\FACU_fer\labo\personas.txt";

            Console.WriteLine("Ingrese ID a borrar:");
            String id = Console.ReadLine();

            string[] lineas = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo);
            for (int i = 0; i < lineas.Length; i++)
            {
                int indice = lineas[i].IndexOf(";");
                string Columna = lineas[i].Substring(0, indice);
                if (Columna.Equals(id))
                {
                    lineas[i] = "*"+ lineas[i];
                    break;
                }
            }
            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo, lineas);
            Carpeta.borrar();
        }

        public void ListarPersonas()
        {
            String archivo = @"\FACU_fer\labo\personas.txt";
            try
            {
                using(StreamReader streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo))
                {
                    string linea;
                    while((linea = streamReader.ReadLine()) != null)
                    {
                        if (!linea.Contains("*")) 
                        {
                            Console.WriteLine(linea);
                        }
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo leer el archivo");
                Console.WriteLine(e.Message);
            }
            Carpeta.borrar();
        }

        public void BuscarPersona()
        {
            String archivo = @"\FACU_fer\labo\personas.txt";

            Console.WriteLine("Ingrese ID a buscar:");
            String id = Console.ReadLine();

            try
            {
                using (StreamReader streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + archivo))
                {
                    string linea;
                    while ((linea = streamReader.ReadLine()) != null)
                    {
                        int indice = linea.IndexOf(";");
                        string Columna = linea.Substring(0, indice);
                        if (Columna.Equals(id))
                        {
                            Console.WriteLine(linea);
                            Carpeta.borrar();
                            return;
                        }
                    }
                    Console.WriteLine("Persona no encontrada");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo leer el archivo");
                Console.WriteLine(e.Message);
            }
            Carpeta.borrar();
        }

    }
}
