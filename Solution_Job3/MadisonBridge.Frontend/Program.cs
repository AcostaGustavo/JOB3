using System;
using MadisonBridge.Backend; // Asegúrate de haber agregado la Referencia de Proyecto

class Program
{
    static void Main()
    {
        // Formato de salida idéntico a las capturas de tus pruebas
        Console.Write("Ingrese el puente: ");
        string entrada = Console.ReadLine() ?? "";

        ValidadorBackend validador = new ValidadorBackend();

        // Ejecutamos la validación del puente
        validador.Validar(entrada, out string resultado);

        // Imprime el estado final (VALIDO o INVALIDO)
        Console.WriteLine(resultado);

        // Mantenemos la consola abierta para ver el resultado
        Console.ReadKey();
    }
}