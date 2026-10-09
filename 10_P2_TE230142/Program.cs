string continuar = "s";

while (continuar == "s" || continuar == "S") // ciclo para evaluar varios motores
{
    Console.Clear();
    Console.WriteLine("DIAGNÓSTICO DE MOTORES ELÉCTRICOS");
    Console.WriteLine();

    DiagnosticoMotor motorEval = new DiagnosticoMotor(); // se crea objeto motorEval

    Console.Write("Ingrese el identificador del motor: "); // pide ID del motor
    motorEval.Identificador = Console.ReadLine() ?? "Sin ID";

    motorEval.SumaCorrientes = 0;
    for (int i = 1; i <= 4; i++) // bucle para capturar 4 corrientes
    {
        Console.Write($"Ingrese la medición de corriente #{i} (A): ");
        double corriente = Convert.ToDouble(Console.ReadLine());
        motorEval.SumaCorrientes += corriente; // acumula las corrientes
    }

    double promedio = motorEval.CalcularPromedioCorriente(); // calcula corriente promedio

    Console.WriteLine();
    Console.WriteLine($"Motor: {motorEval.Identificador}");
    Console.WriteLine($"Corriente promedio: {promedio:F2} A"); // muestra promedio
    Console.WriteLine($"Diagnóstico: {motorEval.ObtenerDiagnostico()}"); // muestra diagnóstico

    Console.WriteLine();
    Console.Write("¿Desea registrar otro motor? (s/n): "); // pregunta si desea continuar
    continuar = Console.ReadLine() ?? "n";
}

Console.WriteLine("\nPrograma finalizado.");

class DiagnosticoMotor // se define la clase
{
    public string Identificador { get; set; } = "";
    public double SumaCorrientes { get; set; } = 0;

    public double CalcularPromedioCorriente() => SumaCorrientes / 4.0; // calcula promedio

    public string ObtenerDiagnostico() // evalúa el diagnóstico según la corriente
    {
        if (CalcularPromedioCorriente() <= 5.0) return "NORMAL";
        else return "REQUIERE MANTENIMIENTO";
    }
}

