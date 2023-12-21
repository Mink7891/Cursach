using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimPervak : MonoBehaviour
{
    public void AnimWalk(Transform point, Animator anim)
    {
        float horizontalDifference = transform.position.x - point.position.x;
        float verticalDifference = transform.position.y - point.position.y;
        if (anim)
        {
            if (Mathf.Abs(horizontalDifference) > Mathf.Abs(verticalDifference))
            {
                if (horizontalDifference > 0)
                {
                    anim.SetTrigger("right");
                }
                else
                {
                    anim.SetTrigger("left");
                }
            }
            else
            {
                anim.SetTrigger(verticalDifference > 0 ? "down" : verticalDifference < 0 ? "up" : "bite");
            }
        }
    }
}
