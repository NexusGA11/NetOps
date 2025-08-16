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
