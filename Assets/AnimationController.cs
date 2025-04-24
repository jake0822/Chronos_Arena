using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animation animation;
     public bool attack, hit, run, idle, death;
    private bool swap;
    
    public void resetAnimations()
    {
        attack = false; hit = false; run = false; idle = false; death = false;
    }
    private void FixedUpdate()
    {
        if (idle)
        {
            animation.Play("Idle_01");
        }
        
        else if (hit)
        {
            animation.Play("Hit");
        }
        else if (attack)
        {
            animation.Play("Attack_01");
            /*if (swap)
                animation.Play("Attack_01");
            else
                animation.Play("Attack_02");
            swap = !swap;*/
        }
        else if (run)
        {
            animation.Play("Run");
        }
        else if (death)
        {
            animation.Play("Die");
        }

    }

    
}
