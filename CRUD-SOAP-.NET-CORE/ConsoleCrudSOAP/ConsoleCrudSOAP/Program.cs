using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCrudSOAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new ServiceReference1.WebServiceSoapClient();
                bool continuar = true;

                while (continuar)
                {
                    Console.Clear();
                    Console.WriteLine("Gestor de Pacientes - CRUD");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("1. Agregar Paciente");
                    Console.WriteLine("2. Obtener Todos los Pacientes");
                    Console.WriteLine("3. Actualizar Paciente");
                    Console.WriteLine("4. Eliminar Paciente");
                    Console.WriteLine("5. Salir");
                    Console.Write("Seleccione una opción: ");

                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.Write("Ingrese el nombre del paciente: ");
                            var nombre = Console.ReadLine();
                            Console.Write("Ingrese la edad del paciente: ");
                            var edad = int.Parse(Console.ReadLine());

                            var respuestaAgregar = client.AgregarPaciente(nombre, edad);
                            Console.WriteLine(respuestaAgregar);
                            break;

                        case "2":
                            Console.WriteLine("\nLista de Pacientes:");
                            var pacientes = client.ObtenerPacientes();
                            foreach (var paciente in pacientes)
                            {
                                Console.WriteLine($"Id: {paciente.Id}, Nombre: {paciente.Name}, Edad: {paciente.Age}");
                            }
                            break;

                        case "3":
                            Console.Write("Ingrese el ID del paciente a actualizar: ");
                            var idActualizar = int.Parse(Console.ReadLine());
                            Console.Write("Ingrese el nuevo nombre del paciente: ");
                            var nuevoNombre = Console.ReadLine();
                            Console.Write("Ingrese la nueva edad del paciente: ");
                            var nuevaEdad = int.Parse(Console.ReadLine());

                            var respuestaActualizar = client.ActualizarPaciente(idActualizar, nuevoNombre, nuevaEdad);
                            Console.WriteLine(respuestaActualizar);
                            break;

                        case "4":
                            Console.Write("Ingrese el ID del paciente a eliminar: ");
                            var idEliminar = int.Parse(Console.ReadLine());

                            var respuestaEliminar = client.EliminarPaciente(idEliminar);
                            Console.WriteLine(respuestaEliminar);
                            break;

                        case "5":
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }

                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consumir el servicio: " + ex.Message);
            }

            Console.WriteLine("\nPrograma finalizado. Presione Enter para salir.");
            Console.ReadLine();
        }
    }
}
