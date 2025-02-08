using UnityEngine;

public class CameraMovement2D : MonoBehaviour
{
    public float speed = 100;
    public Transform obj;
    public Transform player; // Assign player in Inspector
    public Vector3 offset = new Vector3(0, 2, -5); // Default camera offset
    public float resetSpeed = 5f; // How fast the reset happens

    private bool resetting = false; // Track if we're resetting

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press Space to reset
        {
            resetting = true;
        }

        if (resetting)
        {
            // Move camera smoothly back to the player's position + offset
            transform.position = Vector3.Lerp(transform.position, player.position + offset, resetSpeed * Time.deltaTime);

            // Stop resetting when close enough
            if (Vector3.Distance(transform.position, player.position + offset) < 0.1f)
            {
                resetting = false;
            }
        }
    }

    public void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, 0, v);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        obj.transform.position += tempVect;       
        // Get mouse position in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {

            //Target (mouse pos)
            Vector3 lookTarget = hit.point;    

            //look at target slowly    
            Vector3 direction = lookTarget - obj.transform.position;
            direction = new Vector3(direction.x, 0, direction.z);
            Quaternion toRotation = Quaternion.LookRotation(direction, obj.transform.up);
            obj.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
        }
    }
}
