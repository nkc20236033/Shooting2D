using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetKeyDown(KeyCode.Z)) 
        { 
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
