using UnityEngine;
using UnityEngine.AI;

public class BirdShoot : MonoBehaviour{

    Animator animComponent;
    public GameObject Sphere;
    public GameObject bulletModel;
    public float bulletSpeed;
    public Transform bulletSpawnPoint;

    void Start()
    {
        animComponent = GetComponent<Animator>(); //fetch the animator this script is attached to
        Sphere = GameObject.Find("Sphere1");
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
            var bullet = Instantiate(bulletModel, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        if (Input.GetMouseButton(3))
        {
            var bullet = Instantiate(bulletModel, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            var bullet = Instantiate(bulletModel, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}