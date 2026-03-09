using System;
using MadisonBridge.Backend; 

class Program
{
    static void Main()
    {
        
        Console.Write("Ingrese el puente: ");
        string entrada = Console.ReadLine() ?? "";

        ValidadorBackend validador = new ValidadorBackend();

        
        validador.Validar(entrada, out string resultado);

        
        Console.WriteLine(resultado);

        
        Console.ReadKey();
    }
}