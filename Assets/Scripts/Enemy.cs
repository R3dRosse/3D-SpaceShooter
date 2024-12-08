using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform myTransform;
    public float minSpeed = 5.0f;
    public float maxSpeed = 20.0f;
    int x, y, z;
    public float currentSpeed; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        y = 14;
        z = 0;
        x = Random.Range(-14, 14);
        myTransform = transform;
        myTransform.position = new Vector3(x, y, 0);
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(-14, 14);
        myTransform.Translate(-Vector3.up * currentSpeed * Time.deltaTime);
        if(myTransform.position.y < -10)
        {
            myTransform.position = new Vector3(x, y, 0);
            currentSpeed = Random.Range(minSpeed, maxSpeed);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("ProjectileFab"))
        {
            Destroy(this.gameObject);
        }
        if (collider.gameObject.CompareTag("Player")) ;
        {
            Destroy(this.gameObject);
        }
    }
}
