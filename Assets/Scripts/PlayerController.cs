using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    float _xRange = 8.30f;
    [SerializeField] float _MovementSpeed = 8.0f;
    public GameObject _ball;

    private Rigidbody2D rb2d;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI launchBallText;

    int _score = 0;
    bool _isDead = false;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _ball = Instantiate(_ball, new Vector3(0.0f, 0.0f), _ball.transform.rotation);
        _ball.GetComponent<Rigidbody2D>().velocity = Vector2.down * 0.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            launchBallText.gameObject.SetActive(false);
            _ball.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10.0f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (_isDead)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    void CalculateMovement()
    {
        var vel = rb2d.velocity;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -_MovementSpeed;
        }  
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = _MovementSpeed;
        }
        else
        {
            vel.x = 0;
        }

        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.x < -_xRange)
        {
            pos.x = -_xRange;
        } 
        else if(pos.x > _xRange)
        {
            pos.x = _xRange;
        }

        transform.position = pos;
    }

    public void AddScore(int points)
    {
        _score += points;
        scoreText.text = "Score: " + _score;
    }

    public void IsDead(bool isDead)
    {
        _isDead = isDead;
    }
}