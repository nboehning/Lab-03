using UnityEngine;

public enum ObjectType
{
    BREAKABLE,
    SOLID,
    DAMAGING,
    HEALING,
    PASSABLE
}

public enum DamageTypes
{
    FIRE,
    PHYSICAL
}

public enum HealingTypes
{
    HEALTH,
    SHIELD
}

public enum HealingPickups
{
    COLLIDED,
    INTERACTED
}

[System.Serializable]
public class ObjectTypes
{
    public ObjectType type;
    public float breakablePoints;

    public bool solidMoving;
    public Vector3 solidStart;
    public Vector3 solidEnd;

    public DamageTypes damageType;
    public float damageAmount;

    public HealingTypes healingType;
    public HealingPickups healingPickupType;
    public float healingAmount;

}
