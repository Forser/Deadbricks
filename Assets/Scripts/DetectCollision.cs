using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private Rigidbody2D rb2d;
    float _forceSpeed = 10.0f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.collider.gameObject.CompareTag("Obstacle"))
        {
            if(collision.gameObject.name == "Player")
            {
                float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);

                Vector2 dir = new Vector2(x, 1).normalized;
                rb2d.velocity = dir * _forceSpeed;
            }
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 padPos, float padWidth)
    {
        return (ballPos.x - padPos.x) / padWidth;
    }
}
