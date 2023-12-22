using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTrigger : MonoBehaviour
{
   
    public PlayableDirector timeline;
    private bool animationPlayed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !animationPlayed)
        {
            timeline.enabled = true;
            timeline.Play();

           

            animationPlayed = true;
        }
    }

  
    private void Update()
    {
        if (animationPlayed && timeline.state != PlayState.Playing)
        {
            timeline.enabled = true;
            animationPlayed = false;
        }
    }
}
