using UnityEngine;

public class ennemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] wayPoints;
    private Transform target;
    private int destPoint = 0;
    public SpriteRenderer spriteRenderer;



    void Start()
    {
        target = wayPoints[0];
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized*speed*Time.deltaTime,Space.World);
        // Si l'ennemi est casiment arrrivé à destination 
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        

    }

}
