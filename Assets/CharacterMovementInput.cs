using UnityEngine;

public class CharacterMovementInput : MonoBehaviour
{
  //  [SerializeField] MouseInput mouseInput;
    CharacterMovement characterMovement; 

    private void Awake(){
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update(){
  //      characterMovement.SetDestination(mouseInput.mouseInputPosition);
    }
}
