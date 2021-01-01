using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void DifficultyChange(int val)
    {
        botLogic.setDifficulty(val);
    }
}
