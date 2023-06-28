using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoer : MonoBehaviour
{
    public Text tokuten;
    // Start is called before the first frame update
    void Start()
    {
        tokuten.text = "‹L˜^‚Í" + gamedirec.kyori.ToString("D6") + "Pt‚Å‚·";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
