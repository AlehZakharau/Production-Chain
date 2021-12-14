using UnityEditor;
using UnityEngine;

namespace GameLogic.Manufacture
{
    [CustomEditor(typeof(BuildingInitData))]
    [CanEditMultipleObjects]
    public class BuildingInitDataEditor : Editor
    {
        SerializedProperty buildingsType;
    
        void OnEnable()
        {
            buildingsType = serializedObject.FindProperty("BuildingInitData");
        }
        
        // public override void OnInspectorGUI()
        // {
        //     serializedObject.Update();
        //     EditorGUILayout.PropertyField(buildingsType);
        //     serializedObject.ApplyModifiedProperties();
        //
        //     if (buildingsType.type == BuildingsType.Refinery.ToString())
        //     {
        //         
        //     }
        // }
    }
}