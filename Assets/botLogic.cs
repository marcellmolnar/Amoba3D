using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botLogic : MonoBehaviour
{
    public static botLogic instance;
    
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void setDifficulty(int diff)
    {
        Debug.Log("Difficulty is now: " + diff);
    }

    private IEnumerator MyWait()
    {
        float waitSec = Random.Range(1.0f, 3.0f);
        //Debug.Log("Waiting: " + waitSec + " s");
        yield return new WaitForSecondsRealtime(waitSec);
        int indexToPut;
        do
        {
            indexToPut = (int)(Random.Range(-0.5f, 15.5f));
        } while (!positionHandler.createNewBall(indexToPut));
    }

    public static void step()
    {
        if (GameLogic.isBotsTurn())
        {
            instance.StartCoroutine(instance.MyWait());
        }
    }

}
