// See https://aka.ms/new-console-template for more information
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;

//while (!System.Diagnostics.Debugger.IsAttached)
  //  if (Console.KeyAvailable)
    //    break;

List<string> portNames = new List<string>();

Console.WriteLine("\nStarted!!!!!\n");

portNames = SerialPort.GetPortNames().ToList();

Console.WriteLine($"# Serial Ports = {portNames.Count}");
for (int i = 0; i < portNames.Count; i++)
{
    Console.WriteLine($"\nPort[{i}] = '{portNames.ElementAt(i)}'");
    
    Console.Write($"> Attempt open Port[{i}] = '{portNames.ElementAt(i)}'");
    using (var port = new SerialPort(portNames.ElementAt(i)))
    {
        try  {
            port.Open();
            Console.WriteLine($" IsOpen = [{port.IsOpen}]");
            Console.WriteLine($"> Successful");
            port.Close();
        } catch (Exception ex) { 
            Console.WriteLine($"\n>>>> Failure! Excepton: ['{ex.Message}']");
        }
    }
    Console.Write("\n");
}





