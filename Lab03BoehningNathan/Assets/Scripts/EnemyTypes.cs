// enum for factions
public enum EnemyFactions
{
    AGGRESSIVE,
    NEUTRAL,
    PASSIVE
}

// enum for attacks
public enum AttackTypes
{
    MELEE,
    RANGED
}

// enum for damage types
public enum AttackDamageTypes
{
    PHYSICAL,
    SPELL
}

// enum for spells
public enum SpellTypes
{
    FIRE,
    FROST,
    ARCANE
}

// enum for armor types
[System.Flags]
public enum ArmorTypes
{
    CLOTH = 1,
    LEATHER = 2,
    MAIL = 4,
    PLATE = 8
}

// enum for weapon types
[System.Flags]
public enum EnemyWeaponTypes
{
    TWOHAND = 1,
    DUALWIELD = 2
}

[System.Serializable]
public class EnemyTypes
{
    // variables for enemy types
    public EnemyFactions enemyFaction;
    public AttackTypes attackType;
    public AttackDamageTypes damageType;
    public SpellTypes spellType;
    public ArmorTypes armorType;
    public EnemyWeaponTypes weaponType;
    
    public string enemyName;
    public int health;
    public int mana;

}
