using System;



public class Orm : IDisposable
{
    private readonly Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {

        if (this.database.DbState != Database.State.Closed)
        {
            throw new InvalidOperationException();
        }
        this.database.BeginTransaction();
    }

    public void Write(string data)
    {
  
        try
        {
            this.database.Write(data);
        }
        catch
        {

            this.database.Dispose();
        }
    }

    public void Commit()
    {

        try
        {
            this.database.EndTransaction();
        }
        catch
        {

            this.database.Dispose();
        }
    }

    public void Dispose()
    {
        this.database.Dispose();
    }
}
