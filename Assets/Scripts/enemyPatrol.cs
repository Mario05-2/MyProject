using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb; 
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    private bool isIdle = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("Moving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle) return;

        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            StartCoroutine(IdleCoroutine());
        }

        anim.SetBool("isRunning?", rb.velocity != Vector2.zero);
    }

    private IEnumerator IdleCoroutine()
    {
        isIdle = true;
        rb.velocity = Vector2.zero;
        anim.SetBool("Moving", false);

        yield return new WaitForSeconds(2);

        if (currentPoint == pointB.transform)
        {
            Flip();
            currentPoint = pointA.transform;
        }
        else
        {
            Flip();
            currentPoint = pointB.transform;
        }

        anim.SetBool("Moving", true);
        isIdle = false;
    }

    public void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}