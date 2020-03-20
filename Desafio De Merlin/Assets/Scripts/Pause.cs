using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool pausado;
    [SerializeField] GameObject particle;
    public GameObject pauseBox;
    [SerializeField] AudioClip click;

    public void ButtonScalePump(GameObject botao)
    {
        
        iTween.PunchScale(botao.gameObject,iTween.Hash("z",10f,"y",0.5f,"amount",botao.transform.localScale,"time",1f,"ignoretimescale",true));
        particle.transform.position = botao.transform.position;
        particle.transform.rotation = botao.transform.rotation;
        particle.SetActive(true);
        iTween.Stab(botao.gameObject,click,0.5f);
    }
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
