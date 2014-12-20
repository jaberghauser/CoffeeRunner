using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float movementSpeed;
    public float jumpSpeed;
    public float gravity;

    private Vector3 moveDirection = Vector3.zero;
    private bool grounded = false;

	// Update is called once per frame
	void Update () {
        
        Movement();

	}
    void Movement()
    {
        //autonomous motion
        Vector3 forward = transform.TransformDirection(Vector3.forward);


        //controls
        CharacterController cc = GetComponent<CharacterController>();
        cc.SimpleMove(forward * movementSpeed);

        //jump
        if (grounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        //gravity
        moveDirection.y -= gravity * Time.deltaTime;

        CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
        CollisionFlags flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = (flags & CollisionFlags.CollidedBelow) != 0;
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    grounded = true;
    //}
}
