using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 3f;
    private Transform myTransform;
    public static int playerLives = 3;
    public static int score = 0;
    float timer = 0f;

    public GameObject ProjectileFab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = transform;
        myTransform.position = new Vector3(0, -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento en 4 direcciones
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
        {
            transform.position += Vector3.right * velocidad * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w"))
        {
            transform.position += Vector3.up * velocidad * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            transform.position += Vector3.down * velocidad * Time.deltaTime;
        }

        // Corrige la posici�n si excede el l�mite
        if (myTransform.position.x >= 11)
        {
            myTransform.position = new Vector3(-11, myTransform.position.y, myTransform.position.z);
        }
        else if (myTransform.position.x <= -11)
        {
            myTransform.position = new Vector3(11, myTransform.position.y, myTransform.position.z);
        }
        else if (myTransform.position.y <= -6)
        {
            myTransform.position = new Vector3(myTransform.position.x, 8, myTransform.position.z);
        }
        else if (myTransform.position.y >= 8)
        {
            myTransform.position = new Vector3(myTransform.position.x, -6, myTransform.position.z);
        }

        // Disparo al presionar espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = new Vector3(myTransform.position.x, myTransform.position.y +1, myTransform.position.z);
            Instantiate(ProjectileFab, position, Quaternion.identity);
        }

        if (Time.time - timer > 1)
        {
            GetComponent<Renderer>().enabled = true;
        }

        print("Lives: " + playerLives + " Score: " + score + "        Current Time: " + Time.time + " Timer to respond: " + timer);


    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            playerLives--;
            GetComponent<Renderer>().enabled = false;
            timer = Time.time;

            if (playerLives < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
