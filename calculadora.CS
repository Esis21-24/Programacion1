using System.Globalization;

double LeerNumero(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (double.TryParse(Console.ReadLine()?.Replace(',', '.'), NumberStyles.Float,
                            CultureInfo.InvariantCulture, out double n))
            return n;
        Console.WriteLine("Error: escriba un número válido.");
    }
}

string opcion = "";
while (opcion != "0") 
{
    Console.WriteLine("\n1. Sumar  2. Restar  3. Multiplicar  4. Dividir  5. Estudiante  0. Salir");
    Console.Write("Opción: ");
    opcion = Console.ReadLine()?.Trim() ?? "";

    switch (opcion)
    {
        case "1": case "2": case "3": case "4":
        {
            double a = LeerNumero("Primer número: ");
            double b = LeerNumero("Segundo número: ");

            if (opcion == "4" && b == 0)
                Console.WriteLine("Error: no se puede dividir entre cero.");
            else
                Console.WriteLine("Resultado: " + (opcion switch
                {
                    "1" => a + b,
                    "2" => a - b,
                    "3" => a * b,
                    _   => a / b
                }));
            break;
        }
        case "5":
        {
            int cantidad = (int)LeerNumero("Cantidad de notas: ");
            if (cantidad <= 0)
            {
                Console.WriteLine("Error: debe ingresar al menos una nota.");
                break;
            }

            double suma = 0;
            for (int i = 1; i <= cantidad; i++)
            {
                double nota;
                do nota = LeerNumero($"Nota {i} (0-100): ");
                while (nota < 0 || nota > 100);
                suma += nota;
            }

            double promedio = suma / cantidad;
            Console.WriteLine($"Promedio: {promedio:F2} - " + (promedio >= 70 ? "APROBADO" : "REPROBADO"));
            break;
        }
        case "0":
            Console.WriteLine("¡Hasta pronto!");
            break;
        default:
            Console.WriteLine("Error: opción no válida.");
            break;
    }
}