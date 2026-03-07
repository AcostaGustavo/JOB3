using System;
using System.Collections.Generic;
using System.Text;

namespace Motion.Backend;

public class Harvest
{
    private char[,] _campo = new char[8, 8];

    public void CargarFrutos(string entrada)
    {
        string[] items = entrada.Split(',');
        foreach (var item in items)
        {
            string trimItem = item.Trim();
            if (trimItem.Length >= 3)
            {
                int col = char.ToLower(trimItem[0]) - 'a';
                int fila = 8 - (int)char.GetNumericValue(trimItem[1]);
                char fruto = trimItem[2];
                _campo[fila, col] = fruto;
            }
        }
    }

    // AHORA DEVUELVE UN OBJETO "Motion"
    public Movement CalcularNuevoMovimiento(int fActual, int cActual, string sigla)
    {
        var (df, dc) = sigla.Trim().ToUpper() switch
        {
            "UL" => (-2, -1),
            "UR" => (-2, 1),
            "LU" => (-1, -2),
            "LD" => (1, -2),
            "RU" => (-1, 2),
            "RD" => (1, 2),
            "DL" => (2, -1),
            "DR" => (2, 1),
            _ => (0, 0)
        };

        int nf = fActual + df;
        int nc = cActual + dc;

        if (nf >= 0 && nf < 8 && nc >= 0 && nc < 8)
        {
            return new Movement
            {
                Fila = nf,
                Columna = nc,
                Fruto = _campo[nf, nc],
                EsValido = true
            };
        }
        return new Movement { EsValido = false };
    }
}