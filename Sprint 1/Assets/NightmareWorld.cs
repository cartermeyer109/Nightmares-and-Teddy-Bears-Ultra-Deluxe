using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareWorld : MonoBehaviour
{

    private GameObject evilBackground;
    private GameObject evilBackObj;
    private GameObject evilTiles;
    public bool didGlitch;
    public bool isNightmareScene;
    private int glitchTime;

    private GameObject DreamMusicObject;
    private GameObject NightmareMusicObject;

    private AudioSource DreamMusic;
    private AudioSource NightmareMusic;

    // Start is called before the first frame update
    void Start()
    {
        evilBackground = GameObject.Find("evilBackground");
        evilBackObj = GameObject.Find("EvilBackground");
        evilTiles = GameObject.Find("EvilTiles");
        didGlitch = false;
        
        isNightmareScene = false;
        glitchTime = 75;

        DreamMusicObject = GameObject.Find("DreamMusic");
        NightmareMusicObject = GameObject.Find("NightmareMusic");

        DreamMusic = DreamMusicObject.GetComponent<AudioSource>();
        NightmareMusic = NightmareMusicObject.GetComponent<AudioSource>();
        
        endNightmareMode();
        DreamMusic.Play();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(glitchTimedCounter());
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    setNightmareMode();
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    endNightmareMode();
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Mushroom"))
        //{
        //    //Debug.Log("hit mushroom");
        //    if (!didGlitch)
        //    {
        //        StartCoroutine(glitchTimedCounter());
        //        didGlitch = true;
        //    }
        //}

        if (other.gameObject.CompareTag("NightmareLine"))
        {
            if (!didGlitch)
            {
                StartCoroutine(glitchTimedCounter());
                Destroy(other.gameObject);
                didGlitch = true;

            }
            /*else */if (!isNightmareScene /*&& didGlitch*/)
            {
                //StartCoroutine(nighmareWorldTransition());

            }
            else
            {
                //Debug.Log("Error setting nightmare mode");
            }
        }
    }

    //switches between the nightmare mode and dream world at timed intervals depending on the frames to give a glitch like effect
    //also pauses music during the glitch timer, can be changed to play the music for that mode with each change, but ends up sounding choppy
    public IEnumerator glitchTimedCounter()
    {
        DreamMusic.Pause();
        yield return null;
        setNightmareMode();
        for (int i = 0; i < glitchTime; ++i) { yield return null; }
        endNightmareMode();
        for (int i = 0; i < glitchTime; ++i) { yield return null; }
        setNightmareMode();
        yield return new WaitForSeconds(1);
        endNightmareMode();
        for (int i = 0; i < glitchTime; ++i) { yield return null; }
        setNightmareMode();
        //for (int i = 0; i < glitchTime; ++i) { yield return null; }
        //endNightmareMode();
        //DreamMusic.Play();
        //StartCoroutine(nighmareWorldTransition());
        NightmareMusic.Play();
    }

    //switches a little back and forth and ending in the nightmare mode
    public IEnumerator nighmareWorldTransition()
    {
        DreamMusic.Stop();
        setNightmareMode();
        for (int i = 0; i < (glitchTime * 2); ++i) { yield return null; }
        endNightmareMode();
        for (int i = 0; i < (glitchTime * 2); ++i) { yield return null; }
        setNightmareMode();
        NightmareMusic.Play();
    }

    void setNightmareMode()
    {
        evilBackground.SetActive(true);
        evilBackObj.SetActive(true);
        evilTiles.SetActive(true);
        isNightmareScene = true;

        //DreamMusic.Pause();
    }

    void endNightmareMode()
    {
        evilBackground.SetActive(false);
        evilBackObj.SetActive(false);
        evilTiles.SetActive(false);
        isNightmareScene = false;
        
        //DreamMusic.Play();
    }

}

