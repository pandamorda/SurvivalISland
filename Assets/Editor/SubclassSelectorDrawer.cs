using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using _Project.Scripts.Gameplay.Interaction.Behaviors;

namespace _Project.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(SubclassSelectorAttribute))]
    public class SubclassSelectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Type baseType = fieldInfo.FieldType;
            
            List<Type> options = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => baseType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToList();
            
            string[] names = new string[options.Count + 1];
            names[0] = "(none)";
            for (int i = 0; i < options.Count; i++)
                names[i + 1] = options[i].Name;
            
            int currentIndex = 0;
            string currentTypeName = property.managedReferenceFullTypename;
            if (!string.IsNullOrEmpty(currentTypeName))
            {
                string shortName = currentTypeName.Split(' ').Last().Split('.').Last();
                currentIndex = Array.FindIndex(names, n => n == shortName);
                if (currentIndex < 0) currentIndex = 0;
            }
            
            Rect dropdownRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            int newIndex = EditorGUI.Popup(dropdownRect, label.text, currentIndex, names);
            
            if (newIndex != currentIndex)
            {
                property.managedReferenceValue = newIndex == 0 
                    ? null 
                    : Activator.CreateInstance(options[newIndex - 1]);
            }
            
            Rect propertyRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, 
                position.width, position.height - EditorGUIUtility.singleLineHeight - 2);
            EditorGUI.PropertyField(propertyRect, property, GUIContent.none, true);
        }
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true) + EditorGUIUtility.singleLineHeight + 2;
        }
    }
}