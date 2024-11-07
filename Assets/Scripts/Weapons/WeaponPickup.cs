using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder; // Weapon prefab yang akan diberikan kepada player
    [SerializeField] GameObject portal; // Berguna untuk asteroit (portal) muncul saat mengambil weapon
    Weapon weapon; // Referensi ke objek weapon yang diambil dari weaponHolder

    void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
            weapon.gameObject.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("WeaponHolder belom di masukin.");
        }

        if (portal != null)
        {
            portal.SetActive(false); // Menyembunyikan portal 
        }
        else
        {
            Debug.LogWarning("Portal belum dipasangkan pada setiap weaponpickup.");
        }
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false); // Menyembunyikan visual weaponnya
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with WeaponPickup!");

            if (weapon != null)
            {
                Weapon currentWeapon = other.GetComponentInChildren<Weapon>();
                if (currentWeapon != null)
                {
                    currentWeapon.gameObject.SetActive(false); // Mengubah senjata lama menjadi senjata yang baru
                }

                // Memberikan weapon baru ke pemain
                Weapon newWeapon = Instantiate(weapon, other.transform.position, Quaternion.identity);
                newWeapon.transform.SetParent(other.transform);
                newWeapon.transform.localPosition = new Vector3(0, 0, 1); // Mengatur posisi pada player
                newWeapon.gameObject.SetActive(true);

                TurnVisual(true, newWeapon); // Mengaktifkan visual weapon yang baru

                if (portal != null)
                {
                    portal.SetActive(true); // Menampilkan portal setelah palyer mengambil weapon
                    Debug.Log("Weapon berhasil dipakai!");
                }
            }
            else
            {
                Debug.LogWarning("Weapon tidak berhasil pada weaponpickup.");
            }
        }
    }

    // Metode ini untuk mengaktifkan atau menonaktifkan visual pada senjata
    void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }

    // Metode dapat untuk mengaktifkan atau menonaktifkan visual senjata tertentu
    void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }
}
