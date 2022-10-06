using System.Collections;
using UnityEngine;

public abstract class Destroyable : MonoBehaviour
{
    [Header("Animation Settings")]
    public GameObject particleOnDestroy;
    public float animationFadeOutTime;

    public abstract void DoDestroy();
    public abstract IEnumerator DelayedDestroy();
}