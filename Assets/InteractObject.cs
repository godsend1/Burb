using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField] string postMessage; 
    public string objectName;

    private void Start(){
        objectName = transform.name;
    }

    public void Interact(){
        Debug.Log(postMessage);
    }
}
