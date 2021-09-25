using System;

namespace INGRESAR_DATOS
{
    class Programa_cliente
    {
        public struct cliente
        {
            public String cedula_cliente;
            public String nombre_cliente;
            public String tipo_cuenta;
            public String numero_cuenta;
            public String direccion_cliente;
            public String telefono_cliente;
            public String email_cliente;
            public String genero;
            public String ocupacion;
            public String estadocivil_cliente;
            public DateTime fecha_nacimiento;
            public String estado;
        }

        enum genero { masculino, femenino }
        enum estadocivil { casado, soltero, union_libre, divorciado }
        enum Estadocuenta { activo, eliminado, inactivo }
        enum tipocuenta { ahorro, corriente }

        const int tope = 2;
        static cliente[] lista = new cliente[tope];
        static int contador = 0;
        static void Main(string[] args)
        {
            menu();
        }

        public static void menu()
        {
            int opcion;

            Console.WriteLine("***Menu de Opciones***");
            Console.WriteLine("1.-Ingrese Datos del Cliente");
            Console.WriteLine("2.-Consultar");
            Console.WriteLine("3.-Modificar");
            Console.WriteLine("4.-Eliminar Cliente");
            Console.WriteLine("5.-Salir");
            do
            {
                Console.WriteLine("Ingrese la Opcion :");
                opcion = int.Parse(Console.ReadLine());
                if (opcion <= 0 || opcion >= 6)
                {
                    Console.WriteLine("Ingrese una opcion Valida ");
                }
            } while (opcion > 5);
            switch (opcion)
            {
                case 1: ingresardatos(); break;
                case 2: consultardatos(); break;
                case 3: modificardatos(); break;
                case 4: eliminardatos(); break;
            }
        }

        public static void ingresardatos()
        {
            for (int i = contador; i < tope; i++)
            {
                Console.WriteLine("Ingreso de datos del cliente " + (i + 1));

                Console.WriteLine("Ingrese numero de cedula :");
                lista[i].cedula_cliente = Console.ReadLine();

                Console.WriteLine("Ingrese el Nombre :");
                lista[i].nombre_cliente = Console.ReadLine();

                Console.WriteLine("Ingrese el tipo de cuenta :");
                lista[i].tipo_cuenta = Console.ReadLine();

                Console.WriteLine("Ingrese numero de cuenta :");
                lista[i].numero_cuenta = Console.ReadLine();

                Console.WriteLine("Ingrese la direccion :");
                lista[i].direccion_cliente = Console.ReadLine();

                Console.WriteLine("Ingrese el telefono :");
                lista[i].telefono_cliente = Console.ReadLine();

                Console.WriteLine("Ingrese el E-mail :");
                lista[i].email_cliente = Console.ReadLine();

                Console.WriteLine("Ingrese su Ocupacion :");
                lista[i].ocupacion = Console.ReadLine();

                Console.WriteLine("Ingrese el estado civil :");
                lista[i].estadocivil_cliente = Console.ReadLine();

                Console.WriteLine("Ingrese el Genero :");
                lista[i].genero = Console.ReadLine();

                Console.WriteLine("Ingrese La Fecha de Nacimiento :");
                lista[i].fecha_nacimiento = DateTime.Parse(Console.ReadLine());

                lista[i].estado = Estadocuenta.activo.ToString();

                contador++;

                if (contador > tope)
                {
                    Console.WriteLine("Valor macimo para ingresar alcanzado");
                    break;
                }

            }

            menu();
        }
        public static void consultardatos()
        {
            for (int i = 0; i < tope; i++)
            {
                if (lista[i].estado.Equals("activo") || lista[i].estado.Equals("inactivo"))
                {
                    Console.WriteLine("Consulta del Cliente ");
                    Console.WriteLine("Cedula           : " + lista[i].cedula_cliente);
                    Console.WriteLine("Nombre           : " + lista[i].nombre_cliente);
                    Console.WriteLine("Tipo de Cuenta   : " + lista[i].tipo_cuenta);
                    Console.WriteLine("Numero de Cuenta : " + lista[i].numero_cuenta);
                    Console.WriteLine("Dirección        : " + lista[i].direccion_cliente);
                    Console.WriteLine("Telefono         : " + lista[i].telefono_cliente);
                    Console.WriteLine("E-mail           : " + lista[i].email_cliente);
                    Console.WriteLine("Genero           : " + lista[i].genero);
                    Console.WriteLine("Ocupación        : " + lista[i].ocupacion);
                    Console.WriteLine("Estado Civil     : " + lista[i].estadocivil_cliente);
                    Console.WriteLine("Fecha Nac.       : " + lista[i].fecha_nacimiento);
                } else
                {
                    Console.WriteLine("No hay datos");
                }
            }
            menu();
        }

        public static void eliminardatos()
        {
            string dato = "";
            Console.WriteLine("Ingrese numero de cedula a eliminar");
            dato = Console.ReadLine();

            for(int i = 0; i < lista.Length; i++)
            {
                if (lista[i].cedula_cliente.Equals(dato))
                lista[i].estado = Estadocuenta.eliminado.ToString();
                else
                    Console.WriteLine("El numero de cedula no existe");
            }

            menu();
        }

        public static void modificardatos()
        {
            string respuesta = "";
            string nvcedula, nvnombre, nvtpcuenta, nvestadocuenta, nvdireccion, nvtelefono, nvemail, nvgenero, nvocupacion, nvestcivil, nvfchnac;
            int nuevodato = 0;
            do
            {

                Console.WriteLine("Desea Modificar los datos del Cliente");
                respuesta = Console.ReadLine();
                respuesta = respuesta.ToUpper();

                if (respuesta.Equals("SI"))
                {
                    if (nuevodato >= 0 && nuevodato < lista.Length)
                    {
                        Console.WriteLine("Ingrese el nuevo numero de cedula del Cliente: " + lista[nuevodato].cedula_cliente);
                        nvcedula = Console.ReadLine();
                        lista[nuevodato].cedula_cliente = nvcedula;

                        Console.WriteLine("Ingrese el nuevo Nombre del Cliente: " + lista[nuevodato].nombre_cliente);
                        nvnombre = Console.ReadLine();
                        lista[nuevodato].nombre_cliente = nvnombre;

                        Console.WriteLine("Ingrese el nuevo Numero de Cuenta del Cliente: " + lista[nuevodato].numero_cuenta);
                        nvtpcuenta = Console.ReadLine();
                        lista[nuevodato].numero_cuenta = nvtpcuenta;

                        Console.WriteLine("Ingrese el nuevo tipo de Cuenta del Cliente: " + lista[nuevodato].tipo_cuenta);
                        nvtpcuenta = seleccionarTipocuenta();
                        lista[nuevodato].tipo_cuenta = nvtpcuenta;

                        Console.WriteLine("Ingrese La nueva Direccion del Cliente: " + lista[nuevodato].direccion_cliente);
                        nvdireccion = Console.ReadLine();
                        lista[nuevodato].direccion_cliente = nvdireccion;

                        Console.WriteLine("Ingrese el nuevo Telefono del Cliente: " + lista[nuevodato].telefono_cliente);
                        nvtelefono = Console.ReadLine();
                        lista[nuevodato].telefono_cliente = nvtelefono;

                        Console.WriteLine("Ingrese el nuevo E-mail del Cliente: " + lista[nuevodato].email_cliente);
                        nvemail = Console.ReadLine();
                        lista[nuevodato].email_cliente = nvemail;

                        Console.WriteLine("Ingrese el Nuevo Genero: " + lista[nuevodato].genero);
                        nvgenero = seleccionargenero();
                        lista[nuevodato].genero = nvgenero;

                        Console.WriteLine("Ingrese la nueva Ocupacion: " + lista[nuevodato].ocupacion);
                        nvocupacion = Console.ReadLine();
                        lista[nuevodato].ocupacion = nvocupacion;

                        Console.WriteLine("Ingrese el nuevo Estado Civil: " + lista[nuevodato].estadocivil_cliente);
                        nvestcivil = seleccionarestadocivil();
                        lista[nuevodato].estadocivil_cliente = nvestcivil;

                        Console.WriteLine("Ingrese la nueva Fecha de Nacimiento: " + lista[nuevodato].fecha_nacimiento);
                        nvfchnac = Console.ReadLine();
                        lista[nuevodato].fecha_nacimiento = Convert.ToDateTime(nvfchnac);

                        Console.WriteLine("Ingrese el nuevo Estado de Cuenta: " + lista[nuevodato].estado);
                        nvestadocuenta = seleccionarestado();
                        lista[nuevodato].estado = nvestadocuenta;
                    }
                    else if (respuesta.Equals("No"))
                    {
                        Console.WriteLine("Gracias por su atención");
                    }
                }
            } while (respuesta.Equals("SI"));
            menu();
        }
        public static string seleccionarTipocuenta()
        {
            int opcion = 0;
            string cuenta = "";

            Console.WriteLine("Seleccione : 1.- Cuenta de ahorro   2.- Cuenta corriente");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                cuenta = tipocuenta.ahorro.ToString();
            }
            else if (opcion == 2)
            {
                cuenta = tipocuenta.corriente.ToString();
            }
            return cuenta;
        }
        public static string seleccionarestadocivil()
        {
            int opcion = 0;
            string estadoc = "";

            Console.WriteLine("Seleccionar : 1.- Casado  2.- Soltero  3.- Union_libre  4.- Divorciado");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: estadoc = estadocivil.casado.ToString(); break;
                case 2: estadoc = estadocivil.soltero.ToString(); break;
                case 3: estadoc = estadocivil.union_libre.ToString(); break;
                case 4: estadoc = estadocivil.divorciado.ToString(); break;
            }
            return estadoc;
        }

        public static string seleccionargenero()
        {
            int opcion = 0;
            string acc = "";

            Console.WriteLine("Seleccione el genero :  1.- Masculino  2.- Femenino");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                acc = genero.masculino.ToString();
            }
            else if (opcion == 2)
            {
                acc = genero.femenino.ToString();
            }
            return acc;
        }

        public static string seleccionarestado()
        {
            int opcion = 0;
            string ess = "";

            Console.WriteLine("Seleccione una opcion : 1.- activo  2.- eliminado  3.- inactivo");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                ess = Estadocuenta.activo.ToString();
            }
            else if (opcion == 2)
            {
                ess = Estadocuenta.eliminado.ToString();
            }
            else if (opcion == 3)
            {
                ess = Estadocuenta.inactivo.ToString();
            }
            return ess;
        }
    }
}
