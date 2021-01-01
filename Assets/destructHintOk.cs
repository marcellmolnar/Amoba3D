using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructHintOk : MonoBehaviour
{
    void Update()
    {
        Vector3 clickPos = -Vector3.one;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            clickPos = hit.collider.gameObject.transform.position;
        }
        clickPos.y = 4.0f;
        if (Input.GetMouseButtonUp(0))
        {
            showHintBall.isHintCreated = false;
            //positionHandler positionHandlerObj = GameObject.Find("SpawnPoint").GetComponent("positionHandler") as positionHandler;
            Vector3 newPos = positionHandler.getBestHint(new Vector3(clickPos.x, clickPos.y, clickPos.z));
            positionHandler.createNewBall(newPos);
            Destroy(this.gameObject);
        }

        Vector3 hintPos = positionHandler.getBestHint(new Vector3(clickPos.x, clickPos.y, clickPos.z));
        transform.position = new Vector3(hintPos.x, hintPos.y, hintPos.z);
    }
}
