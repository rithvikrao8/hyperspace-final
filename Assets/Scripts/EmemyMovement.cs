using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (isFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
            Debug.Log("isFacingRight");
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
            Debug.Log("isFacingleft");
        }
    }

    private void OnTriggerExit2D(Collider2D colltion)
    {
        Debug.Log("enitered");
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
        Debug.Log(transform.localScale + "localScale");
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}