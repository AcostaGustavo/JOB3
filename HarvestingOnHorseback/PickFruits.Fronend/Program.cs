using System;
using System.Collections.Generic;
using Motion.Backend; // Asegúrate de que la referencia de proyecto esté agregada


namespace PickFruits.Frontend;

class Program
{
    static void Main()
    {
        Harvest juego = new Harvest();

        Console.Write("Ingrese ubicación de los frutos: ");
        string entradaFrutos = Console.ReadLine() ?? "";
        juego.CargarFrutos(entradaFrutos);

        Console.Write("Ingrese posición inicial del caballo: ");
        string inicio = Console.ReadLine()?.Trim() ?? "a1";
        int colActual = char.ToLower(inicio[0]) - 'a';
        int filaActual = 8 - (int)char.GetNumericValue(inicio[1]);

        Console.Write("Ingrese los movimientos del caballo: ");
        string entradaMovs = Console.ReadLine() ?? "";
        string[] movimientos = entradaMovs.Split(',');

        List<char> recolectados = new List<char>();

        foreach (var mov in movimientos)
        {
            // Usamos la lógica de Harvest para obtener un Motion
            Movement res = juego.CalcularNuevoMovimiento(filaActual, colActual, mov);

            if (res.EsValido)
            {
                filaActual = res.Fila;
                colActual = res.Columna;
                if (res.Fruto != '\0' && res.Fruto != ' ')
                {
                    recolectados.Add(res.Fruto);
                }
            }
        }

        Console.WriteLine("Los frutos recogidos son: " + string.Join(" ", recolectados));
    }
}