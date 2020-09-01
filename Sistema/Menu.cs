using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema
{
    class Menu
    {
        String[] opciones =  //hardcodeado ~ hardcoding
        {
            "1. Verificar Carpeta",
            "2. Crear Carpeta",
            "3. Borrar Carpeta",
            "4. Ingresar Persona",
            "5. Borrar Persona",
            "6. Listar Personas",
            "7. Buscar Persona",
            "8. Salir"
        };
        public Menu() 
        {
            Carpeta carpeta = new Carpeta();
            Persona persona = new Persona();
            while (true)
            {
                ImprimirMenu();
                if (int.TryParse(ElegirOpcion(), out int opcion)){
                    Console.Clear();
                    switch (opcion)
                    {
                        case 1:
                            carpeta.VerificarCarpeta();
                            break;
                        case 2:
                            carpeta.CrearCarpeta();
                            break;
                        case 3:
                            carpeta.BorrarCarpeta();
                            break;
                        case 4:
                            
                            persona.IngresarPersona();
                            break;
                        case 5:
                            persona.BorrarPersona();
                            break;
                        case 6:
                            persona.ListarPersonas();
                            break;
                        case 7:
                            persona.BuscarPersona();
                            break;
                        case 8:
                            Salir();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion invalida..");
                }
                
            }   
        }
        private void ImprimirMenu()
        {
            foreach(String opcion in opciones)
            {
                Console.WriteLine(opcion);
            }
        }
        private string ElegirOpcion()
        {
            Console.Write("Elija una opcion:");
            return Console.ReadLine();
        }
        private void Salir()
        {
            Console.Clear();
            Console.WriteLine("Saliendo...");
            Thread.Sleep(2500);
            Environment.Exit(0);
        }
    }
}
