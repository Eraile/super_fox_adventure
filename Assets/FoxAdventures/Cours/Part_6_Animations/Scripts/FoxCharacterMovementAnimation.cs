using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCharacterMovementAnimation : MonoBehaviour
{
    // Character Controller
    private FoxCharacterController __foxCharacterController = null;
    public FoxCharacterController FoxCharacterController
    {
        get
        {
            if (this.__foxCharacterController == null)
                this.__foxCharacterController = this.GetComponent<FoxCharacterController>();
            return this.__foxCharacterController;
        }
    }

    // Rigidbody
    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (this.FoxCharacterController != null)
                return this.FoxCharacterController.Rigidbody2D;
            return null;
        }
    }

    // Animator
    private Animator __animator = null;
    public Animator Animator
    {
        get
        {
            if (this.__animator == null)
                this.__animator = this.GetComponent<Animator>();
            return this.__animator;
        }
    }

    // LateUpdate to update animations
    void LateUpdate()
    {
        if (this.FoxCharacterController != null)
        {
            this.Animator.SetBool("IsGrounded", this.FoxCharacterController.IsGrounded);
            this.Animator.SetBool("IsCrouching", this.FoxCharacterController.crouch);
            this.Animator.SetFloat("Horizontal", Mathf.Abs(this.FoxCharacterController.horizontalInput));
            //this.Animator.SetFloat("Horizontal", Mathf.Abs(this.Rigidbody2D.velocity.x) / this.FoxCharacterController.moveSpeedFactor);
            this.Animator.SetFloat("Vertical", this.Rigidbody2D.velocity.y);
        }
    }
}
