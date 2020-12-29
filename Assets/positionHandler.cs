using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionHandler : MonoBehaviour
{

    private static Vector3[] positions;

    public GameObject balls;
    private static int numberOfBalls;

    // Start is called before the first frame update
    void Start()
    {
        numberOfBalls = 0;
        positions = new Vector3[16];
        for(int i = 0; i < 16; i++)
        {
            int index = i + 1;
            GameObject cylinderrr = GameObject.Find("/Cylinders/Cylinder_" + index);
            positions[i] = cylinderrr.transform.position;
            positions[i].y = 4.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createNewBall(Vector3 pos)
    {
        Instantiate(balls, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(-90, 0, 0));
        numberOfBalls++;
    }

    public static Vector3 getBestHint(Vector3 pointer)
    {
        int bestIndex = 0;
        for (int i = 0; i < 16; i++)
        {
            if (getDist(pointer, positions[i]) < getDist(pointer, positions[bestIndex]))
            {
                bestIndex = i;
            }
        }
        return positions[bestIndex];
    }

    private static float getDist(Vector3 v1, Vector3 v2)
    {
        return (v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y) + (v1.z - v2.z) * (v1.z - v2.z);
    }
}
