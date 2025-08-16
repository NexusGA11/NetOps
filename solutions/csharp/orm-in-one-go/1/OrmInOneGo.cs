using System;

public class Orm
{
    private readonly Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using (database)
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            // A lógica de 'Write' é replicada aqui, mas dentro de um bloco try-catch.
            // Não chama o método 'Write' para evitar a recursão.
            using (database)
            {
                database.BeginTransaction();
                database.Write(data);
                database.EndTransaction();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
