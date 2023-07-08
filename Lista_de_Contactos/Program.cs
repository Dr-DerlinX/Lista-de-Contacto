using System;
using System.IO;

namespace Lista_de_Contactos
{
    static class Program
    {
        static long contador = 0;
        static string operador, linea, nombre, telef, correo, buscar, siono;

        static string[] nombreContacto = new string[1000];
        static string[] telefContacto = new string[1000];
        static string[] correoContacto = new string[1000];

        static int i = 0, e = 0;
        static void Main(string[] args)
        {
            StreamWriter dat;
            StreamReader inicio;

            if (!File.Exists("listContactos1.dat"))
            {
                dat = File.CreateText("listContactos1.dat");
                dat.Close();
            }
            else
            {
                inicio = File.OpenText("listContactos1.dat");

                do
                {
                    linea = inicio.ReadLine();
                    nombreContacto[i] = linea;
                    telefContacto[i] = linea;
                    correoContacto[i] = linea;
                    i += 1;
                    contador += 1;

                } while (linea != null);
                inicio.Close();
                contador -= 1;
                Console.WriteLine("{0}", contador);
            }

            do
            {
                Console.WriteLine("------Lista de Contactos---------");

                Console.WriteLine("--Agregar nuevo contacto--           1 ");
                Console.WriteLine("");
                Console.WriteLine("--Mostar contactos--                 2 ");
                Console.WriteLine("");
                Console.WriteLine("--Buscar contactos--                 3 ");
                Console.WriteLine("");
                Console.WriteLine("--Eliminar contactos--               4 ");
                Console.WriteLine("");
                Console.WriteLine("--Eliminar Lista de contacto--       5 ");


                operador = Convert.ToString(Console.ReadLine());

                if (operador == "1") { newContacto(); }
                    if (operador == "2") { mostrarContactos(); }
                         if (operador == "3") { buscarContacto(); }
                            if(operador == "4") { eliminarContacto(); }
                                if (operador == "5") { borrarList(); }

                Console.Clear();

            } while (true);
        }

        static void newContacto()
        {
            StreamWriter datos;

            Console.Clear();

            Console.WriteLine("Nombre :");
            nombre = Convert.ToString(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Teleono : ");
            telef = Convert.ToString(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Correo : ");
            correo = Convert.ToString(Console.ReadLine());

            nombreContacto[contador] = nombre;
            telefContacto[contador] = telef;
            correoContacto[contador] = correo;

            datos = File.AppendText("listContactos1.dat");
            datos.WriteLine("{0} , {1}, {2}",
                nombreContacto[contador], telefContacto[contador], correoContacto[contador]);
            datos.Close();

            contador += 1;
        }

        static void mostrarContactos()
        {
            Console.Clear();
            Console.WriteLine("------Lista de Contacto------");
            Console.WriteLine("");

            StreamReader rdatos;

            rdatos = File.OpenText("listContactos1.dat");
            Console.WriteLine("Nombre :  Telefono :   Correo:");
            do
            {
                linea = rdatos.ReadLine();
                if (linea != null)
                {
                    Console.WriteLine(linea);
                }
            } while (linea != null);
            rdatos.Close();
            Console.WriteLine("");
            Console.ReadLine();
        }

        static void buscarContacto()
        {
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("Introdusca su sombre , numero , o correo para buscar!");
                buscar = Convert.ToString(Console.ReadLine());

                for (int i = 0; i < contador; i++)
                {
                    if (nombreContacto[i].IndexOf(buscar) >= 0 ||
                        telefContacto[i].IndexOf(buscar) >= 0 ||
                        correoContacto[i].IndexOf(buscar) >= 0)
                    {
                        Console.WriteLine("{0}",
                            nombreContacto[i]);
                    }
                }

                Console.WriteLine("Buscar nuevo contacto :1 no");
                buscar = Convert.ToString(Console.ReadLine());

            } while (buscar != "no");

            Console.ReadLine();
        }

        static void eliminarContacto()
        {
            //este metodo no funciona correcta mente!!
            StreamWriter datoss;
            StreamWriter dat;

            Console.Clear();
            Console.WriteLine("Introdusca su sombre , numero , o correo para buscar!");
            buscar = Convert.ToString(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (nombreContacto[i].IndexOf(buscar) >= 0)
                {
                    int s;
                    for (s = i; s < contador - 1; s++)
                    {
                        nombreContacto[s] = nombreContacto[s + 1];
                        contador--;
                        nombreContacto[contador] = "";
                    }
                } 
            }
            siono = Convert.ToString(Console.ReadLine());
            dat = File.CreateText("listContactos1.dat");
            dat.Close();

            for (int e = 0; e < contador; e++)
            {
                datoss = File.AppendText("listContactos1.dat");
                datoss.WriteLine("{0}", nombreContacto[e]);
                datoss.Close();
            }
            Console.WriteLine("Contacto Eliminado correcta mente!!");
            Console.ReadLine();
        }

        static void borrarList()
        {
            Console.Clear();
            StreamWriter dat;
            Console.WriteLine("Eliminal Lista de contacto : Y - Si || N - no");
            siono = Convert.ToString(Console.ReadLine());

            if (siono == "y")
            {
                dat = File.CreateText("listContactos1.dat");
                dat.Close();

                Array.Clear(nombreContacto, 0, nombreContacto.Length);
                contador = 0;
            }
        }
    }
}
