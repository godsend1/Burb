using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOff : StateMachineBehaviour
{    
    GameObject sphere;
    public void OnStateUpdate()
    {
       sphere = GameObject.Find("Sphere");
       sphere.SetActive(false);
    }
}