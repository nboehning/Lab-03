using UnityEditor;

[CustomEditor(typeof(EnemyController))]
public class EnemyControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        //Update the serializedObject for array alterations
        serializedObject.Update();

        //Get an editable of the ObjectType[] controllerObjects on the script
        SerializedProperty enemyController = serializedObject.FindProperty("enemyTypes");

        //Display the foldout for the ObjectType array
        EditorGUILayout.PropertyField(enemyController);

        //Apply any changes to the script
        serializedObject.ApplyModifiedProperties();
    }
}
