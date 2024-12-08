using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform myTransform;
    public int projectileSpeed = 7;
    GameObject Enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);

        if (myTransform.position.y > 8)
        {
            Object.Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Player.score += 50;
            Destroy(this.gameObject);
        }
    }
}
