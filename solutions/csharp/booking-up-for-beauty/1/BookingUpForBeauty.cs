using System;
using System.Globalization; // Necessário para a formatação de cultura específica

static class Appointment
{
    // Tarefa 1: Implementar o método Schedule().
    // Analisa uma string para criar um objeto DateTime.
    public static DateTime Schedule(string appointmentDateDescription)
    {
        // DateTime.Parse lida com vários formatos comuns, incluindo os do exercício,
        // especialmente sob a cultura en-US.
        return DateTime.Parse(appointmentDateDescription);
    }

    // Tarefa 2: Implementar o método HasPassed().
    // Compara a data do agendamento com a data e hora atuais.
    public static bool HasPassed(DateTime appointmentDate)
    {
        // DateTime.Now retorna a data e hora atuais do sistema.
        // A comparação direta (appointmentDate < DateTime.Now) retorna true se a data do agendamento for anterior a agora.
        return appointmentDate < DateTime.Now;
    }

    // Tarefa 3: Implementar o método IsAfternoonAppointment().
    // Verifica se a hora do agendamento está no período da tarde.
    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        // A propriedade .Hour retorna a hora do dia (0-23).
        // A tarde é definida como o período das 12:00 (incluso) até as 18:00 (excluso).
        int hour = appointmentDate.Hour;
        return hour >= 12 && hour < 18;
    }

    // Tarefa 4: Implementar o método Description().
    // Cria uma string de descrição formatada.
    public static string Description(DateTime appointmentDate)
    {
        // Usamos interpolação de string ($"...") para construir a mensagem.
        // O segundo argumento em ToString("G", CultureInfo.CreateSpecificCulture("en-US"))
        // garante o formato "General" (data curta e hora longa) na cultura en-US,
        // resultando no formato "M/d/yyyy h:mm:ss tt" (ex: 3/29/2019 3:00:00 PM).
        return $"You have an appointment on {appointmentDate.ToString("G", CultureInfo.CreateSpecificCulture("en-US"))}.";
    }

    // Tarefa 5: Implementar o método AnniversaryDate().
    // Retorna a data de aniversário do salão para o ano corrente.
    public static DateTime AnniversaryDate()
    {
        // DateTime.Now.Year obtém o ano atual.
        // Criamos uma nova data para 15 de setembro do ano atual, à meia-noite.
        return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
    }
}
