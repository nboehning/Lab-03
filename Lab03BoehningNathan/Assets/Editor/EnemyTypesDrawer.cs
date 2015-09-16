using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnemyTypes))]
public class EnemyTypesDrawer : PropertyDrawer
{

    //Create extra spacing below the inspector for this object
    private float extraHeight = 150f;
    int totalVal = 0;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Set the offset from position.x
        float offsetX = position.x + (position.width / 2);


        //Create a rect that represents the enum dropdown position for the object type
        Rect objectTypeDisplay = new Rect(offsetX, position.y, position.width / 2, 15f);
        Rect enemyNameLabel = new Rect(position.x, position.y, position.width, 15f);

        //Inform the editor that a new portion of the editor is going to be started
        EditorGUI.BeginProperty(position, label, property);

        // Gather the editable references of the variables
        SerializedProperty name = property.FindPropertyRelative("enemyName");
        SerializedProperty faction = property.FindPropertyRelative("enemyFaction");

        SerializedProperty attackType = property.FindPropertyRelative("attackType");
        SerializedProperty damageType = property.FindPropertyRelative("damageType");


        SerializedProperty weaponType = property.FindPropertyRelative("weaponType");
        SerializedProperty spellType = property.FindPropertyRelative("spellType");
        SerializedProperty armorType = property.FindPropertyRelative("armorType");

        SerializedProperty health = property.FindPropertyRelative("health");
        SerializedProperty mana = property.FindPropertyRelative("mana");

        // Get the name of the enemy/ally
        EditorGUI.LabelField(enemyNameLabel, "Name");
        EditorGUI.PropertyField(objectTypeDisplay, name, GUIContent.none);
        EditorGUI.indentLevel++;

        // Get the faction type
        Rect enemyFactionLabelRect = new Rect(position.x, position.y + 17, position.width, 15f);
        EditorGUI.LabelField(enemyFactionLabelRect, "Faction Type");
        Rect enemyFactionRect = new Rect(offsetX, position.y + 17, position.width / 2, 15f);
        EditorGUI.PropertyField(enemyFactionRect, faction, GUIContent.none);

        // Get attack type
        Rect attackTypeLabelRect = new Rect(position.x, position.y + 34, position.width, 15f);
        EditorGUI.LabelField(attackTypeLabelRect, "Attack Type");
        Rect attackTypeRect = new Rect(offsetX, position.y + 34, position.width / 2, 15f);
        EditorGUI.PropertyField(attackTypeRect, attackType, GUIContent.none);

        // Get damage type
        Rect damageTypeLabelRect = new Rect(position.x, position.y + 51, position.width, 15f);
        EditorGUI.LabelField(damageTypeLabelRect, "Damage Type");
        Rect damageTypeRect = new Rect(offsetX, position.y + 51, position.width / 2, 15f);
        EditorGUI.PropertyField(damageTypeRect, damageType, GUIContent.none);

        switch ((AttackDamageTypes)damageType.enumValueIndex)
        {
            case AttackDamageTypes.PHYSICAL:
                // Get health
                Rect healthLabelRect = new Rect(position.x, position.y + 68, position.width, 15f);
                EditorGUI.LabelField(healthLabelRect, "Health");
                Rect healthRect = new Rect(offsetX, position.y + 68, position.width / 2, 15f);
                health.intValue = EditorGUI.IntField(healthRect, health.intValue);

                // Get weapon type
                Rect weaponTypeLabelRect = new Rect(position.x, position.y + 85, position.width, 15f);
                EditorGUI.LabelField(weaponTypeLabelRect, "Weapon Type");
                Rect weaponTypeRect = new Rect(offsetX, position.y + 85, position.width / 2, 15f);
                weaponType.intValue = EditorGUI.MaskField(weaponTypeRect, "", weaponType.intValue, weaponType.enumNames);

                Debug.Log("weaponType int value " + weaponType.intValue);
                if (weaponType.intValue != -2 && weaponType.intValue != 0)
                {
                    // Armor type
                    string[] physicalTwoChoices = { "Leather", "Plate" };
                    Rect armorTypeLabelRect = new Rect(position.x, position.y + 102, position.width, 15f);
                    EditorGUI.LabelField(armorTypeLabelRect, "Armor Type");

                    // Create the mask for the armor types with the custom string array
                    Rect armorTypeRect = new Rect(offsetX, position.y + 102, position.width / 2, 15f);
                    totalVal = EditorGUI.MaskField(armorTypeRect, "", totalVal, physicalTwoChoices);

                    // Shift the bits
                    if (totalVal == 1)
                        armorType.intValue = 2;
                    else if (totalVal == 2)
                        armorType.intValue = 8;
                    else if (totalVal == 3)
                        armorType.intValue = 10;
                    else
                        armorType.intValue = totalVal;
                }
                else
                {
                    // Armor type
                    string[] physicalOtherChoices = { "Leather", "Mail", "Plate" };
                    Rect armorTypeLabelRect = new Rect(position.x, position.y + 102, position.width, 15f);
                    EditorGUI.LabelField(armorTypeLabelRect, "Armor Type");

                    // Create the mask for the armor types with the custom string array
                    Rect armorTypeRect = new Rect(offsetX, position.y + 102, position.width / 2, 15f);
                    totalVal = EditorGUI.MaskField(armorTypeRect, "", totalVal, physicalOtherChoices);

                    // Shift the bits
                    if (totalVal == 1 || totalVal == 2 || totalVal == 4)
                        armorType.intValue = totalVal * 2;
                    else if (totalVal == 3)
                        armorType.intValue = 6;
                    else if (totalVal == 5)
                        armorType.intValue = 10;
                    else if (totalVal == 6)
                        armorType.intValue = 12;
                    else if (totalVal == 7)
                        armorType.intValue = 14;
                    else
                        armorType.intValue = totalVal;
                }
                break;
            case AttackDamageTypes.SPELL:
                EditorGUI.indentLevel++;

                // Get mana
                Rect manaLabelRect = new Rect(position.x, position.y + 68, position.width, 15f);
                EditorGUI.LabelField(manaLabelRect, "Mana");
                Rect manaRect = new Rect(offsetX, position.y + 68, position.width / 2, 15f);
                mana.intValue = EditorGUI.IntField(manaRect, mana.intValue);

                // Get spell type
                Rect spellTypeLabelRect = new Rect(position.x, position.y + 85, position.width, 15f);
                EditorGUI.LabelField(spellTypeLabelRect, "Spell Type");
                Rect spellTypeRect = new Rect(offsetX, position.y + 85, position.width / 2, 15f);
                EditorGUI.PropertyField(spellTypeRect, spellType, GUIContent.none);

                EditorGUI.indentLevel--;

                // Get health
                healthLabelRect = new Rect(position.x, position.y + 102, position.width, 15f);
                EditorGUI.LabelField(healthLabelRect, "Health");
                healthRect = new Rect(offsetX, position.y + 102, position.width / 2, 15f);
                health.intValue = EditorGUI.IntField(healthRect, health.intValue);

                // Get weapon type
                weaponTypeLabelRect = new Rect(position.x, position.y + 119, position.width, 15f);
                EditorGUI.LabelField(weaponTypeLabelRect, "Weapon Type");
                weaponTypeRect = new Rect(offsetX, position.y + 119, position.width / 2, 15f);
                weaponType.intValue = EditorGUI.MaskField(weaponTypeRect, "", weaponType.intValue, weaponType.enumNames);

                if (weaponType.intValue != -2 && weaponType.intValue != 0)
                {
                    // Armor type
                    string[] spelltwochoices = { "Cloth", "Leather", "Plate" };
                    Rect armorTypeLabelRect = new Rect(position.x, position.y + 136, position.width, 15f);
                    EditorGUI.LabelField(armorTypeLabelRect, "Armor Type");

                    // Create the mask for the armor types with the custom string array
                    Rect armorTypeRect = new Rect(offsetX, position.y + 136, position.width / 2, 15f);
                    totalVal = EditorGUI.MaskField(armorTypeRect, "", totalVal, spelltwochoices);

                    // Shift the bits appropriately
                    if (totalVal == 4)
                        armorType.intValue = 8;
                    else if (totalVal == 5)
                        armorType.intValue = 9;
                    else if (totalVal == 6)
                        armorType.intValue = 10;
                    else if (totalVal == 7)
                        armorType.intValue = 11;
                    else
                        armorType.intValue = totalVal;
                }
                else
                {
                    // Armor type
                    string[] spellOtherChoices = { "Cloth", "Leather", "Mail", "Plate" };
                    Rect armorTypeLabelRect = new Rect(position.x, position.y + 136, position.width, 15f);
                    EditorGUI.LabelField(armorTypeLabelRect, "Armor Type");

                    // Create the mask for the armor types with the custom string array
                    Rect armorTypeRect = new Rect(offsetX, position.y + 136, position.width / 2, 15f);
                    totalVal = EditorGUI.MaskField(armorTypeRect, "", totalVal, spellOtherChoices);

                    // Don't need to shift due to the flags being set correctly already
                    armorType.intValue = totalVal;
                }

                break;
        }
        EditorGUI.EndProperty();
    }

    //Gets the height of the property
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        //Increases the height of the property by extraHeight
        return base.GetPropertyHeight(property, label) + extraHeight;

    }
}

