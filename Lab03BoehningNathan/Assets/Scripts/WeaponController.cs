using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public WeaponTypes weaponTypes;

    void Start()
    {
            // Print out weapon information
            Debug.Log("weapon class " + weaponTypes.weaponClassification);
            Debug.Log("weapon type " + weaponTypes.weapon);
            Debug.Log("damage amount " + weaponTypes.damageAmount);
            Debug.Log("is upgradeable " + weaponTypes.isUpgradeable);
    }
}