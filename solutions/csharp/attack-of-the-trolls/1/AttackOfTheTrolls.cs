using System;

// Tarefa 1: Definir o enum 'AccountType'.
// Este é um enum simples, sem a necessidade do atributo [Flags].
public enum AccountType
{
    Guest,
    User,
    Moderator
}

// Tarefa 2: Definir o enum 'Permission' com o atributo [Flags].
// Os valores são potências de 2 para que possam ser combinados com operações de bits.
[Flags]
public enum Permission
{
    None = 0,          // 0b0000
    Read = 1,          // 0b0001
    Write = 2,         // 0b0010
    Delete = 4,        // 0b0100
    All = Read | Write | Delete // Combinação de todas as permissões (0b0111)
}

static class Permissions
{
    // Tarefa 3: Retorna as permissões padrão para um tipo de conta.
    public static Permission Default(AccountType accountType)
    {
        // Usa uma switch expression para mapear o tipo de conta para suas permissões padrão.
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write, // Combina Read e Write
            AccountType.Moderator => Permission.All,
            // O caso padrão '_' lida com qualquer valor de enum inesperado.
            _ => Permission.None
        };
    }

    // Tarefa 4: Concede (adiciona) uma permissão.
    public static Permission Grant(Permission current, Permission grant)
    {
        // O operador OR bit a bit (|) "liga" os bits da permissão a ser concedida.
        // Ex: (Read) 0001 | (Write) 0010  =>  0011 (Read e Write)
        return current | grant;
    }

    // Tarefa 5: Revoga (remove) uma permissão.
    public static Permission Revoke(Permission current, Permission revoke)
    {
        // O operador AND bit a bit (&) com o complemento (~) "desliga" os bits.
        // ~revoke inverte todos os bits da permissão a ser revogada.
        // Ex: (Read | Write) 0011 & ~(Write) 1101  =>  0001 (Apenas Read)
        return current & ~revoke;
    }

    // Tarefa 6: Verifica se uma permissão específica está presente.
    public static bool Check(Permission current, Permission check)
    {
        // O operador AND bit a bit (&) é usado para verificar a presença de um "flag".
        // Se o resultado da operação for igual ao próprio "flag", significa que ele está presente.
        // Ex: (Read | Write) 0011 & (Write) 0010  =>  0010. Como 0010 == 0010, retorna true.
        // Ex: (Read | Write) 0011 & (Delete) 0100 =>  0000. Como 0000 != 0100, retorna false.
        // Caso especial: a permissão a ser checada é None.
        if (check == Permission.None)
        {
            return true; // Ter "nenhuma" permissão é sempre verdade.
        }
        return (current & check) == check;
    }
}
