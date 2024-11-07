using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder; 
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
            Debug.LogWarning("WeaponHolder is not assigned.");
        }
    }

    void Start()
    {
       
        if (weapon != null)
        {
            TurnVisual(false); 
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
                   
                    currentWeapon.gameObject.SetActive(false);
                }

                
                Weapon newWeapon = Instantiate(weapon, other.transform.position, Quaternion.identity);

               
                newWeapon.transform.SetParent(other.transform);

                
                newWeapon.transform.localPosition = new Vector3(0, 0, 1); 

                
                newWeapon.gameObject.SetActive(true);

                
            }
            else
            {
                Debug.LogWarning("Weapon is not instantiated in WeaponPickup.");
            }
        }
    }

    
    void TurnVisual(bool on)
    {
        if (weapon != null)
        {
            
            weapon.gameObject.SetActive(on);
        }
    }
}
