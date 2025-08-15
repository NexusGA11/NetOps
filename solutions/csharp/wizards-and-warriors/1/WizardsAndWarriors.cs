using System;

abstract class Character
{
    // Campo para armazenar o tipo do personagem.
    private readonly string _characterType;

    // Construtor da classe base.
    // Armazena o tipo de personagem passado pela classe derivada.
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    // Método abstrato que DEVE ser implementado pelas classes derivadas.
    public abstract int DamagePoints(Character target);

    // Tarefa 2: Método virtual que PODE ser sobrescrito.
    // Por padrão, um personagem não é vulnerável.
    public virtual bool Vulnerable()
    {
        return false;
    }

    // Tarefa 1: Sobrescrever o método ToString() da classe base 'object'.
    // Retorna uma descrição formatada do personagem.
    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    // O construtor do Warrior chama o construtor da classe base 'Character'
    // e passa a string "Warrior".
    public Warrior() : base("Warrior")
    {
    }

    // Tarefa 6: Implementar a lógica de dano do Warrior.
    public override int DamagePoints(Character target)
    {
        // O dano depende se o alvo está vulnerável ou não.
        // O método Vulnerable() do alvo é chamado para determinar isso.
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{
    // Campo privado para rastrear se o feitiço foi preparado.
    private bool _spellPrepared = false;

    // O construtor do Wizard chama o construtor da classe base 'Character'
    // e passa a string "Wizard".
    public Wizard() : base("Wizard")
    {
    }

    // Tarefa 5: Implementar a lógica de dano do Wizard.
    public override int DamagePoints(Character target)
    {
        // O dano depende apenas se o próprio Wizard preparou um feitiço.
        return _spellPrepared ? 12 : 3;
    }

    // Tarefa 3: Implementar a preparação do feitiço.
    public void PrepareSpell()
    {
        // Simplesmente define o estado do feitiço como preparado.
        _spellPrepared = true;
    }

    // Tarefa 4: Sobrescrever o método Vulnerable para a lógica específica do Wizard.
    public override bool Vulnerable()
    {
        // Um Wizard é vulnerável se NÃO tiver preparado um feitiço.
        return !_spellPrepared;
    }
}
