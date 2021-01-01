using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class positionHandler : MonoBehaviour
{
    enum State
    {
        PLAYER,
        EMPTY,
        COMPUTER
    }
    private static float maxX, minX, maxY, minY;
    private static Vector3[] positions;
    private static int[] numberOfBalls;
    private static State[,,] balls;

    public GameObject newBallDarkInstance;
    public GameObject newBallLightInstance;
    public static GameObject newBallDark;
    public static GameObject newBallLight;

    // Start is called before the first frame update
    void Start()
    {
        newBallDark = newBallDarkInstance;
        newBallLight = newBallLightInstance;
        Debug.Log("ok");
        positions = new Vector3[16];
        numberOfBalls = new int[16];
        maxX = 0.0f; minX = 0.0f; maxY = 0.0f; minY = 0.0f;
        for (int i = 0; i < 16; i++)
        {
            int index = i + 1;
            GameObject cylinderrr = GameObject.Find("/Cylinders/Cylinder_" + index);
            positions[i] = cylinderrr.transform.position;
            positions[i].y = 4.0f;
            if (maxX < positions[i].x)
            {
                maxX = positions[i].x;
            }
            if (minX > positions[i].x)
            {
                minX = positions[i].x;
            }
            if (maxY < positions[i].z)
            {
                maxY = positions[i].z;
            }
            if (minY > positions[i].z)
            {
                minY = positions[i].z;
            }
            numberOfBalls[i] = 0;
        }

        balls = new State[4,4,4];
        for (int row = 0; row < 4; ++row)
        {
            for (int col = 0; col < 4; ++col)
            {
                for (int height = 0; height < 4; ++height)
                {
                    balls[row, col, height] = State.EMPTY;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private static void checkState()
    {
        for (int alongCoord = 0; alongCoord < 3; ++alongCoord)
        {
            checkStateAlong(alongCoord);
        }
    }

    private static void checkStateAlong(int runningCoord)
    {
        // Checking along z coordinate
        for (int coord1 = 0; coord1 < 4; ++coord1)
        {
            for (int coord2 = 0; coord2 < 4; ++coord2)
            {
                bool areSame = true;
                State compareValue = State.EMPTY;
                for (int coord3 = 0; coord3 < 4; ++coord3)
                {
                    int row = coord1;
                    int col = coord2;
                    int height = coord3;
                    compareValue = balls[row, col, 0];
                    if (runningCoord == 0)
                    {
                        row = coord3;
                        col = coord1;
                        height = coord2;
                        compareValue = balls[0, col, height];
                    }
                    if (runningCoord == 1)
                    {
                        row = coord1;
                        col = coord3;
                        height = coord2;
                        compareValue = balls[row, 0, height];
                    }
                    if (compareValue != balls[row, col, height])
                    {
                        areSame = false;
                        break;
                    }
                }
                if (areSame && compareValue != State.EMPTY)
                {
                    if (compareValue == State.PLAYER)
                    {
                        GameLogic.playerWon();
                    }
                    else
                    {
                        GameLogic.computerWon();
                    }
                }
            }
        }
    }

    public static bool createNewBall(Vector3 pos)
    {
        if (numberOfBalls[getBestIndex(pos)] >= 4)
        {
            return false;
        }
        Vector2 ballPos = indexToCoord(getBestIndex(pos));
        int ballX = (int)(ballPos.x);
        int ballY = (int)(ballPos.y);
        if (GameLogic.isPlayersTurn())
        {
            Instantiate(newBallDark, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(-90, 0, 0));
            balls[ballX, ballY, numberOfBalls[getBestIndex(pos)]] = State.PLAYER;
        }
        else
        {
            Instantiate(newBallLight, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(-90, 0, 0));
            balls[ballX, ballY, numberOfBalls[getBestIndex(pos)]] = State.COMPUTER;
        }
        
        numberOfBalls[getBestIndex(pos)]++;

        checkState();

        GameLogic.changePlayer();
        return true;
    }

    public static bool createNewBall(int index)
    {
        return createNewBall(positions[index]);
    }

    private static int getBestIndex(Vector3 pointer)
    {
        int bestIndex = 0;
        for (int i = 0; i < 16; i++)
        {
            if (getDist(pointer, positions[i]) < getDist(pointer, positions[bestIndex]))
            {
                bestIndex = i;
            }
        }
        return bestIndex;
    }

    public static Vector3 getBestHint(Vector3 pointer)
    {
        return positions[getBestIndex(pointer)];
    }

    private static float getDist(Vector3 v1, Vector3 v2)
    {
        return (v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y) + (v1.z - v2.z) * (v1.z - v2.z);
    }

    private static Vector2 indexToCoord(int index)
    {
        float x_coord_f = 3.0f * (positions[index].x - minX) / (maxX - minX);
        float y_coord_f = 3.0f * (positions[index].z - minY) / (maxY - minY);
        int x_coord = (int)(Math.Round(x_coord_f));
        int y_coord = (int)(Math.Round(y_coord_f));
        return new Vector2(x_coord, y_coord);
    }
}
