using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private bool isAlive;
    private CapsuleCollider2D myCollider;
   [SerializeField]private int jumpspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) return;
        Run();
        FlipSprite();
        Die();
        Jump();
    }

    void Die()
    {
        //Debug.Log("entered die");

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("deathBarrier")) || myCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))

        {
            Debug.Log("entered die touching layers");
            myAnimator.SetTrigger("isDead");
            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextIndex);
            isAlive = false;
        }
        else
        {
            Debug.Log("did not enter entered die touching layers");
        }

    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between  -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * 5, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        //print(playerVelocity);

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
    private void Jump()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump") && myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpspeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }
}
              