using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidBody;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping;
    public float jumpForce;
    private bool isGrouded = false;
    public Transform pied_droit;
    public Transform pied_gauche;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
   
    void FixedUpdate()
    {
        isGrouded = Physics2D.OverlapArea(pied_gauche.position, pied_droit.position);
        float horizontalMouvement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 
        if (Input.GetButtonDown("Jump") && isGrouded)
            isJumping = true;
        movePlayer(horizontalMouvement);
        flip(rigidBody.velocity.x);
        animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
        
    }
    void movePlayer(float _horizontalMouvement)
    {
        Vector3 velocit = new Vector2(_horizontalMouvement, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, velocit, ref velocity,.05f);
        if (isJumping == true)
        {
            rigidBody.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }
    void flip(float _velocity)
    {
        if (_velocity > 0.1f)
            spriteRenderer.flipX = false;
        else if (_velocity < -0.1f)
            spriteRenderer.flipX = true;
    }
}
