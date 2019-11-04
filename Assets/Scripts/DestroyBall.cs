using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    float _outOfBounds = -5.25f;
    PlayerController _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(gameObject.transform.position.y < _outOfBounds && gameObject.CompareTag("Ball"))
        {
            _player.IsDead(true);
            Destroy(gameObject);
        }
    }
}
