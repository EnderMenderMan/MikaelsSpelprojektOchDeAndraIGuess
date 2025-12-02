using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class SeeInvis : Rune
{
    [SerializeField] UnityEvent onPickup;
    [SerializeField] UnityEvent onDrop;
    public override void OnInteract(InteractData data)
    {
        switch (data.type)
        {
            case InteractType.Player:

                base.OnInteract(data);
                onPickup.Invoke();

                break;
        }
    }

    public override void OnDropped()
    {
        base.OnDropped();
        onDrop.Invoke();
    }
}
