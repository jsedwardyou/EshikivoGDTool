using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Eshikivo.Utils.Prefab {
    
    public class PrefabEditor: Editor
    {
        private const string COMPONENTS = "components";
        private const string PREFAB_PATHS = "prefabPaths";

        [MenuItem("Eshikivo/Prefab/Rebuild Resources")]
        private static void ConfigureResource()
        {
            PrefabInfoMap infoMap = Resources.LoadAll<PrefabInfoMap>("")[0];
            
            var serializedObj = new SerializedObject(infoMap);
            ClearPrefabInfoMap(serializedObj);
            
            PrefabResource[] prefabs = Resources.LoadAll<PrefabResource>("");
            foreach (var prefab in prefabs)
            {
                string prefabPath = AssetDatabase.GetAssetPath(prefab);
                prefabPath = prefabPath.Substring(prefabPath.IndexOf("Resources") + "Resources".Length + 1);
                prefabPath = prefabPath.Substring(0, prefabPath.IndexOf(".prefab"));

                int size = serializedObj.FindProperty(COMPONENTS).arraySize;
                var componentsObj = serializedObj.FindProperty(COMPONENTS);
                var prefabPathsObj = serializedObj.FindProperty(PREFAB_PATHS);
                
                componentsObj.InsertArrayElementAtIndex(size);
                prefabPathsObj.InsertArrayElementAtIndex(size);

                componentsObj.GetArrayElementAtIndex(size).stringValue = prefab.GetType().ToString().Split(".").Last();
                prefabPathsObj.GetArrayElementAtIndex(size).stringValue = prefabPath;

                Debug.Log($"set {prefab.name} path to {prefabPath}");
            }
            
            serializedObj.ApplyModifiedProperties();

            GameObject instance = FindObjectOfType<PrefabInfoMap>().gameObject;

            if (instance == null) return;
            
            PrefabUtility.RevertPrefabInstance(instance, InteractionMode.UserAction);
        }

        private static void ClearPrefabInfoMap(SerializedObject serializedObj)
        {
            int size = serializedObj.FindProperty(COMPONENTS).arraySize;
            for (int i = 0; i < size; i++)
            {
                serializedObj.FindProperty(COMPONENTS).DeleteArrayElementAtIndex(0);
                serializedObj.FindProperty(PREFAB_PATHS).DeleteArrayElementAtIndex(0);
            }
        }

    }
}