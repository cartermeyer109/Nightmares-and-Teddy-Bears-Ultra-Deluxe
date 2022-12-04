using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionParticle : MonoBehaviour
{
    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnParticleCollision(GameObject other)
    {
            Debug.Log("PARTICLES YIPPE");
    }

    public void OnParticleTrigger()
    {
            Debug.Log("PARTICLES YIPPE");
            Destroy(this.gameObject);
    }

}
