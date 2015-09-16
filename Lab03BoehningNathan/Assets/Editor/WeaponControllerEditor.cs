using UnityEditor;

[CustomEditor(typeof(WeaponController))]
public class WeaponControllerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        //Update the serializedObject for array alterations
        serializedObject.Update();

        //Get an editable of the ObjectType[] controllerObjects on the script
        SerializedProperty controller = serializedObject.FindProperty("weaponTypes");

        //Display the foldout for the ObjectType array
        EditorGUILayout.PropertyField(controller);

        //Apply any changes to the script
        serializedObject.ApplyModifiedProperties();
    }
}