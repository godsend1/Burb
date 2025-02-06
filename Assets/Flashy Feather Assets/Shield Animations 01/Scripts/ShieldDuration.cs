using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ff_shield_animations_01{
public class ShieldDuration : MonoBehaviour
{
    public float shield_duration = 3f;
    public bool DESTROY_ON_END = false;



    void Awake(){
        if( shield_duration < 0 ){
            print("duration can't be less than zero!");
            return;
        }
        ParticleSystem[] ps_all = gameObject.GetComponentsInChildren<ParticleSystem>();
        if( ps_all.Length >= 1 ){
            foreach (ParticleSystem ps in ps_all){
                ps.Stop();
                var main = ps.main;
                main.duration = shield_duration;
                main.startLifetime = shield_duration;
                ps.Play();
            }
        }else{
            print("No ParticleSystem Found!");
            return;
        }
        if( DESTROY_ON_END )
            Destroy( gameObject, shield_duration + 0.1f );       
    }


    
}
}

