using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    Rigidbody fisica;
    RaycastHit hit;
    Vector3 movimento;

    [SerializeField] string pisandoEmQueIlha;



    //ector3 posicaoDoMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        Cursor.visible = false;

    }

    private void Update()
    {
        movimento = new Vector3((Input.GetAxisRaw("Vertical")), 0f, -(Input.GetAxisRaw("Horizontal")));
        movimento = movimento.normalized * speed;
        fisica.velocity = movimento;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            Vector3 playerToMouse = (hit.point - transform.position).normalized;
            playerToMouse.y = 0;
            Quaternion newRot = Quaternion.LookRotation(playerToMouse);
            fisica.MoveRotation(newRot);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == pisandoEmQueIlha)
        {
            for (int i = 0; i < WaveSpawner.Instance.spawnPoints.Length; i++)
            {
                WaveSpawner.Instance.spawnPoints[i].position = transform.forward * 10;
            }
        }
    }
    // Update is called once per frame
    //void FixedUpdate()
    //{

    //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    //    {
    //        Vector3 playerToMouse = hit.point - transform.position;
    //        playerToMouse.y = 0;
    //        Quaternion newRot = Quaternion.LookRotation(playerToMouse);
    //        fisica.MoveRotation(newRot);
    //    }
    //    //Apenas inverti os valores do movimento baseado no Angulo da Camera, se preferir que a camera fique do jeito Original, basta retirar as 2 barrinhas "//" da linha abaixo e apagar a linha invertida

    //    movimento = new Vector3((Input.GetAxisRaw("Horizontal")), 0f, (Input.GetAxisRaw("Vertical")));
    //    movimento = new Vector3((Input.GetAxisRaw("Vertical")), 0f, -(Input.GetAxisRaw("Horizontal")));
    //    movimento = movimento.normalized * speed * Time.fixedDeltaTime;
    //    fisica.MovePosition(transform.position + movimento);

    //}
}
