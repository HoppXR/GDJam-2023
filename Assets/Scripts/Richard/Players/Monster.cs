using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    private Vector2 _moveDirection2;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init2(this); // Initialize monster controls separately
        InputManager.SetGameControls(); // Enable monster controls
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDirection2);
    }

    public void SetMovementDirection(Vector2 currentDirection)
    {
        _moveDirection2 = currentDirection;
    }
}