using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AbilityDash : MonoBehaviour
{
    Rigidbody2D rb;
 
    public float moveSpeed;
    Vector2 movement;
 
    //Dash
    [SerializeField] float startDashTime = 0.3f;
    [SerializeField] float dashSpeed = 15f;
    float currentDashTime;
 
    bool canDash = true;
    bool canMove = true;
 
    
    //Cooldown
    [SerializeField] private float cooldownTime;
    private float _nextDashTime;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        DashDir();
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            movement.Normalize();
            rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }  
    }

    // Jaden added this
    public void StartDash()
    {
        if (canDash)
        {
            StartCoroutine(Dash(movement.normalized));
            _nextDashTime = Time.time + cooldownTime;
            Debug.Log("Dash Initiated!");
        }
    }

    IEnumerator Dash(Vector2 direction)
    {
        canDash = false;
        canMove = false;
        currentDashTime = startDashTime;
 
        while (currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime;
 
            rb.velocity = direction * dashSpeed;
 
            yield return null;
        }
 
        rb.velocity = new Vector2(0f, 0f);
 
        canDash = true;
        canMove = true;
    }

    void DashDir()
    {
        //Plyaer Movement Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
 
        //Dash if not currently dashing and pressed space
        if (Time.time > _nextDashTime && canDash && Input.GetKeyDown(KeyCode.Space))
        {//Diagonal Dashing
            _nextDashTime = Time.time + cooldownTime;
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(Dash(new Vector2(1f, 1f)));
            }
 
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                StartCoroutine(Dash(new Vector2(1f, -1f)));
            }
 
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                StartCoroutine(Dash(new Vector2(-1f, 1f)));
            }
 
            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                StartCoroutine(Dash(new Vector2(-1f, -1f)));
            }
            //WASD direction dashing
            else if (Input.GetKey(KeyCode.W))
            {
                StartCoroutine(Dash(Vector2.up));
            }
 
            else if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine(Dash(Vector2.left));
            }
 
            else if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine(Dash(Vector2.down));
            }
 
            else if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine(Dash(Vector2.right));
            }
        }
    }
}