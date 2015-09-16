using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof (WeaponTypes))]
public class WeaponTypesDrawer : PropertyDrawer
{

    //Create extra spacing below the inspector for this object
    private float extraHeight = 55f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
    //Create a rect that represents the enum dropdown position for the object type
    Rect objectTypeDisplay = new Rect(position.x, position.y, position.width, 15f);

        //Inform the editor that a new portion of the editor is going to be started
        EditorGUI.BeginProperty(position, label, property);

        // Gather the editable references of the variables
        SerializedProperty weaponType = property.FindPropertyRelative("weapon");
        SerializedProperty weaponClassification = property.FindPropertyRelative("weaponClassification");

        SerializedProperty damageAmount = property.FindPropertyRelative("damageAmount");
        SerializedProperty isUpgradeable = property.FindPropertyRelative("isUpgradeable");

        // Display initial drop down with no label for the weapon classification
        EditorGUI.PropertyField(objectTypeDisplay, weaponClassification, GUIContent.none);

        switch ((WeaponClassifications) weaponClassification.enumValueIndex)
        {
            case WeaponClassifications.OFFHAND:
                EditorGUI.indentLevel++;

                // String array of offhand weapon choices
                string [] offHandChoices = new string[] {"Shield", "Relic"};

                // Set the choice index off of enum value
                int offChoiceIndex;
                switch (weaponType.enumValueIndex)
                {
                    case 2:
                        offChoiceIndex = 1;
                        break;
                    default:
                        offChoiceIndex = 0;
                        break;
                }

                // Rect showing the pop up
                Rect offHandWeaponTypeRect = new Rect(position.x, position.y + 17, position.width, 17f);

                // Gets the choice the designer made from the popup
                offChoiceIndex = EditorGUI.Popup(offHandWeaponTypeRect, "Weapon Type", offChoiceIndex, offHandChoices);

                // Switch statement based on which choice designer makes
                switch (offChoiceIndex)
                {
                    case 0:
                        // Designer chose shield, set weapon type accordingly
                        weaponType.enumValueIndex = 1;
                        break;
                    case 1:
                        // Designer chose relic, set weapon type accordingly
                        weaponType.enumValueIndex = 2;
                        break;
                }

                // Rectangles for how much damage the weapon will do.
                Rect offHandDamageLabelRect = new Rect(position.x, position.y + 34, position.width, 17f);
                EditorGUI.LabelField(offHandDamageLabelRect, "Damage Amount");

                Rect offHandDamageRect = new Rect(position.x + (position.width / 2), position.y + 34, position.width / 2, 15f);
                damageAmount.floatValue = EditorGUI.FloatField(offHandDamageRect, damageAmount.floatValue);

                //Create a rect to represent the location that the dropdown will appear
                Rect canUpgradeRect = new Rect(position.x, position.y + 51, position.width, 15f);

                //Convert the isUpgradeable bool to an integer
                int index = isUpgradeable.boolValue ? 0 : 1;

                //Set up what the dropdown options will be
                string[] options = new string[] { "Yes", "No" };

                //Display a dropdown at the appropriate location, with a set label, 
                //displaying the value of index as the corrisponding string
                index = EditorGUI.Popup(canUpgradeRect, "Upgradeable?", index, options);

                //Convert the value of index to a bool and store it in the SerializedProperty
                isUpgradeable.boolValue = (index <= 0);

                EditorGUI.indentLevel--;

                break;
            case WeaponClassifications.ONEHANDED:
                EditorGUI.indentLevel++;

                // String array of offhand weapon choices
                string[] oneHandChoices = new string[] { "Sword", "Hammer" };

                // Set the popup choice based off of current enum value
                int oneChoiceIndex;
                switch (weaponType.enumValueIndex)
                {
                    case 3:
                        oneChoiceIndex = 1;
                        break;
                    default:
                        oneChoiceIndex = 0;
                        break;
                }

                // Rect showing the pop up
                Rect oneHandWeaponTypeRect = new Rect(position.x, position.y + 17, position.width, 17f);

                // Set the pop up to the one desginer chose
                oneChoiceIndex = EditorGUI.Popup(oneHandWeaponTypeRect, "Weapon Type", oneChoiceIndex, oneHandChoices);

                // Switch statement based on which choice designer makes
                switch (oneChoiceIndex)
                {
                    case 0:
                        // Designer chose sword, set weapon type accordingly
                        weaponType.enumValueIndex = 0;
                        break;
                    case 1:
                        // Designer chose hammer, set weapon type accordingly
                        weaponType.enumValueIndex = 3;
                        break;
                }

                // Rectangles for how much damage the weapon will do.
                Rect onHandDamageLabelRect = new Rect(position.x, position.y + 34, position.width, 17f);
                EditorGUI.LabelField(onHandDamageLabelRect, "Damage Amount");

                Rect onHandDamageRect = new Rect(position.x + 113, position.y + 34, position.width / 2, 15f);
                damageAmount.floatValue = EditorGUI.FloatField(onHandDamageRect, damageAmount.floatValue);

                if (weaponType.enumValueIndex != 3)
                {
                    //Create a rect to represent the location that the dropdown will appear
                    canUpgradeRect = new Rect(position.x, position.y + 51, position.width, 15f);

                    //Convert the isUpgradeable bool to an integer
                    index = isUpgradeable.boolValue ? 0 : 1;

                    //Set up what the dropdown options will be
                    options = new string[] { "Yes", "No" };

                    //Display a dropdown at the appropriate location, with a set label, 
                    //displaying the value of index as the corrisponding string
                    index = EditorGUI.Popup(canUpgradeRect, "Upgradeable?", index, options);

                    //Convert the value of index to a bool and store it in the SerializedProperty
                    isUpgradeable.boolValue = (index <= 0);
                }

                EditorGUI.indentLevel--;
                break;
            case WeaponClassifications.TWOHANDED:
                EditorGUI.indentLevel++;

                // String array of offhand weapon choices
                string[] twoHandChoices = new string[] { "Sword", "Hammer", "Scythe" };

                // Set pop up choice based off enum value
                int twoChoiceIndex;
                switch (weaponType.enumValueIndex)
                {
                    case 3:
                        twoChoiceIndex = 1;
                        break;
                    case 4:
                        twoChoiceIndex = 2;
                        break;
                    default:
                        twoChoiceIndex = 0;
                        break;
                }

                // Rect showing the pop up
                Rect twoHandWeaponTypeRect = new Rect(position.x, position.y + 17, position.width, 17f);

                // Get the choice designer made from the pop up
                twoChoiceIndex = EditorGUI.Popup(twoHandWeaponTypeRect, "Weapon Type", twoChoiceIndex, twoHandChoices);

                // Switch statement based on which choice designer makes
                switch (twoChoiceIndex)
                {
                    case 0:
                        // Designer chose sword, set weapon type accordingly
                        weaponType.enumValueIndex = 0;
                        break;
                    case 1:
                        // Designer chose hammer, set weapon type accordingly
                        weaponType.enumValueIndex = 3;
                        break;
                    case 2:
                        // Designer chose scythe, set weapon type accordingly
                        weaponType.enumValueIndex = 4;
                        break;
                }

                // Rectangles for how much damage the weapon will do.
                Rect twoHandDamageLabelRect = new Rect(position.x, position.y + 34, position.width, 17f);
                EditorGUI.LabelField(twoHandDamageLabelRect, "Damage Amount");

                Rect twoHandDamageRect = new Rect(position.x + 113, position.y + 34, position.width / 2, 15f);
                damageAmount.floatValue = EditorGUI.FloatField(twoHandDamageRect, damageAmount.floatValue);

                if (weaponType.enumValueIndex != 3)
                {
                    //Create a rect to represent the location that the dropdown will appear
                    canUpgradeRect = new Rect(position.x, position.y + 51, position.width, 15f);

                    //Convert the isUpgradeable bool to an integer
                    index = isUpgradeable.boolValue ? 0 : 1;

                    //Set up what the dropdown options will be
                    options = new string[] {"Yes", "No"};

                    //Display a dropdown at the appropriate location, with a set label, 
                    //displaying the value of index as the corrisponding string
                    index = EditorGUI.Popup(canUpgradeRect, "Upgradeable?", index, options);

                    //Convert the value of index to a bool and store it in the SerializedProperty
                    isUpgradeable.boolValue = (index <= 0);
                }

                EditorGUI.indentLevel--;
                break;
        }

        if (damageAmount.floatValue < 0f)
            damageAmount.floatValue = 0f;
        else if (damageAmount.floatValue > 100f)
            damageAmount.floatValue = 100f;

        EditorGUI.EndProperty();
    }

    //Gets the height of the property
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        //Increases the height of the property by extraHeight
        return base.GetPropertyHeight(property, label) + extraHeight;

    }
}
