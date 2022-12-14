using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
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
        if (gameObject.transform.GetChild(0).gameObject != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerAnimator.SetBool("cutsceneIdle", true);
                GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
                Object.Destroy(gameObject.transform.GetChild(0).gameObject);
            }
        }
    }
}
