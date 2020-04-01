using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Explode : MonoBehaviour
{
    [SerializeField] float explosionRadius = 3f;
    [SerializeField] float explosionForce = 2000f;
    [SerializeField] float delay = 3f;
    float countdown;

    bool hasExploded;
    [SerializeField] TimeManager freezeFrame;
    Collider[] explosion;
    [SerializeField] List<GameObject> listaDePedras = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    void Explosion()
    {
        explosion = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider objetosAfetados in explosion)
        {
            Rigidbody rb = objetosAfetados.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce,transform.position, explosionRadius,20f,ForceMode.Impulse);
                freezeFrame.FreezeFrame();
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            for (int i = 0; i < listaDePedras.Count; i++)
            {
                listaDePedras[i].GetComponent<Rigidbody>().isKinematic = false;
            }
            Explosion();
            
            hasExploded = true;
        }
        if (hasExploded)
        {
            Time.fixedDeltaTime = .02f;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
