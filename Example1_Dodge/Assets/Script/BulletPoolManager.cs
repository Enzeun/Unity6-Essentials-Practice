using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolManager : MonoBehaviour
{
    private ObjectPool<Bullet> pool;
    [SerializeField]
    private Bullet bull;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        pool = new ObjectPool<Bullet>
            (CreateBullet,
        OnGetBullet,
        OnReleaseBullet,
        OnDestroyBullet);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private Bullet CreateBullet()
    {
        return Instantiate(bull);
    }
    private void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    public Bullet SpawnBullet(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = pool.Get();
        bullet.Init(pool, position, rotation);
        return bullet;
    }
}
