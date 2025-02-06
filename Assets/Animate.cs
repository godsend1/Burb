using UnityEngine;
using UnityEngine.AI;

public class Animate : MonoBehaviour
{
    Animator animator;

    private void Awake(){
        animator = GetComponentInChildren<Animator>();
    }

    private void Update(){
   //     Vector3 worldVelocity = (transform.position - previousPosition) / Time.deltaTime;
     //   previousPosition = transform.position;
     //   animator.SetFloat("Motion", worldVelocity);
    }
}
