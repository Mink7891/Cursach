using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource walkSource;
    private bool isWalking = false;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal" , movement.x);
        animator.SetFloat("verical" , movement.y);
        animator.SetFloat("speed" , movement.sqrMagnitude);

        isWalking = movement.magnitude > 0.01f;

        if (!isWalking && walkSource.isPlaying)
        {
            walkSource.Stop();
        }
    }


    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (isWalking && !walkSource.isPlaying)
        {
            StartCoroutine(PlayFootstepSound());
        }
    }

    IEnumerator PlayFootstepSound()
    {
        walkSource.Play();
        yield return new WaitForSeconds(walkSource.clip.length);
        isWalking = false;
    }
}
