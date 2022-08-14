using UnityEngine;

/// <summary>
/// This class helps to animate repetative actions / movements
/// It can be used mainly for idle animations
/// </summary>

[CreateAssetMenu(menuName = "Variable / Animation Data")]
public class AnimationDataSO : ScriptableObject
{
    [SerializeField] private AnimationCurve _animationCurve = default;
    [SerializeField] private FloatReference _animationTime = default;

    // To prevent having to match animation time in animation curve
    private float AnimationSpeed => _animationCurve.keys[_animationCurve.length - 1].time / _animationTime.Value;

    public float Evaluate(float time, float animationTime)
    {
        return _animationCurve.Evaluate(time * AnimationSpeed);
    }

}
