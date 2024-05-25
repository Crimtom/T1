using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio #1

            // Declara las variables
            string cedula;
            string nombre_empleado = "";
            int tipo_empleado; // 1 = Operario; 2 = Técnico; 3 = Profesional;
            double horas_trabajadas;
            double hora_precio;
            double aumento;

            //Salarios
            double salario_ordi;
            double salario_bruto;
            double salario_neto;
            double deduccion_CCSS;

            double salario_neto_OP;
            double salario_neto_TEC;
            double salario_neto_PRO;
            

            // Declara los arreglos
            string[] Operarios = new string[255];   // Cantidad de cada tipo de empleado
            string[] Tecnicos = new string[255];
            string[] Profesionales = new string[255];

            double[] salneto_OP_Acumulado = new double[255];
            double[] salneto_TEC_Acumulado = new double[255];
            double[] salneto_PRO_Acumulado = new double[255];

            // Menú
            bool salir = false;
            int menu_decision;

            while (salir != true)
            {
                // Presenta el menú
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+-----[Aumentos salariales]-----+");
                Console.WriteLine("|                               |");
                Console.WriteLine("|         Bienvenido/a          |");
                Console.WriteLine("|      ¿Desea añadir datos      |");
                Console.WriteLine("| o revizar los ya existentes?  |");
                Console.WriteLine("|                               |");
                Console.WriteLine("+-------------------------------+");
                Console.WriteLine("(1) Añadir datos.");
                Console.WriteLine("(2) Revizar los datos presentes.");
                Console.WriteLine("(3) Salir del programa.");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ingrese el número correspondiente a la opción deseada: ");
                    menu_decision = int.Parse(Console.ReadLine());

                    switch (menu_decision)
                    {
                        case 1:
                            anadir_datos();
                            break;

                        case 3:
                            salir = true;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("SE HA PRODUCIDO UN ERROR DEBIDO A QUE SE INGRESÓ UN VALOR INVÁLIDO");
                }

            }

            void anadir_datos()
            {
                int paso = 0;
                try
                {
                    Console.Clear();
                    // Solicita la cédula
                    while (paso == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Por favor, ingrese su cédula: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        cedula = Console.ReadLine();
                        bool cedula_num = cedula.All(char.IsDigit);
                        if (cedula.Length == 9)
                        {
                            if (cedula_num == true)
                            {
                                paso++;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("NÚMERO DE CÉDULA INVÁLIDO. SOLO SE ADMITEN DIGITOS NUMÉRICOS");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NÚMERO DE CÉDULA INVÁLIDO. DEBE SER DE 9 DIGITOS");
                        }
                    }
                    
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SE HA PRODUCIDO UN ERROR");
                }

                //Solicita el nombre del empleado
                Console.Clear();

                while (paso == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Por favor, ingrese su nombre: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    nombre_empleado = Console.ReadLine();
                    bool name_letters = nombre_empleado.All(char.IsLetter);
                    switch (name_letters)
                    {
                        case true:
                            paso++;
                            break;
                        case false:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El nombre ingresado no es válido. Absténgase de emplear números.");
                            break;
                    }
                }

                // Solicita el tipo de empleado
                Console.Clear();

                while (paso == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("+-----[Tipos de empleados]-----+");
                    Console.WriteLine("|                              |");
                    Console.WriteLine("|  (1) Operario.               |");
                    Console.WriteLine("|  (2) Técnico.                |");
                    Console.WriteLine("|  (3) Profesional.            |");
                    Console.WriteLine("|                              |");
                    Console.WriteLine("+------------------------------+");

                    try
                    {
                        Console.WriteLine("Por favor, digite el número correspondiente al tipo de empleado que le corresponde: ");
                        tipo_empleado = int.Parse(Console.ReadLine());
                        if (tipo_empleado > 0 && tipo_empleado < 4)
                        {
                            switch (tipo_empleado)
                            {
                                case 1:
                                    for (int i = 0; i <= 255; i++)
                                    {
                                        if (Operarios[i] == null)
                                        {
                                            Operarios[i] = nombre_empleado;
                                            i = 256;
                                            paso++;
                                        }
                                        else if (i == 255)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("NO HAY ESPACIOS PARA NUEVOS EMPLEADOS DE TIPO OPERARIO");
                                        }
                                    }
                                    break;

                                case 2:
                                    for (int i = 0; i <= 255; i++)
                                    {
                                        if (Tecnicos[i] == null)
                                        {
                                            Tecnicos[i] = nombre_empleado;
                                            i = 256;
                                            paso++;
                                        }
                                        else if (i == 255)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("NO HAY ESPACIOS PARA NUEVOS EMPLEADOS DE TIPO TÉCNICO");
                                        }
                                    }
                                    break;

                                case 3:
                                    for (int i = 0; i <= 255; i++)
                                    {
                                        if (Profesionales[i] == null)
                                        {
                                            Profesionales[i] = nombre_empleado;
                                            i = 256;
                                            paso++;
                                        }
                                        else if (i == 255)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("NO HAY ESPACIOS PARA NUEVOS EMPLEADOS DE TIPO PROFESIONAL");
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                    }

                }

                //Solicita las horas trabajadas
                Console.Clear();

                while (paso == 3)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Por favor, digite el número correspondiente a la cantidad de horas laboradas: ");

                    }
                }
            }
        }
    }
}
