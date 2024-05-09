using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHumanMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _input;
    private bool _isMoving;
    private bool _isGrounded;
    private bool _isFlying;

    public Rigidbody2D _rigidbody;
    private MainHumanAnimation _animations;
    [SerializeField] private SpriteRenderer _MainHumanSprite;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<MainHumanAnimation>();
    }

 
    private void Update()
    {
        Move();
        Jump();
        CheckingGround();
    }

	private void Move()
	{
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;
        if (_isMoving) 
        {
            _MainHumanSprite.flipX = _input.x > 0 ? false : true;
        }
        _animations.IsMoving = _isMoving;
	}

    public float jumpForce = 7f;
    private void Jump()
    {
		if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //_rigidbody.velocity = new Vector2(_input.x, jumpForce);

		    _rigidbody.AddForce(Vector2.up * jumpForce);
        }
    }

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    
    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        if (onGround)
            Debug.Log("ONGROUND");

    }
}
