using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class TDMovement : MonoBehaviour
    {
        private float moveSpeed;
        public Rigidbody2D rb;
        private Vector2 moveInput;

        // Define custom input keys for movement
        public KeyCode moveUpKey = KeyCode.W;
        public KeyCode moveLeftKey = KeyCode.A;
        public KeyCode moveDownKey = KeyCode.S;
        public KeyCode moveRightKey = KeyCode.D;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Check for WASD key presses
            moveInput = Vector2.zero;
        
            if (Input.GetKey(moveUpKey))
            {
                moveInput.y = 1;
            }
            else if (Input.GetKey(moveDownKey))
            {
                moveInput.y = -1;
            }
        
            if (Input.GetKey(moveLeftKey))
            {
                moveInput.x = -1;
            }
            else if (Input.GetKey(moveRightKey))
            {
                moveInput.x = 1;
            }
        
            moveInput.Normalize();

            rb.velocity = moveInput * moveSpeed;
        }
    }


