using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof (ObjectController))]
public class ObjectControllerEditor : Editor
{

    private ObjectController controllerScript;


    private void Awake()
    {
        //Capture a reference to the script that is being edited
        controllerScript = (ObjectController) target;
    }

    public override void OnInspectorGUI()
    {
        //Update the serializedObject for array alterations
        serializedObject.Update();

        //Get an editable of the ObjectType[] controllerObjects on the script
        SerializedProperty controller = serializedObject.FindProperty("controllerObjects");

        //Display the foldout for the ObjectType array
        EditorGUILayout.PropertyField(controller);

        //Determine if the foldout is set to display the elements of the array
        if (controller.isExpanded)
        {
            //Get an editable copy of the array size for the user, and then display it
            EditorGUILayout.PropertyField(controller.FindPropertyRelative("Array.size"));

            //Increase the indent level
            EditorGUI.indentLevel++;

            //Go through each element of the array and display it
            for (int i = 0; i < controller.arraySize; i++)
            {
                EditorGUILayout.PropertyField(controller.GetArrayElementAtIndex(i));
            }

            //Decreate the indent level
            EditorGUI.indentLevel--;
        }

        //Apply any changes to the script
        serializedObject.ApplyModifiedProperties();
    }
}