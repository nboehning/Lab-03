using UnityEngine;
using System.Collections;

public enum WeaponClassifications
{

    TWOHANDED,
    ONEHANDED,
    OFFHAND

}

public enum Weapons
{
    SWORD,
    SHIELD,
    RELIC,
    HAMMER,
    SCYTHE
}

[System.Serializable]
public class WeaponTypes
{

    public WeaponClassifications weaponClassification;
    public Weapons weapon;

    public float damageAmount;
    public bool isUpgradeable;

}
