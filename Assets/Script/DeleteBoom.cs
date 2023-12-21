using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBoom : MonoBehaviour
{
    public AudioSource boomSource;

    IEnumerator Start()
    {
        boomSource.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
