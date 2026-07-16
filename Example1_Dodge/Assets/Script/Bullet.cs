using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

        Destroy(rb, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponent<PlayerController>();

            if (controller != null)
            {
                controller.Die();
            }

        }
    }
}