using S7.Net;
using System;

public class PlcConnection
{
    private Plc plc;

    // Constructor pentru inițializarea PLC-ului
    public PlcConnection(string ipAddress, CpuType cpuType = CpuType.S71200, short rack = 0, short slot = 1)
    {
        plc = new Plc(cpuType, ipAddress, rack, slot);
    }

    // Metodă pentru deschiderea conexiunii
    public void Connect()
    {
        if (!plc.IsConnected)
        {
            try
            {
                plc.Open();
                Console.WriteLine("Conectat la PLC.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la conectare: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Deja conectat la PLC.");
        }
    }

    // Metodă pentru închiderea conexiunii
    public void Disconnect()
    {
        if (plc.IsConnected)
        {
            plc.Close();
            Console.WriteLine("Conexiunea a fost închisă.");
        }
    }

    // Metodă pentru citirea din Data Block
    public object ReadData(string address)
    {
        try
        {
            if (plc.IsConnected)
            {
                var result = plc.Read(address);
                Console.WriteLine($"Date citite de la adresa {address}: {result}");
                return result;
            }
            else
            {
                Console.WriteLine("Nu există conexiune activă la PLC.");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la citirea datelor: {ex.Message}");
            return null;
        }
    }

    // Metodă pentru scrierea în Data Block
    public void WriteData(string address, object value)
    {
        try
        {
            if (plc.IsConnected)
            {
                plc.Write(address, value);
                Console.WriteLine($"Date scrise la adresa {address}: {value}");
            }
            else
            {
                Console.WriteLine("Nu există conexiune activă la PLC.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la scrierea datelor: {ex.Message}");
        }

    }
    // Metodă pentru a obține instanța PLC curentă
    public Plc GetPlcInstance()
    {
        return plc;
    }
}

