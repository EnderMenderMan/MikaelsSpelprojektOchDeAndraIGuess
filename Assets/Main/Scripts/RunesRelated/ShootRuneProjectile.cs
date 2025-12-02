using UnityEngine;

public class ShootRuneProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Interactable") == false)
            return;
        IInteract interact = col.GetComponent<IInteract>();
        interact.OnInteract(new InteractData { type = InteractType.Bullet, senderObject = gameObject });
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
