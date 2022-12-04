using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemControl : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.6f);
    }
}
