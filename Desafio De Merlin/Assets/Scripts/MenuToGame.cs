using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{

    
    // Start is called before the first frame update
    public void Tran_SITION(int index)
    {
        StartCoroutine(Transicao(index));
    }

    IEnumerator Transicao(int buildNumber)
    {
        
        SceneManager.LoadScene(buildNumber);
        yield return null;
    }
}
