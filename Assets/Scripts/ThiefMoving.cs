using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThiefMoving : MonoBehaviour
{
    [SerializeField] private float speed;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _rigidbody.velocity = Vector2.right * speed;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            speed *= -1;
        }
    }
}
