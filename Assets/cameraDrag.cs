using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraDrag : MonoBehaviour
{
    private bool ctrlPressed;
    private float dragSpeed = 2;
    private Vector3 dragOrigin;

    void Start()
    {
        ctrlPressed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) == true)
        {
            ctrlPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) == true)
        {
            ctrlPressed = false;
        }

        if (ctrlPressed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

            transform.RotateAround(new Vector3(0,0,0), new Vector3(0.0f, -1.0f, 0.0f), -60 * move.x);

            dragOrigin = Input.mousePosition;
        }
        
    }
}
