using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPageScript : MonoBehaviour
{

    Animator playerAnimator;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && GameObject.Find("Canvas").transform.GetChild(3).gameObject.activeSelf) 
        {
            SceneManager.LoadScene("Credits");
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAnimator.SetBool("cutsceneIdle", true);
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
