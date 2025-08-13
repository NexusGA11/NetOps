using System;
using System.Collections.Generic; // Necessário para HashSet

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    // Tarefa 1: Implementar a igualdade para FacialFeatures.
    // Duas características faciais são iguais se a cor dos olhos E a largura do filtro labial forem iguais.
    public override bool Equals(object obj)
    {
        // Verifica se o objeto é do tipo FacialFeatures e não nulo.
        if (obj is FacialFeatures other)
        {
            // Compara os valores das propriedades.
            return this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;
        }
        return false;
    }

    // Se você sobrescreve Equals, DEVE sobrescrever GetHashCode.
    public override int GetHashCode()
    {
        // Usa a classe HashCode para combinar os hash codes das propriedades de forma segura.
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    // Tarefa 2: Implementar a igualdade para Identity.
    // Duas identidades são iguais se o email E as características faciais forem iguais.
    public override bool Equals(object obj)
    {
        // Verifica se o objeto é do tipo Identity e não nulo.
        if (obj is Identity other)
        {
            // A comparação de FacialFeatures chama o método Equals que implementamos acima.
            return this.Email == other.Email && this.FacialFeatures.Equals(other.FacialFeatures);
        }
        return false;
    }

    // Sobrescreve GetHashCode para corresponder à lógica de Equals.
    public override int GetHashCode()
    {
        // Combina os hash codes do email e das características faciais.
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    // Tarefa 3: Armazenar as identidades registradas.
    // Usamos um HashSet porque ele é otimizado para verificar a existência de itens
    // e automaticamente usa os métodos Equals/GetHashCode que implementamos.
    private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

    // Tarefa 2: Definir a identidade do administrador.
    private static readonly Identity AdminIdentity = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    // Tarefa 1: Implementar AreSameFace.
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        // Esta chamada funciona porque implementamos o método Equals na classe FacialFeatures.
        return faceA.Equals(faceB);
    }

    // Tarefa 2: Implementar IsAdmin.
    public bool IsAdmin(Identity identity)
    {
        // Compara a identidade fornecida com a identidade estática do administrador.
        // Isso funciona por causa da implementação de Equals na classe Identity.
        return identity.Equals(AdminIdentity);
    }

    // Tarefa 3: Implementar Register.
    public bool Register(Identity identity)
    {
        // O método Add de um HashSet retorna 'true' se o item foi adicionado com sucesso
        // e 'false' se o item já existia no conjunto (baseado em Equals/GetHashCode).
        // Isso corresponde exatamente ao requisito do exercício.
        return _registeredIdentities.Add(identity);
    }

    // Tarefa 4: Implementar IsRegistered.
    public bool IsRegistered(Identity identity)
    {
        // O método Contains de um HashSet usa Equals/GetHashCode para verificar
        // de forma eficiente se uma identidade com os mesmos valores já foi registrada.
        return _registeredIdentities.Contains(identity);
    }

    // Tarefa 5: Implementar AreSameObject.
    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        // Object.ReferenceEquals compara as referências de memória dos objetos,
        // verificando se são a exata mesma instância, e não apenas objetos com valores iguais.
        return object.ReferenceEquals(identityA, identityB);
    }
}
