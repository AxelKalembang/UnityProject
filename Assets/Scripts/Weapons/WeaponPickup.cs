using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;
    [SerializeField] GameObject portal;
    Weapon weapon;

    void Awake()
    {
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder, transform.position, transform.rotation);
            weapon.gameObject.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("WeaponHolder belum dimasukkan.");
        }

        if (portal != null)
        {
            portal.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Portal belum dipasangkan.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with WeaponPickup!");

            if (weapon != null)
            {
                // Dapatkan weapon yang ada di pemain saat ini dan hentikan penembakan
                Weapon currentWeapon = other.GetComponentInChildren<Weapon>();
                if (currentWeapon != null)
                {
                    currentWeapon.StopShooting(); // Hentikan penembakan senjata lama
                    Destroy(currentWeapon.gameObject); // Hapus senjata lama
                }

                // Memberikan weapon baru ke pemain
                Weapon newWeapon = Instantiate(weapon, other.transform.position, Quaternion.identity);
                newWeapon.transform.SetParent(other.transform);
                newWeapon.transform.localPosition = new Vector3(0, 0, 1);
                newWeapon.gameObject.SetActive(true);

                // Mulai menembak senjata baru
                newWeapon.StartShooting();

                if (portal != null)
                {
                    portal.SetActive(true);
                    Debug.Log("Weapon berhasil dipakai dan mulai menembak!");
                }
            }
            else
            {
                Debug.LogWarning("Weapon tidak berhasil diambil.");
            }
        }
    }
}
