using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    public float speed = 100;
    public Transform obj;
    
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
