using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripScript : MonoBehaviour
{

    public GameObject drop;
    public Transform dropPos;

    public void SpawnDrop()
    {
        Instantiate(drop, dropPos.position, Quaternion.identity);
    }
}
