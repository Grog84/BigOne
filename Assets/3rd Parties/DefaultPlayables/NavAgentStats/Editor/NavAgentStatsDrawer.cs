using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.AI;

[CustomPropertyDrawer(typeof(NavAgentStatsBehaviour))]
public class NavAgentStatsDrawer : PropertyDrawer
{
    public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
    {
        int fieldCount = 3;
        return fieldCount * EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty speedProp = property.FindPropertyRelative("speed");
        SerializedProperty accelerationProp = property.FindPropertyRelative("acceleration");
        SerializedProperty angularSpeedProp = property.FindPropertyRelative("angularSpeed");

        Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(singleFieldRect, speedProp);

        singleFieldRect.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(singleFieldRect, accelerationProp);

        singleFieldRect.y += EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(singleFieldRect, angularSpeedProp);
    }
}
