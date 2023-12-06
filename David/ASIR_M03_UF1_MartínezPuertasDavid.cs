using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASIR_M03_UF1_MartinezPuertasDavid_Solucion
{
    internal class SolucionPlantilla
    {

        static void Main(string[] args)
        {
            //--- Declaracion de variables
            int numero = 0;
            int[] sec_fibo;


            //------------------------------------------------------------------------------------------ Ejecución libre del programa

            //-------------------------- Se valida que el número introducido sea correcto
            do
            {
                Console.Write("Inserta el número elementos de Fibonacci a calcular: ");
                numero = Int32.Parse(Console.ReadLine());

            } while (NumeroValido(numero) == false);

            //-------------------------- Se obtiene la secuencia Fibonacci
            sec_fibo = SecuenciaFibo(numero);

            //-------------------------- Se obtiene la secuencia Fibonacci invertida
            sec_fibo = SecuenciaReverse(sec_fibo);

            //-------------------------- Se obtiene la primera posición donde aparece el número que más veces está en el array
            Console.WriteLine(PosicionNumeroMasVisto(sec_fibo));

            //--- Fin de la ejecución del programa
            Console.ReadKey();
        }

        public static bool NumeroValido(int numero)
        {
            if (numero > 2 & numero < 21)
            {
                return true;
                //Se valida el número introducido
            }
            else
            {
                Console.Write("El número introducido no es válido");
                return false;
            }
        }

        public static int[] SecuenciaFibo(int numero)
        {
            // Se definen tres variables para realizar las operaciones del calculo de la secuencia de Fibonacci.
            int v1 = 0;
            int v2 = 1;
            int[] sec_fibo_fin = new int[numero];
            for (int i = 0; i < numero; i++)
            {
                int temp = v1;
                v1 = v2;
                v2 = temp + v1;
                sec_fibo_fin[i] = v1;

            }
            // Debug: Console.WriteLine("[{0}]", string.Join(", ", sec_fibo_fin));
            return sec_fibo_fin;

        }

        public static int[] SecuenciaReverse(int[] directo)
        {
            // Cojo el valor de directo que proviene de sec_fibo y le doy la vuelta con la función Reverse.
            Array.Reverse(directo);
            // Debug: Console.WriteLine("[{0}]", string.Join(", ", directo));
            return directo;
        }

        public static string PosicionNumeroMasVisto(int[] arr_secuencia)
        {
            //Se inicializan variables

            int posicion = 0;
            int valor = 0;
            int recuento = 0;

            //Se crea una matriz para albergar una estructura clave-valor la cual muestra el valor como clave y el numero que se repite como valor

            int[,] frecuencia = new int[arr_secuencia.Length, 2];

            //Se recorre todo el arr_secuencia para contabilizar posicion, valor y recuento.

            foreach (var item in arr_secuencia)
            {
                bool encontrado = false;

                for (int i = 0; i < arr_secuencia.Length; i++)
                {
                    if (frecuencia[i, 0] == item && frecuencia[i, 1] > 0)
                    {
                        frecuencia[i, 1]++;
                        encontrado = true;
                        if (frecuencia[i, 1] > recuento)
                        {
                            recuento = frecuencia[i, 1];
                            valor = item;
                            posicion = i;
                        }
                        break;
                    }
                    else if (frecuencia[i, 1] == 0)
                    {
                        frecuencia[i, 0] = item;
                        frecuencia[i, 1] = 1;
                        encontrado = true;
                        if (recuento == 0)
                        {
                            recuento = 1;
                            valor = item;
                            posicion = i;
                        }
                        break;
                    }
                }
                if (!encontrado)
                {
                    Console.WriteLine("No hay espacio en el array bidimensional");
                }

            }
            /* Esta es otra forma mas complicada que he encontrado investigando por internet.
             * 
             * 
             * Dictionary<int, int> diccRecuentos = new Dictionary<int, int>();


            for (int i = 0; i < arr_secuencia.Length; i++)
            {
                if (diccRecuentos.ContainsKey(arr_secuencia[i]))
                {
                    diccRecuentos[arr_secuencia[i]]++;
                }
                else
                {
                    diccRecuentos[arr_secuencia[i]] = 1;
                }

                if (diccRecuentos[arr_secuencia[i]] > recuento)
                {
                    recuento = diccRecuentos[arr_secuencia[i]];
                    valor = arr_secuencia[i];
                    posicion = i;
                }
            }

            String textBox3 = "";

            foreach (KeyValuePair<int, int> kvp in diccRecuentos)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                textBox3 += string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine(textBox3);*/

            if (recuento > 1)
            {
                return "El valor " + valor + " se repite " + recuento + " veces según la posicion " + posicion + " del array bidimensional.";
            }
            else
            {
                return "Todos los valores de la secuencia aparecen por igual.";
            }
        }
    }
}