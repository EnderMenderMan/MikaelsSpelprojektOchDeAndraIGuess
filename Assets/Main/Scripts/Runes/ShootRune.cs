using UnityEngine;

public class ShootRune : MonoBehaviour
{
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectileObject.GetComponent<Rigidbody2D>();
        //projectileRb.linearVelocity = ;
    }

    void OnEnable()
    {
        PlayerInteract.Instance.OnActivateRuneAbility.AddListener(Shoot);
    }
    void OnDisable()
    {
        PlayerInteract.Instance.OnActivateRuneAbility.RemoveListener(Shoot);
    }
}
