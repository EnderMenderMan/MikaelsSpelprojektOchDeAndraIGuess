using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RunRune : Rune
{
    [SerializeField] float moveForce;
    [SerializeField] float moveMaxForce;
    [SerializeField] float distanceWhenStartStop;
    [SerializeField] Transform[] moveToPoints;
    int moveToPointsIndex;
    Rigidbody2D rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, moveToPoints[moveToPointsIndex].position) <= distanceWhenStartStop)
        {
            moveToPointsIndex++;
            moveToPointsIndex %= moveToPoints.Length;
        }

        Vector2 distanceVecToPoint = moveToPoints[moveToPointsIndex].position - transform.position;
        // float sameDir = Vector2.Dot(rb.linearVelocity, distanceVecToPoint) - (distanceVecToPoint.magnitude * rb.linearVelocity.magnitude);
        // if (Mathf.Abs(sameDir) < 0.2 && rb.linearVelocity.magnitude >= moveMaxForce)
        // 	return;
        distanceVecToPoint.Normalize();
        distanceVecToPoint *= moveMaxForce;
        Vector2 vectorDif = distanceVecToPoint - rb.linearVelocity;
        if (vectorDif.magnitude < moveForce * Time.deltaTime)
            rb.linearVelocity = distanceVecToPoint;
        else
            rb.linearVelocity += vectorDif.normalized * moveForce * Time.deltaTime;
    }
}
