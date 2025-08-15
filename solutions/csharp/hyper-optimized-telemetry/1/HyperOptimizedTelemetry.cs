using System;

/// <summary>
/// Classe estática para codificar e decodificar dados de telemetria.
/// </summary>
public static class TelemetryBuffer
{
    /// <summary>
    /// Codifica um valor 'long' em um buffer de 9 bytes de acordo com o protocolo.
    /// </summary>
    /// <param name="reading">O valor numérico a ser codificado.</param>
    /// <returns>Um array de 9 bytes representando o valor codificado.</returns>
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        byte[] payload;
        byte prefix;

        // A ordem das verificações é crucial para garantir que o menor tipo possível seja usado.
        // Primeiro, verificamos os intervalos que não se sobrepõem com outros tipos menores.
        if (reading > int.MaxValue) // Cobre uint e a parte positiva de long
        {
            if (reading <= uint.MaxValue)
            {
                // Tipo: uint (4 bytes, sem sinal)
                prefix = 4; // 0x04
                payload = BitConverter.GetBytes((uint)reading);
            }
            else // reading > uint.MaxValue
            {
                // Tipo: long (8 bytes, com sinal)
                prefix = 256 - 8; // 248 ou 0xf8
                payload = BitConverter.GetBytes(reading);
            }
        }
        else if (reading < int.MinValue) // Cobre a parte negativa de long
        {
            // Tipo: long (8 bytes, com sinal)
            prefix = 256 - 8; // 248 ou 0xf8
            payload = BitConverter.GetBytes(reading);
        }
        else // O valor está dentro do intervalo de um 'int'
        {
            if (reading >= 0 && reading <= ushort.MaxValue)
            {
                // Tipo: ushort (2 bytes, sem sinal)
                prefix = 2; // 0x02
                payload = BitConverter.GetBytes((ushort)reading);
            }
            else if (reading >= short.MinValue && reading < 0)
            {
                // Tipo: short (2 bytes, com sinal)
                prefix = 256 - 2; // 254 ou 0xfe
                payload = BitConverter.GetBytes((short)reading);
            }
            else
            {
                // Tipo: int (4 bytes, com sinal)
                prefix = 256 - 4; // 252 ou 0xfc
                payload = BitConverter.GetBytes((int)reading);
            }
        }

        // Monta o buffer final
        buffer[0] = prefix;
        payload.CopyTo(buffer, 1);

        return buffer;
    }

    /// <summary>
    /// Decodifica um buffer de 9 bytes para um valor 'long'.
    /// </summary>
    /// <param name="buffer">O array de bytes a ser decodificado.</param>
    /// <returns>O valor numérico decodificado, ou 0 se o prefixo for inválido.</returns>
    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];

        switch (prefix)
        {
            case 248: // 256 - 8 -> long
                return BitConverter.ToInt64(buffer, 1);
            
            case 4: // -> uint
                return BitConverter.ToUInt32(buffer, 1);
            
            case 252: // 256 - 4 -> int
                return BitConverter.ToInt32(buffer, 1);
            
            case 2: // -> ushort
                return BitConverter.ToUInt16(buffer, 1);
            
            case 254: // 256 - 2 -> short
                return BitConverter.ToInt16(buffer, 1);
            
            default:
                // Prefixo inválido
                return 0;
        }
    }
}
