using UnityEngine;
using UnityEngine.Events;

public class RuneAfterEvents : MonoBehaviour
{
    // [Tooltip("After the rune is pick up from alter or ground")] public UnityEvent afterPickup;
    // [Tooltip("After the rune is pick up from ground")] public UnityEvent afterGroundPickup;
    // [Tooltip("After the rune is pick up from alter")] public UnityEvent afterAlterPickup;
    [Tooltip("After player drops the rune to the ground")] public UnityEvent afterDrop;
    [Tooltip("After player places the rune on alter")] public UnityEvent afterAlterPlaced;
    [Tooltip("After rune is kick of alter by an effect (not player)")] public UnityEvent afterAlterKicked;
}
