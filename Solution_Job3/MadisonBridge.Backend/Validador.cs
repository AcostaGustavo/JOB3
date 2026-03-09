using System;

namespace MadisonBridge.Backend;

public class ValidadorBackend
{
    public bool Validar(string estructura, out string resultado)
    {
        
        estructura = estructura.Replace(" ", "").Trim();
        int n = estructura.Length;

        
        if (estructura == "**")
        {
            resultado = "VALIDO";
            return true;
        }

       
        for (int i = 0; i < n / 2; i++)
        {
            if (estructura[i] != estructura[n - 1 - i])
            {
                resultado = "INVALIDO";
                return false;
            }
        }

        
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

        
        int plataformasSeguidas = 0;
        for (int i = 0; i < n; i++)
        {
            if (estructura[i] == '=')
            {
                plataformasSeguidas++;

                
                if (plataformasSeguidas == 3)
                {
                    
                    double centroPuente = (n - 1) / 2.0;
                    double centroPlataformas = i - 1;

                    if (Math.Abs(centroPuente - centroPlataformas) > 0.1)
                    {
                        resultado = "INVALIDO"; 
                        return false;
                    }
                }

                if (plataformasSeguidas > 3)
                {
                    resultado = "INVALIDO"; 
                    return false;
                }
            }
            else
            {
                
            }
        }

        
        resultado = "VALIDO";
        return true;
    }
}