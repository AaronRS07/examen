using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Menu
    {
        private Empleados[] empleados = new Empleados[10];
        private int contador = 0; 

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú Principal =):");
                Console.WriteLine("1. Agregar Empleados:");
                Console.WriteLine("2. Consultar Empleados:");
                Console.WriteLine("3. Modificar Empleados:");
                Console.WriteLine("4. Borrar Empleados:");
                Console.WriteLine("5. Inicializar Arreglos:");
                Console.WriteLine("6. Reportes:");
                Console.WriteLine("7. Salir:");
                Console.Write("Seleccione una opción...: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        ConsultarEmpleado();
                        break;
                    case 3:
                        ModificarEmpleado();
                        break;
                    case 4:
                        BorrarEmpleado();
                        break;
                    case 5:
                        InicializarArreglos();
                        break;
                    case 6:
                        MostrarReportes();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 0);
        }

        private void AgregarEmpleado()
        {
            if (contador >= 10)
            {
                Console.WriteLine("No se pueden agregar más empleados, llenaste el numero de empleados a agregar =(");
                return;
            }

            Console.Write("Ingrese cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese salario: ");
            int salario = int.Parse(Console.ReadLine());

            empleados[contador] = new Empleados(cedula, nombre, direccion, telefono, salario);
            contador++;
            Console.WriteLine("Se agrego exitosamente el empleado =)...");
        }

        private void ConsultarEmpleado()
        {
            Console.Write("Ingresa la cedula del empleado a consultar :...");
            string cedula = Console.ReadLine();
            Empleados empleado = Array.Find(empleados, e => e != null && e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private void ModificarEmpleado()
        {
            Console.Write("Ingrese cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            Empleados empleado = Array.Find(empleados, e => e != null && e.Cedula == cedula);
            if (empleado != null)
            {
                Console.Write("Ingrese nuevo nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Ingrese una nueva dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Ingresa un nuevo numero de telefono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Ingresa un nuevo salario: ");
                empleado.Salario = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Empleado modificado exitosamente, saludos =)....");
            }
            else
            {
                Console.WriteLine("No encontramos a este empleado =(");
            }
        }

        private void BorrarEmpleado()
        {
            Console.Write("Ingrese cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            int index = Array.FindIndex(empleados, e => e != null && e.Cedula == cedula);

            if (index != -1)
            {
                empleados[index] = null; 
                Console.WriteLine("Empleado borrado exitosamente.");
               
                for (int i = index; i < contador - 1; i++)
                {
                    empleados[i] = empleados[i + 1];
                }
                empleados[contador - 1] = null; 
                contador--;
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private void InicializarArreglos()
        {
            empleados = new Empleados[10]; 
            contador = 0;


        }
        private void MostrarReportes()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay empleados para mostrar.");
                return;
            }

            Console.WriteLine("Lista de Empleados:");
            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Salario: {empleado.Salario}");
                }
            }

                                       //Hola profe, lo de calcular el promedio del salario se me complico un poco y por eso no lo hice =(
            double sumaSalarios = 0;
            int cantidadSalarios = 0;

            if (cantidadSalarios > 0)
            {
                double promedioSalarios = sumaSalarios / cantidadSalarios;
                Console.WriteLine($"Promedio de salarios: {promedioSalarios}");
            }
            else
            {
                Console.WriteLine("No se pudo calcular el promedio de salarios.");
            }
        }
    }
}