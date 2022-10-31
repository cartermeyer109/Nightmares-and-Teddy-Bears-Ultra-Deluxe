using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class testscript : MonoBehaviour
{
    public TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        this.tmp.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
