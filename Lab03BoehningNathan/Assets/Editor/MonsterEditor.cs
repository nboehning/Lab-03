using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ScriptMonster))]
public class ScriptMonsterEditor : Editor 
{

	ScriptMonster monsterScript;

	bool visibleRange = false;
	bool transitionRange = false;
	bool spawnTypes = false;

	void Awake()
	{
		monsterScript = (ScriptMonster)target;
	}

	public override void OnInspectorGUI()
	{
		// Display a foldout, with the default value stored in the visible Range and label "Visibility Settings"
		// As the foldout is manipulated, save changes into visibleRange
		visibleRange = EditorGUILayout.Foldout (visibleRange, "Visibility Settings");

		// If statement that is true when the foldout is opened. Everything in if statement will appear.

		// For inside "Visible Settings" foldout
		if(visibleRange)
		{
			// Increase indent level
			EditorGUI.indentLevel++;

			// The variable VariableVisibleTime on the monsterScript should equal the setting the user picked for the toggle
			// The toggle should display the variable VariableVisibleTime
			monsterScript.VariableVisibleTime = EditorGUILayout.Toggle ("Variable Visible Time?",
			                                                            monsterScript.VariableVisibleTime);

			if (monsterScript.VariableVisibleTime)
			{
				EditorGUILayout.LabelField("Maximum - Minimum Time");
				EditorGUILayout.BeginHorizontal();

				//Since I manually created the label above, I am using an overload of the Float Field so no default label 
				//is displayed immediately before it.
				monsterScript.VisibleTimeMax = EditorGUILayout.FloatField(monsterScript.VisibleTimeMax);
				monsterScript.VisibleTimeMin = EditorGUILayout.FloatField(monsterScript.VisibleTimeMin);
				EditorGUILayout.EndHorizontal();
			}
			else
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.PrefixLabel("Visible Time:");

				//Again, I manually created a prefix label to display so I am overloading the float field so no
				//default label is shown
				monsterScript.VisibleTimeMax = EditorGUILayout.FloatField(monsterScript.VisibleTimeMax);
				EditorGUILayout.EndHorizontal();
			}

			// Decrease indent level
			EditorGUI.indentLevel--;
		}

		EditorGUILayout.Space ();

		// Repeat for transition settings
		transitionRange = EditorGUILayout.Foldout (transitionRange, "Transition Settings");
		if (transitionRange)
		{
			//Increase the indent level by one 
			EditorGUI.indentLevel++;
			
			//The variable VariableTransitionTime on the monsterScript should equal the setting the user picked for the 
			// toggle
			//The toggle should display the variable VariableTransitionTime
			monsterScript.VariableTransitionTime = EditorGUILayout.Toggle("Variable Transition Time?",
			                                                              monsterScript.VariableTransitionTime);
			
			if (monsterScript.VariableTransitionTime)
			{
				EditorGUILayout.LabelField("Maximum - Minimum Time");
				EditorGUILayout.BeginHorizontal();
				//Since I manually created the label above, I am using an overload of the Float Field so no default label 
				//is displayed immediately before it.
				monsterScript.TransitionTimeMax = EditorGUILayout.FloatField(monsterScript.TransitionTimeMax);
				monsterScript.TransitionTimeMin = EditorGUILayout.FloatField(monsterScript.TransitionTimeMin);
				EditorGUILayout.EndHorizontal();
			}
			else
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.PrefixLabel("Transition Time:");
				//Again, I manually created a prefix label to display so I am overloading the float field so no
				//default label is shown
				monsterScript.TransitionTimeMax = EditorGUILayout.FloatField(monsterScript.TransitionTimeMax);
				EditorGUILayout.EndHorizontal();
			}
			
			//Reduce the indent level by one
			EditorGUI.indentLevel--;
		}
		
		EditorGUILayout.Space();

		// Repeat for spawn types, however they will be handled differently.
		spawnTypes = EditorGUILayout.Foldout (spawnTypes, "Spawn Settings");
		if (spawnTypes)
		{
			EditorGUI.indentLevel++;

			// Sync the object with script.
			serializedObject.Update();

			// Show the array field.
			EditorGUILayout.PropertyField(serializedObject.FindProperty("possibleTypes"), true);

			EditorGUI.indentLevel--;
		}

		EditorGUILayout.Space ();

		// Display point value
		monsterScript.PointWorth = EditorGUILayout.IntField ("Points Worth: ", monsterScript.PointWorth);

		// Apply all changes to the object
		serializedObject.ApplyModifiedProperties ();
	}
}
