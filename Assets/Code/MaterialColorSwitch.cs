using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorSwitch : MonoBehaviour
{
    private Material myMat;
    private bool isRed;
    // Start is called before the first frame update
    void Start()
    {
        myMat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        isRed = !isRed;
        if(isRed)
        {
            myMat.SetColor("_Color", Color.red);
        }
        else
        {
            myMat.SetColor("_Color", Color.blue);
        }
    }
}
