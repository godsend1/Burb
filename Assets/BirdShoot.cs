using UnityEngine;
using UnityEngine.AI;

public class BirdShoot : MonoBehaviour{

    Animator animComponent;
    public GameObject Sphere;
    public GameObject bulletModel;
    public float bulletSpeed;
    public Transform bulletSpawnPoint;
    public float recoilForce = 10f; // How strong the recoil is
    public GameObject bullet;

    private Rigidbody playerRb;

    void Start()
    {
        animComponent = GetComponent<Animator>(); //fetch the animator this script is attached to
        Sphere = GameObject.Find("Sphere1");
        playerRb = GameObject.Find("Player1").GetComponent<Rigidbody>();
    }

    void Update()
    {   
        //Trigger animation when KeyCode.Space is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            Sphere.SetActive(true);
        }
        else 
        {
            Sphere.SetActive(false);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            bullet = Instantiate(bulletModel, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;   
            
        }

        if (Input.GetMouseButton(3))
        {
            bullet = Instantiate(bulletModel, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        if(bullet != null && Input.GetKey(KeyCode.LeftShift))
        {
            Recoil();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            bullet = Instantiate(bulletModel, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
        if(bullet != null && Input.GetKey(KeyCode.LeftShift))
        {
            Recoil();
        }
    }

    void Recoil()
    {
        // Apply recoil to player (opposite of firePoint direction)
        Vector3 recoilDirection = -bulletSpawnPoint.forward; // Opposite direction
        playerRb.AddForce(recoilDirection * recoilForce, ForceMode.Impulse);   
    }
}