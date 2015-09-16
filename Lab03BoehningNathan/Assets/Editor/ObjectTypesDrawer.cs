using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ObjectTypes))]
public class ObjectTypesDrawer : PropertyDrawer
{
    //Create extra spacing below the inspector for this object
    float extraHeight = 55f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Create a rect that represents the enum dropdown position for the object type
        Rect objectTypeDisplay = new Rect(position.x, position.y, position.width, 15f);

        //Inform the editor that a new portion of the editor is going to be started
        EditorGUI.BeginProperty(position, label, property);

        //Gather editable references to all of the variables needed off the script that is being edited
        SerializedProperty objectType = property.FindPropertyRelative("type");

        SerializedProperty breakablePoints = property.FindPropertyRelative("breakablePoints");

        SerializedProperty solidMoving = property.FindPropertyRelative("solidMoving");
        SerializedProperty solidStart = property.FindPropertyRelative("solidStart");
        SerializedProperty solidEnd = property.FindPropertyRelative("solidEnd");

        SerializedProperty damageType = property.FindPropertyRelative("damageType");
        SerializedProperty damageAmount = property.FindPropertyRelative("damageAmount");

        SerializedProperty healingType = property.FindPropertyRelative("healingType");
        SerializedProperty healingPickupType = property.FindPropertyRelative("healingPickupType");
        SerializedProperty healingAmount = property.FindPropertyRelative("healingAmount");

        //Display the inital dropdown for the user to select what type of object this is, 
        //with no label
        EditorGUI.PropertyField(objectTypeDisplay, objectType, GUIContent.none);

        //Display information based on what enum value the user has choosen
        switch ((ObjectType)objectType.enumValueIndex)
        {
            case ObjectType.BREAKABLE:

                //Create a rect to represent the location of the amount/points option
                Rect breakableRect = new Rect(position.x, position.y + 17, position.width, 15f);

                //Display the points option to the user, including a default label
                EditorGUI.PropertyField(breakableRect, breakablePoints);

                break;
            case ObjectType.DAMAGING:

                //Keep track of how far from the origional position.x new options will be
                float offset = position.x;

                //Create a rect to represent the location of the label "Type"
                Rect damageTypeLabelRect = new Rect(offset, position.y + 17, 47f, 17f);

                //Increase the offset, since the width of the label will be 35
                offset += 35;

                //Create the label at the appropriate location
                EditorGUI.LabelField(damageTypeLabelRect, "Type");

                //Create a rect to represent the location of the DamageType enum 
                Rect damageTypeRect = new Rect(offset, position.y + 17, position.width / 3, 17f);

                //Increase the offset
                offset += position.width / 3;

                //Create the dropdown for DamageType at the appropriate location 
                //without a default label
                EditorGUI.PropertyField(damageTypeRect, damageType, GUIContent.none);

                //Create a rect to represent the location of the label "Amount"
                Rect damageAmountLabelRect = new Rect(offset, position.y + 17, 70f, 17f);

                //Increase the offset, since the width of the label will be 55
                offset += 55;

                //Create the label at the appropriate location
                EditorGUI.LabelField(damageAmountLabelRect, "Amount");

                //Create a rect to represent the location of damageAmount int value
                Rect damageAmountRect = new Rect(offset, position.y + 17, position.width / 3, 17f);

                //Create the input field for the damageAmount at the appropriate location
                //without a default label
                EditorGUI.PropertyField(damageAmountRect, damageAmount, GUIContent.none);

                break;
            case ObjectType.HEALING:

                // Keep track of how far from the original position.x new options will be
                float offsetH = position.x;

                // First label rectange for healing
                Rect healingLabelField1Rect = new Rect(position.x, position.y + 17, position.width / 2, 17f);
                EditorGUI.LabelField(healingLabelField1Rect, "This item will heal the player's ");

                // Increment the offset from position.x
                offsetH += position.width/2 - 13f;

                // Rectangle displaying the healing types
                Rect healingTypesRect = new Rect(offsetH, position.y + 17, 77f, 15f);
                EditorGUI.PropertyField(healingTypesRect, healingType, GUIContent.none);

                // Increment offset
                offsetH += 62f;

                // Next label rectangle for healing
                Rect healingLabelField2Rect = new Rect(offsetH, position.y + 17, position.width, 17f);
                EditorGUI.LabelField(healingLabelField2Rect, "by         if it is");

                // Increment offset
                offsetH += 20f;

                // Rectangle for the amount of healing
                Rect healingAmountRect = new Rect(offsetH, position.y + 17, 45f, 17f);
                healingAmount.floatValue = EditorGUI.FloatField(healingAmountRect, healingAmount.floatValue);

                // Rectangle for the pickup type of the healing object
                Rect healingPickupTypeRect = new Rect(position.x, position.y + 34, 110f, 15f);
                EditorGUI.PropertyField(healingPickupTypeRect, healingPickupType, GUIContent.none);

                // Reset offset
                offsetH = position.x + 95f;

                // Rectangle for final label field
                Rect healingLabelField3Rect = new Rect(offsetH, position.y + 34, position.width, 17f);
                EditorGUI.LabelField(healingLabelField3Rect, "with.");

                break;
            case ObjectType.PASSABLE:

                // Rect to show there are no settings for a passable object
                Rect passableObjectLabelRect = new Rect(position.x, position.y + 17, position.width, 17f);
                EditorGUI.LabelField(passableObjectLabelRect, "There are no settings for a passable object.");

                break;
            case ObjectType.SOLID:

                //Create a rect to represent the location that the dropdown will appear
                Rect shouldMove = new Rect(position.x, position.y + 17, position.width, 17f);

                //Convert the solidMoving bool to an integer
                int index = solidMoving.boolValue ? 0 : 1;

                //Set up what the dropdown options will be
                string[] options = new string[] { "Yes", "No" };

                //Display a dropdown at the appropriate location, with a set label, 
                //displaying the value of index as the corrisponding string
                index = EditorGUI.Popup(shouldMove, "Should it move?", index, options);

                //Convert the value of index to a bool and store it in the SerializedProperty
                solidMoving.boolValue = (index <= 0);

                //If solidMoving is true
                if (solidMoving.boolValue)
                {
                    //Store the offset on the x axis
                    float offsetS = position.x;

                    //Create a rect to represent the location of the "Start Point" label
                    Rect startRect = new Rect(offsetS, position.y + 34, position.width / 2, 17f);

                    //Add to the offset the width of the label
                    offsetS += position.width / 2;

                    //Create the label
                    EditorGUI.LabelField(startRect, "Start Point");

                    //Edit a rect to represent the location of the "End Point" label
                    startRect = new Rect(offsetS, position.y + 34, position.width / 2, 17f);

                    //Add to the offset the width of the label
                    offsetS += position.width / 2;

                    //Create the label
                    EditorGUI.LabelField(startRect, "End Point");

                    //Reset the offset since the next options will be one line down
                    offsetS = position.x;

                    //Edit the rect to represent the location of the solidStart option
                    startRect = new Rect(offsetS, position.y + 50, position.width / 2, 17f);

                    //Add to the offset the width of the option
                    offsetS += position.width / 2;

                    //Display the option with no label
                    EditorGUI.PropertyField(startRect, solidStart, GUIContent.none);

                    //Edit the rect to represent the location of the solidEnd option
                    startRect = new Rect(offsetS, position.y + 50, position.width / 2, 17f);

                    //Display the option with no label
                    EditorGUI.PropertyField(startRect, solidEnd, GUIContent.none);
                }

                break;
        }

        //Inform the editor this is the end of the custom information
        EditorGUI.EndProperty();

    }

    //Gets the height of the property
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        //Increases the height of the property by extraHeight
        return base.GetPropertyHeight(property, label) + extraHeight;

    }
}