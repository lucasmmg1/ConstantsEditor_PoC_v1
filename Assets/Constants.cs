using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Constants : ScriptableObject
{
}

public class ConstantsEditorWindow : EditorWindow
{
    #region Variables

    #region Private Variables

    private int _tabs, _currentAddedTab;
    private List<string> _tabsOptions = new();

    #endregion
    
    #region Protected Variables

    [SerializeField] protected Constants constantsScriptableObject;

    #endregion

    #endregion
    
    #region Methods

    #region Protected Methods

    protected void OnPlusButtonClicked()
    {
        _currentAddedTab++;
                
        if (_tabsOptions.Count >= 4)
            _tabsOptions.RemoveAt(0);

        _tabsOptions.Add($"New Constants {_currentAddedTab}");
    }

    #endregion
    
    #region Public Methods

    [MenuItem("Window/Constants Editor")]
    public static void ShowWindow()
    {
        var instance = GetWindow(typeof(ConstantsEditorWindow), false, "Constants Editor");
        instance.minSize = new Vector2(300, 300);
        instance.maxSize = new Vector2(300, 300);
    }
    
    public void OnGUI()
    {
        switch (_tabsOptions.Count)
        {
            case 0:
                EditorGUILayout.BeginHorizontal();
                {
                    var plusButtonStyle = new GUIStyle(GUI.skin.button)
                    {
                        fixedWidth = 30f
                    };
                    if (GUILayout.Button("+", plusButtonStyle))
                        OnPlusButtonClicked();
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox("Teste", MessageType.Info);
                break;

            case > 0:
                EditorGUILayout.BeginHorizontal();
                {
                    _tabs = GUILayout.Toolbar(_tabs, _tabsOptions.ToArray());
                    _tabs = _tabsOptions.Count - 1;
                    
                    var plusButtonStyle = new GUIStyle(GUI.skin.button)
                    {
                        fixedWidth = 30f
                    };
                    if (GUILayout.Button("+", plusButtonStyle))
                        OnPlusButtonClicked();
                }
                EditorGUILayout.EndHorizontal();
                
                EditorGUILayout.ObjectField(new GUIContent("Constants"), constantsScriptableObject, typeof(Constants), false);
                EditorGUILayout.Space();
                
                if (constantsScriptableObject == null)
                    EditorGUILayout.HelpBox("Teste", MessageType.Info);
                else
                    _tabsOptions[_tabs] = constantsScriptableObject.name;

                break;
        }
    }

    #endregion

    #endregion
}