#if UNITY_EDITOR
using System;
using UnityEngine;
using UnityEditor;

/// <summary>
/// This is second part of implementation of GameSceneSO
/// This part is responsible for editor-related functionality
/// </summary>

public abstract partial class GameSceneSO : ScriptableObject, ISerializationCallbackReceiver
{
    public static Action<GameSceneSO> onEnabled;

    private SceneAsset prevSceneAsset;

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        PopulateScenePath();
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    { }

    private void OnEnable()
    {
        // In case domain was not reloaded after entering play mode
        prevSceneAsset = null;
        PopulateScenePath();
        onEnabled?.Invoke(this);
    }

    private void PopulateScenePath()
    {
        if (sceneAsset != null)
        {
            // To prevent constant invocation of AssetDatabase API
            // when this SO is opened in the Inspector.
            if (prevSceneAsset != sceneAsset)
            {
                prevSceneAsset = sceneAsset;
                scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            }
        }
        else
        {
            scenePath = string.Empty;
        }
    }
}

#endif