using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hopScotchSigns : MonoBehaviour
{
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;
    GameObject player;
    GameObject ADSign;
    GameObject WSign;
    GameObject RUNSign;



    // Start is called before the first frame update
    void Start()
    {
        this.text1.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        this.text1.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
        this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
        this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
        player = GameObject.FindGameObjectWithTag("Player");
        ADSign = GameObject.FindGameObjectWithTag("Sign1");
        WSign = GameObject.FindGameObjectWithTag("Sign2");
        RUNSign = GameObject.FindGameObjectWithTag("Sign3");

    }

    // Update is called once per frame
    void Update()
    {

        //6 possible units 3 and 3
        //.1 -> -1. 1.1 possible

        if (player.transform.position.x <= ADSign.transform.position.x + 3.5)
        {
            
            if (player.transform.position.x > ADSign.transform.position.x + .5)
            {
                this.text1.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (Mathf.Abs(player.transform.position.x - (ADSign.transform.position.x + 3.5f)) * .36666666f) - 1);
                this.text1.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, (Mathf.Abs(player.transform.position.x - (ADSign.transform.position.x + 3.5f)) * 0.1f));

            }
            else if (player.transform.position.x <= ADSign.transform.position.x + .5)
            {
                this.text1.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.1f);
                this.text1.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);

            }
        }

        if (player.transform.position.x >= WSign.transform.position.x - 3.5 && player.transform.position.x <= WSign.transform.position.x + 3.5)
        {

            if (player.transform.position.x > WSign.transform.position.x + .5)
            {
                this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (Mathf.Abs(player.transform.position.x - (WSign.transform.position.x + 3.5f)) * .36666666f) - 1);
                this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, (Mathf.Abs(player.transform.position.x - (WSign.transform.position.x + 3.5f)) * 0.1f));

            }
            else if ((player.transform.position.x >= WSign.transform.position.x - .5) && (player.transform.position.x <= WSign.transform.position.x + .5))
            {
                this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.1f);
                this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);

            }
            else if (player.transform.position.x < WSign.transform.position.x - .5)
            {
                this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (Mathf.Abs(player.transform.position.x - (WSign.transform.position.x - 3.5f)) * .36666666f) - 1);
                this.text2.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, (Mathf.Abs(player.transform.position.x - (WSign.transform.position.x - 3.5f)) * 0.1f));

            }
        }

        if (player.transform.position.x >= RUNSign.transform.position.x - 3.5 && player.transform.position.x <= RUNSign.transform.position.x + 3.5)
        {

            if (player.transform.position.x > RUNSign.transform.position.x + .5)
            {
                this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (Mathf.Abs(player.transform.position.x - (RUNSign.transform.position.x + 3.5f)) * .36666666f) - 1);
                this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, (Mathf.Abs(player.transform.position.x - (RUNSign.transform.position.x + 3.5f)) * 0.1f));

            }
            else if ((player.transform.position.x >= RUNSign.transform.position.x - .5) && (player.transform.position.x <= RUNSign.transform.position.x + .5))
            {
                this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0.1f);
                this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.3f);

            }
            else if (player.transform.position.x < RUNSign.transform.position.x - .5)
            {
                this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (Mathf.Abs(player.transform.position.x - (RUNSign.transform.position.x - 3.5f)) * .36666666f) - 1);
                this.text3.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, (Mathf.Abs(player.transform.position.x - (RUNSign.transform.position.x - 3.5f)) * 0.1f));

            }
        }
    }
}
