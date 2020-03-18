using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaDano : MonoBehaviour
{
    public int vida = 100;

    public BarraDeVida barraVida;
    DropItem drop;
    // Start is called before the first frame update

    private void Start()
    {
        if (gameObject.tag != "inimigoFraco" && gameObject.tag != "inimigoPedra")
        {
            barraVida = GetComponentInChildren<BarraDeVida>();
            barraVida.SetVidaMaxima(vida);
        }
    }
    public void TomarDanos(int quantidade)
    {
        vida -= quantidade;
        iTween.PunchPosition(gameObject, iTween.Hash("x",0.3f, "z",0.1f));
        //iTween.PunchScale(gameObject, iTween.Hash("y", 0.5f, "amount",Vector3.up));
        if (gameObject.tag != "inimigoFraco" && gameObject.tag != "inimigoPedra")
            barraVida.SetVida(vida);
        if (vida <= 0)
        {
            //drop.gameObject.GetComponent<DropItem>().Dropando();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

    }
}
