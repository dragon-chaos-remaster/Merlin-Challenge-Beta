using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{

    [SerializeField] GameObject thisGuy;
    [SerializeField] ParticleSystem manyParticles;
    // Start is called before the first frame update
    public void Tran_SITION(int index)
    {
        iTween.PunchScale(thisGuy, iTween.Hash("z", 10f, "amount", thisGuy.transform.localScale));
        StartCoroutine(Transicao(index));
    }

    IEnumerator Transicao(int buildNumber)
    {
        float many = manyParticles.emission.rateOverTime.constant;
        many *= 10;
        print("Ema");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(buildNumber);
        
    }
}
