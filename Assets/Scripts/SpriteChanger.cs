using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite spL, spR, spU, spD;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = spL;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = spR;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<SpriteRenderer>().sprite = spU;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = spD;
        }
    }
}
