using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTracker : MonoBehaviour
{

    private string[] level;
    public int numLevel; // 0=tutorial, 1=level1.5, 2=level2, 3=bosslevel(?)
    private const int MAX_LEVEL = 4;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        level = new string[] {"TutorialLevel", "Level1.5", "Level2", "Level 3", "BossLevel" };
    }

    public string getLevel()
    {
        return level[numLevel];
    }

    public int getLevelNum()
    {
        return numLevel;
    }

    public void nextLevel()
    {

        if ((numLevel+1) < MAX_LEVEL)
        {
            ++numLevel;
        }
        else
        {
            numLevel = 0;
        }
    }

    public void progressLevel()
    {
        nextLevel();
        SceneManager.LoadScene("Hopscotch Shop");
    }

    public void reloadShop(){ SceneManager.LoadScene("Hopscotch Shop"); }

    public void setLevel(int i){ numLevel = i; }
}
