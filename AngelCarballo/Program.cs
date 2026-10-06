using System;

// SOLUCIÓN AL CASO: Crisis en Admisiones del Hospital San Rafael (Ruta B)
// Cédula terminada en 5 -> Tamaño máximo de vectores N = 5 + 10 = 15

class Program
{
    static void Main()
    {
        // Límite exacto de memoria en base al último dígito del carné (5 + 10 = 15)
        const int N = 15;

        // Estructuras de vectores sincronizados por índice para nombres y niveles de gravedad
        string[] nombres = new string[N];
        int[] gravedad = new int[N];

        int tot = 0; // Contador de registros activos en memoria temporal
        int opc = 0; // Control de menú principal

        // Menú para gestionar la emergencia
        while (opc != 5)
        {
            Console.Write("\n=== HOSPITAL SAN RAFAEL: AISLAMIENTO CRÍTICO ===\n1.Ingresar  2.Ver  3.Modificar  4.Alta  5.Salir\nOpcion: ");
            int.TryParse(Console.ReadLine(), out opc);

            // OPCIÓN 1: Registrar paciente y su nivel de urgencia/gravedad
            if (opc == 1)
            {
                if (tot < N)
                {
                    Console.Write("Nombre del paciente: ");
                    nombres[tot] = Console.ReadLine();

                    // Validación del nivel de gravedad (Rango exigido: 1 al 5)
                    int nivel = 0;
                    do
                    {
                        Console.Write("Nivel de Gravedad (1 a 5): ");
                        int.TryParse(Console.ReadLine(), out nivel);
                        if (nivel < 1 || nivel > 5)
                        {
                            Console.WriteLine(" Error: El nivel de gravedad debe ser entre 1 y 5.");
                        }
                    } while (nivel < 1 || nivel > 5);

                    gravedad[tot] = nivel;
                    tot++;
                    Console.WriteLine(" Paciente registrado con éxito.");
                }
                else
                {
                    Console.WriteLine(" ERROR: Capacidad máxima alcanzada en memoria.");
                }
            }
            // OPCIÓN 2: Generar reporte/consulta limpia de pacientes activos
            else if (opc == 2)
            {
                if (tot == 0)
                {
                    Console.WriteLine("No hay pacientes registrados en el área.");
                }
                else
                {
                    Console.WriteLine("\n--- LISTA DE PACIENTES REGISTRADOS ---");
                    for (int i = 0; i < tot; i++)
                    {
                        Console.WriteLine($"{i + 1}. {nombres[i]} - Gravedad: {gravedad[i]}");
                    }
                }
            }
            // OPCIÓN 3: Modificar la gravedad cuando un paciente empeora o mejora
            else if (opc == 3)
            {
                Console.Write("Posición a modificar: ");
                int.TryParse(Console.ReadLine(), out int pos);

                if (pos >= 1 && pos <= tot)
                {
                    int nGrav = 0;
                    do
                    {
                        Console.Write($"Nueva Gravedad (1 a 5) para {nombres[pos - 1]}: ");
                        int.TryParse(Console.ReadLine(), out nGrav);
                    } while (nGrav < 1 || nGrav > 5);

                    gravedad[pos - 1] = nGrav;
                    Console.WriteLine(" Gravedad actualizada correctamente.");
                }
                else
                {
                    Console.WriteLine(" Posición no válida.");
                }
            }
            // OPCIÓN 4: Dar de alta y realizar desplazamiento para mantener sincronía
            else if (opc == 4)
            {
                Console.Write("Posición a dar de alta: ");
                int.TryParse(Console.ReadLine(), out int pos);

                if (pos >= 1 && pos <= tot)
                {
                    Console.WriteLine($" Paciente {nombres[pos - 1]} dado de alta.");

                    // Desplazamiento a la izquierda para no perder la sincronía de los vectores
                    for (int i = pos - 1; i < tot - 1; i++)
                    {
                        nombres[i] = nombres[i + 1];
                        gravedad[i] = gravedad[i + 1];
                    }
                    tot--;
                    Console.WriteLine(" Registro limpiado exitosamente.");
                }
                else
                {
                    Console.WriteLine(" Posición no válida.");
                }
            }
        }
    }
}