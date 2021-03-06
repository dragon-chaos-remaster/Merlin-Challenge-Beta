﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveiraMinion : MonoBehaviour
{

    public GameObject projetil;
    public Transform ondeNasco;
    Transform target;

    public float tempoDeEspera = 5;
    public float tempoAtual;
    public float tempo = 1;


    [SerializeField] Pooling pooling;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("player").transform;
        pooling = GameObject.Find("PoolingArrow").GetComponent<Pooling>();
    }

    // Update is called once per frame
    void Update()
    {

        if (BossCaveira.contagemCaveira >= 4 | tempoAtual >= 3)
        {
            Destroy(gameObject);
        }

        OlhandoProPlayer();
        transform.LookAt(target);
        tempoAtual += tempo * Time.deltaTime;
        if (tempoAtual >= tempoDeEspera)
        {
            GameObject aux = pooling.GetPooledObject();
            if(aux != null)
            {
                print("Oi");
                aux.transform.position = ondeNasco.position;
                aux.transform.rotation = ondeNasco.rotation;
            }
            tempo = 1;
            tempoAtual = 0;
        }

    }
    void OlhandoProPlayer()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);
    }

}
