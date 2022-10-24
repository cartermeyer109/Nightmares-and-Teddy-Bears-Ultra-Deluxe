using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShopScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D thingHit)
    {
        if (thingHit.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Hopscotch Shop");
        }
    }
}
