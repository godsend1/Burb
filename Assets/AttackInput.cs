using UnityEngine;

public class AttackInput : MonoBehaviour
{
    InteractInput interactInput;
    AttackHandler attackHandler;

    // Start is called before the first frame update
    void Start(){
        interactInput = GetComponent<InteractInput>();
        attackHandler = GetComponent<AttackHandler>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            if(interactInput.hoveringOverObject != null){
                attackHandler.Attack(interactInput.hoveringOverObject);
            }

        }
    }
}

