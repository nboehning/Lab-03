using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public EnemyTypes enemyTypes;

    void Start()
    {
        // Print out all information on enemies
        Debug.Log("Enemy name: " + enemyTypes.enemyName);
        Debug.Log("Enemy faction: " + enemyTypes.enemyFaction);
        Debug.Log("Enemy attack type: " + enemyTypes.attackType);
        Debug.Log("Enemy damage type: " + enemyTypes.damageType);
        if (enemyTypes.damageType != AttackDamageTypes.SPELL)
        {
            Debug.Log("Enemy health: " + enemyTypes.health);
            Debug.Log("Enemy weapon type: " + enemyTypes.weaponType);
            Debug.Log("Enemy armor type: " + enemyTypes.armorType);
        }
        else
        {
            Debug.Log("Enemy mana: " + enemyTypes.mana);
            Debug.Log("Enemy spell type: " + enemyTypes.spellType);
            Debug.Log("Enemy health: " + enemyTypes.health);
            Debug.Log("Enemy weapon type: " + enemyTypes.weaponType);
            Debug.Log("Enemy armor type: " + enemyTypes.armorType);
        }
    }
}
