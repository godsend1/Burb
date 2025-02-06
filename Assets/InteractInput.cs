using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    [HideInInspector] public InteractObject hoveringOverObject;
    
    void Update()
    {
        CheckInteractObject();
        if(Input.GetMouseButtonDown(0)){
            if(hoveringOverObject != null){
                hoveringOverObject.Interact();
            }
        }
    }

    private void CheckInteractObject(){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                InteractObject interactableObject = hit.transform.GetComponent<InteractObject>();
                if(interactableObject != null){
                    hoveringOverObject = interactableObject;
                    textOnScreen.text = hoveringOverObject.objectName;
                }
                else{
                    hoveringOverObject = null;
                }
            }
    }
}
