using UnityEngine;

/// <summary>
/// This class is a base class for all game scene handlers
/// This is first part of implementation of GameSceneSO
/// </summary>

public abstract partial class GameSceneSO : ScriptableObject
{
    [Header("Information")]

#if UNITY_EDITOR
    public UnityEditor.SceneAsset sceneAsset;
#endif

    [HideInInspector]
    public string scenePath;

    [TextArea] public string shortDescription;

    [Header("Sounds")]
    public AudioClip music;

}
