using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    public bool pausado;

    public GameObject pauseBox;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (!pausado))
        {
            print(pausado);
            pausado = true;
            pauseBox.SetActive(true);
            Time.timeScale = 0;
           
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && (pausado))
        {
            print(pausado);
            pausado = false;
            pauseBox.SetActive(false);
            Time.timeScale = 1;
            
        }
    }
}
