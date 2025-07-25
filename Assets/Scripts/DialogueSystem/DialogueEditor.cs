// using UnityEditor;
// using UnityEngine;

// [CustomEditor(typeof(DialogueManager))]
// public class DialogueEditor : Editor
// {
//     SerializedProperty dialoghi;

//     void OnEnable() => dialoghi = serializedObject.FindProperty("dialoghi");

//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();

//         EditorGUILayout.PropertyField(serializedObject.FindProperty("scenaCorrente"));
//         EditorGUILayout.PropertyField(serializedObject.FindProperty("finaliSbloccati"));

//         var lore = serializedObject.FindProperty("lore");
//         EditorGUILayout.LabelField("Lore Flags");
//         EditorGUI.indentLevel++;
//         for (int i = 0; i < lore.arraySize; i++)
//         {
//             var prop = lore.GetArrayElementAtIndex(i);
//             switch (i)
//             {
//                 case 0:
//                     prop.boolValue = EditorGUILayout.Toggle($"Ciclo eterno", prop.boolValue);
//                     break;
//                 case 1:
//                     prop.boolValue = EditorGUILayout.Toggle($"Extra pass", prop.boolValue);
//                     break;
//                 case 2:
//                     prop.boolValue = EditorGUILayout.Toggle($"Gioco esterno", prop.boolValue);
//                     break;
//                 case 3:
//                     prop.boolValue = EditorGUILayout.Toggle($"Fase 1", prop.boolValue);
//                     break;
//                 case 4:
//                     prop.boolValue = EditorGUILayout.Toggle($"Fase 2", prop.boolValue);
//                     break;
//                 case 5:
//                     prop.boolValue = EditorGUILayout.Toggle($"Fase 3", prop.boolValue);
//                     break;

//                 default:
//                     break;
//             }
//         }
//         EditorGUI.indentLevel--;

//         EditorGUILayout.Space(10);
//         EditorGUILayout.LabelField("Dialoghi", EditorStyles.boldLabel);

//         for (int i = 0; i < dialoghi.arraySize; i++)
//         {
//             SerializedProperty dialogo = dialoghi.GetArrayElementAtIndex(i);
//             SerializedProperty testo = dialogo.FindPropertyRelative("Testo");
//             SerializedProperty scena = dialogo.FindPropertyRelative("Scena");
//             SerializedProperty finali = dialogo.FindPropertyRelative("FinaliSbloccati");
//             SerializedProperty flags = dialogo.FindPropertyRelative("LoreFlags");

//             EditorGUILayout.BeginVertical("box");
//             EditorGUILayout.PropertyField(testo);
//             EditorGUILayout.PropertyField(scena);
//             EditorGUILayout.PropertyField(finali);

//             EditorGUILayout.LabelField("Lore Richiesti:");
//             EditorGUI.indentLevel++;
//             for (int j = 0; j < flags.arraySize; j++)
//             {
//                 var flag = flags.GetArrayElementAtIndex(j);
//                 flag.boolValue = EditorGUILayout.Toggle($"Lore{j + 1}", flag.boolValue);
//             }
//             EditorGUI.indentLevel--;
//             EditorGUILayout.EndVertical();
//         }

//         if (GUILayout.Button("Aggiungi Dialogo"))
//         {
//             dialoghi.InsertArrayElementAtIndex(dialoghi.arraySize);
//         }

//         serializedObject.ApplyModifiedProperties();
//     }
// }
