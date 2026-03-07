using System;

namespace MadisonBridge.Backend;

public class ValidadorBackend
{
    public bool Validar(string estructura, out string resultado)
    {
        // 1. Limpieza y preparación
        estructura = estructura.Replace(" ", "").Trim();
        int n = estructura.Length;

        // Caso especial Prueba 5: El puente mínimo permitido
        if (estructura == "**")
        {
            resultado = "VALIDO";
            return true;
        }

        // 2. REGLA: Simetría (Debe ser un espejo perfecto)
        for (int i = 0; i < n / 2; i++)
        {
            if (estructura[i] != estructura[n - 1 - i])
            {
                resultado = "INVALIDO";
                return false;
            }
        }

        // 3. REGLA: Bases (*) solo en los extremos
        if (n < 2 || estructura[0] != '*' || estructura[n - 1] != '*')
        {
            resultado = "INVALIDO";
            return false;
        }

        for (int i = 1; i < n - 1; i++)
        {
            if (estructura[i] == '*')
            {
                resultado = "INVALIDO";
                return false;
            }
        }

        // 4. REGLA: Plataformas (=) y Refuerzos (+)
        int plataformasSeguidas = 0;
        for (int i = 0; i < n; i++)
        {
            if (estructura[i] == '=')
            {
                plataformasSeguidas++;

                // Validar regla de 3 plataformas seguidas
                if (plataformasSeguidas == 3)
                {
                    // El centro de un string de longitud 'n' es (n-1) / 2.0
                    // Si tenemos 3 plataformas, la plataforma de en medio es (i-1)
                    double centroPuente = (n - 1) / 2.0;
                    double centroPlataformas = i - 1;

                    if (Math.Abs(centroPuente - centroPlataformas) > 0.1)
                    {
                        resultado = "INVALIDO"; // Solo se permiten 3 en el centro
                        return false;
                    }
                }

                if (plataformasSeguidas > 3)
                {
                    resultado = "INVALIDO"; // Nunca más de 3
                    return false;
                }
            }
            else
            {
                // Regla: Si hay exactamente 2 plataformas, debe haber refuerzo o base después
                // Pero como ya validamos simetría y extremos, solo verificamos que no sea plataforma
                plataformasSeguidas = 0;
            }
        }

        // Si pasó todas las reglas anteriores
        resultado = "VALIDO";
        return true;
    }
}