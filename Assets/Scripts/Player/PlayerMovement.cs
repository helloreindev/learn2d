using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    // Public properties
    public float moveSpeed;
    public float crouchSpeed;
    public float sprintSpeed;
    public Rigidbody2D player;
    public Animator animator;
    
    private Vector2 moveDirection;

    public void Update()
    {
        ProcessInputs();
    }

    /// <summary>
    /// Handle every of the character movements
    /// </summary>
    public void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
        }

        if (moveX == 1 || moveX == -1 || moveY == 1 || moveY == -1)
        {
            animator.SetFloat("LastHorizontal", moveX);
            animator.SetFloat("LastVertical", moveY);
        }

        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        moveDirection = new Vector2(moveX, moveY);

        if (Input.GetKey(KeyCode.LeftShift))
        {        
            player.velocity = new Vector2(moveDirection.x * sprintSpeed, moveDirection.y * sprintSpeed);
        } else
        {
            player.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            player.velocity = new Vector2(moveDirection.x * crouchSpeed, moveDirection.y * crouchSpeed);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
