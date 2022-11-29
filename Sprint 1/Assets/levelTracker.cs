using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTracker : MonoBehaviour
{

    private string[] level;
    private int numLevel; // 0=tutorial, 1=level1.5, 2=level2, 3=bosslevel(?)

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        level = new string[] {"TutorialLevel", "Level1.5", "Level2" };
    }

    public string getLevel()
    {
        return level[numLevel];
    }

    public void nextLevel()
    {
        ++numLevel;
    }
}
