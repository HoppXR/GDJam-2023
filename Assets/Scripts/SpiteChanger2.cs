using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SpriteChanger2 : MonoBehaviour
    {
        public Sprite spL, spR, spU, spD;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().sprite = spL;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GetComponent<SpriteRenderer>().sprite = spR;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetComponent<SpriteRenderer>().sprite = spU;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                GetComponent<SpriteRenderer>().sprite = spD;
            }
        }
    }
