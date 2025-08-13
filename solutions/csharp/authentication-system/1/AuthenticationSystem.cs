using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Authenticator
{
    // 1. CONSTANTS: A classe interna EyeColor é desnecessária.
    // Seus valores são constantes e podem ser definidos aqui.
    // Como são usados apenas na inicialização dos desenvolvedores, podem ser privados.
    private const string EyeColorBlue = "blue";
    private const string EyeColorBrown = "brown";

    // 2. READONLY FIELDS: Os campos 'admin' e 'developers' são inicializados
    // uma vez (no construtor ou inline) e nunca mais devem ser alterados.
    // O modificador 'readonly' impõe essa regra.
    private readonly Identity admin;
    private readonly IDictionary<string, Identity> developers;

    public Authenticator(Identity admin)
    {
        this.admin = admin;

        // A inicialização do dicionário é feita aqui para usar as constantes.
        this.developers = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = EyeColorBlue
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = EyeColorBrown
            }
        };
    }

    // 3. REMOVE SETTER & DEFENSIVE COPY:
    // A propriedade Admin não deve ter um 'set' para que a identidade do admin não possa ser trocada.
    // Ao retornar 'this.admin', como Identity é uma struct (tipo de valor),
    // o C# já retorna uma CÓPIA, não a referência original.
    // Isso impede que o código cliente modifique o campo 'admin' interno.
    public Identity Admin => this.admin;

    // 4. READONLY COLLECTION:
    // Para impedir que o código cliente modifique o dicionário de desenvolvedores,
    // retornamos uma "visão" somente leitura dele usando ReadOnlyDictionary.
    // Isso expõe os dados de forma segura, sem permitir adições ou remoções.
    public IDictionary<string, Identity> GetDevelopers()
    {
        return new ReadOnlyDictionary<string, Identity>(this.developers);
    }
}

// IMPORTANTE: A struct Identity deve permanecer com 'get; set;'
// para ser compatível com os testes do Exercism, que esperam poder
// modificar suas propriedades. A segurança é garantida pela classe Authenticator.
public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}
