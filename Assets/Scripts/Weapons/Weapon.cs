using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Bullets")]
    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private readonly int initialPoolSize = 30;

    void Awake()
    {
        // Inisialisasi Object Pool untuk peluru
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, false, initialPoolSize);
    }

    public void StartShooting()
    {
        // Mulai proses menembak dengan memanggil Shoot() setiap frame tanpa delay
        if (!IsInvoking("Shoot"))
        {
            InvokeRepeating("Shoot", 0f, 0.05f); // 0.05f interval untuk efek terus-menerus tanpa delay
        }
    }

    public void StopShooting()
    {
        // Menghentikan proses menembak
        CancelInvoke("Shoot");
    }

    private Bullet CreateBullet()
    {
        if (bulletPrefab != null)
        {
            Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            newBullet.SetPool(objectPool);
            return newBullet;
        }
        return null;
    }

    private void OnGetBullet(Bullet bullet)
    {
        if (bullet != null) // Periksa apakah bullet masih ada
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = bulletSpawnPoint.rotation;
            bullet.Fire();
        }
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        if (bullet != null) // Periksa apakah bullet masih ada
        {
            bullet.gameObject.SetActive(false);
        }
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        if (bullet != null) // Periksa apakah bullet masih ada
        {
            
        }
    }

    public void Shoot()
    {
        if (objectPool != null)
        {
            Bullet pooledBullet = objectPool.Get();
            
        }
    }
}
