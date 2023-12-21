using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : MonoBehaviour
{
    public static bool temp = true;
    public void AnimWalk(Transform point, Animator anim)
    {
        float horizontalDifference = transform.position.x - point.position.x;
        float verticalDifference = transform.position.y - point.position.y;
        if (anim && temp)
        {
            if (Mathf.Abs(horizontalDifference) > Mathf.Abs(verticalDifference))
            {
                if (horizontalDifference > 0)
                {
                    anim.SetTrigger("left");
                }
                else
                {
                    anim.SetTrigger("right");
                }
            }
            else
            {
                anim.SetTrigger(verticalDifference > 0 ? "down" : verticalDifference < 0 ? "up" : "idle");
            }
        }
    }
}
