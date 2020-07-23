using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class LevelDesignerTool : EditorWindow
{
    [MenuItem("Tool/Level Design Tool")]
    public static void OpenWindow() => GetWindow<LevelDesignerTool>("Level Design");

    SerializedObject so;
    SerializedProperty propSize;
    JewelleryDesignData design;

    GameObject gameObject;
    Editor gameObjectEditor;

    SerializedProperty propTheme;
    GameObject[] tempelates;

    int selectedTempelateIndex = -1;
    //int last = 0;
    GameObject newGem;
    int sectionCount;
    GameObject[] section;
    GameObject newGameObject;
    public string savePath = "Assets/Jewellery/Prefabs/";
    SerializedProperty propSavePath;
    public string fileName;
    SerializedProperty propFileName;
    SerializedObject thisObj;

    private void OnEnable()
    {
        if (design == null)
        {
            so = new SerializedObject(new JewelleryDesignData());
            propSize = so.FindProperty("size");
            propTheme = so.FindProperty("theme");
        }

        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Tool/Design Tempelate"});
        IEnumerable<string> paths = guids.Select(AssetDatabase.GUIDToAssetPath);
        tempelates = paths.Select(AssetDatabase.LoadAssetAtPath<GameObject>).ToArray();

        thisObj = new SerializedObject(this);
        propSavePath = thisObj.FindProperty("savePath");
        propFileName = thisObj.FindProperty("fileName");
    }

    private void OnGUI()
    {
        so.Update();
        GUILayout.Space(10);
        using (new GUILayout.HorizontalScope(EditorStyles.helpBox))
        {
            GUILayout.Height(20);
            GUILayout.Label("Design Data :", GUILayout.Width(100));
            EditorGUI.BeginChangeCheck();
            design = (JewelleryDesignData)EditorGUILayout.ObjectField(design, typeof(JewelleryDesignData), false);
            if (EditorGUI.EndChangeCheck())
            {                
                so = new SerializedObject(design);
                propSize = so.FindProperty("size");
                propTheme = so.FindProperty("theme");
                //gameObject = design.jewellerySize[(int)design.size];
                fileName = "Design_" + design.theme.name + "_L00";
                EditorUtility.SetDirty(design);
            }
        }
    
        GUILayout.Space(10);

        EditorGUILayout.PropertyField(propSize);
        EditorGUILayout.PropertyField(propTheme);

        //display design tempelate button
        GUILayout.Space(10);
        
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.LabelField("Select Design Tempelate", EditorStyles.boldLabel);
            using (new GUILayout.HorizontalScope())
            {
                for (int i = 0; i < tempelates.Length; i++)
                {
                    Texture icon = AssetPreview.GetAssetPreview(tempelates[i]);
                    EditorGUI.BeginChangeCheck();
                    if (GUILayout.Toggle(selectedTempelateIndex == i, icon))
                    {
                        if (EditorGUI.EndChangeCheck())
                        {
                            //selectedTempelateGameObject = tempelates[i];
                            selectedTempelateIndex = i;
                            sectionCount = design.tempelateDesignData[i].uniqueSection;
                            section = new GameObject[sectionCount];
       
                        }
                    }
                }
            }
        }
        so.ApplyModifiedProperties();

        if (GUILayout.Button("Generate Design"))
        {
            GenerateDesign();
        }

        thisObj.Update();
        using (new GUILayout.VerticalScope(EditorStyles.helpBox))
        {
            EditorGUILayout.PropertyField(propSavePath);
            EditorGUILayout.PropertyField(propFileName);

            if (GUILayout.Button("Save"))
            {
                var newPath = savePath + fileName +".prefab";
                PrefabUtility.SaveAsPrefabAssetAndConnect(newGameObject, newPath, InteractionMode.UserAction);
            }
        }
        thisObj.ApplyModifiedProperties();

        if (gameObject != null )
        {
            if (gameObjectEditor == null)
            {
                gameObjectEditor = Editor.CreateEditor(gameObject);
                gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(500, 500, EditorStyles.foldout), EditorStyles.whiteLabel);
            }
            else
            {
                Editor.CreateCachedEditor(gameObject, null, ref gameObjectEditor);
                gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(500, 500, EditorStyles.foldout), EditorStyles.whiteLabel);
            }
        } 
    }

    private void GenerateDesign()
    {
        if (newGameObject != null)
        {
            DestroyImmediate(newGameObject);
        }
        newGameObject = new GameObject();
        var selectedSize = design.jewellerySize[(int)design.size];
        var selectedTempelateDesignData = design.tempelateDesignData[selectedTempelateIndex]
                                            .tempelateSizeVarient[(int)design.size].designData;

        var themeSlot = design.theme;
        for (int j = 0; j < section.Length; j++)
        {
            section[j] = themeSlot.gem[Random.Range(0, themeSlot.gem.Length)];
        }

        for (int i = 0; i < selectedTempelateDesignData.Length; i++)
        {
            var current = selectedTempelateDesignData[i];

            switch (current)
            {
                case 1:
                    newGem = section[0];
                    break;
                case 2:
                    newGem = section[1];
                    break;
                case 3:
                    newGem = section[2];
                    break;
            }

            var newSpawnedGem = (GameObject)PrefabUtility.InstantiatePrefab(newGem, newGameObject.transform);
            var childTransform = selectedSize.transform.GetChild(i);

            newSpawnedGem.transform.position = childTransform.position;
            newSpawnedGem.transform.rotation = childTransform.rotation;
        }
        gameObject = newGameObject;
    }

    private void OnDestroy()
    {
        DestroyImmediate(newGameObject);
    }

}
