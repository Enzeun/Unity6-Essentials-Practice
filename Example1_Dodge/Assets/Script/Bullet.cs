using UnityEngine;
using UnityEngine.Pool;


public class Bullet : MonoBehaviour
{
    public float speed = 8f;

    ObjectPool<Bullet> myPool;

    private float time;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        rb.linearVelocity = transform.forward * speed;

        if (time >= 3)
        {
            myPool.Release(this);
        }
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

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        //myPool.Release(this);
    }

    public void Init(ObjectPool<Bullet> pool, Vector3 position, Quaternion rotation)
    {
        myPool = pool;
        transform.position = position;
        transform.rotation = rotation;
        time = 0f;
    }
}