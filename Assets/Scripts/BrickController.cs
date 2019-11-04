using UnityEngine;

public class BrickController : MonoBehaviour
{
    int _brickLife = 2;
    SpriteRenderer _spriteRenderer;
    public Sprite _newSprite;

    PlayerController _player;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _brickLife = _brickLife - 1;
            _player.AddScore(100);
            if(_brickLife < 1)
            {
                Destroy(gameObject);
            }
            else
            {
                _spriteRenderer.sprite = _newSprite;
            }
        }
    }
}
