using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHintBall : MonoBehaviour
{
    public GameObject spwneee;
    public static bool isHintCreated;
    private bool ctrlPressed;

    void Start()
    {
        isHintCreated = false;
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
        if (Input.GetMouseButtonDown(0) && !ctrlPressed && GameLogic.isPlayersTurn())
        {
            if (isHintCreated == false)
            {
                Vector3 clickPos = -Vector3.one;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    clickPos = hit.collider.gameObject.transform.position;
                }
                isHintCreated = true;
                clickPos.y = 4.0f;
                Instantiate(spwneee, clickPos, Quaternion.Euler(-90, 0, 0));
            }
        }
        
    }


}
