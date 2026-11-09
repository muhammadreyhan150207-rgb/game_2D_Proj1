using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfig config;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private IMoveInput input;
    private Vector2 velocity;

    // Properti Facing agar bisa dibaca oleh PlayerInteractor
    public Vector2 Facing { get; private set; } = Vector2.down;

    public void Construct(IMoveInput moveInput)
    {
        input = moveInput;
    }

    void Update()
    {
        if (input == null) return;

        float speed = input.IsRunning ? config.RunSpeed : config.WalkSpeed;
        velocity = input.Move * speed;

        // Cek apakah player sedang menekan tombol arah
        if (input.Move.sqrMagnitude > 0)
        {
            // Update arah Facing cardinal (atas, bawah, kiri, kanan)
            Facing = ToCardinal(input.Move);

            // Masukkan nilai arah ke animator
            animator.SetFloat("MoveX", Facing.x);
            animator.SetFloat("MoveY", Facing.y);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            // Tombol dilepas: set IsMoving ke false, tapi Facing dipertahankan
            animator.SetBool("IsMoving", false);
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", 0f);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = velocity;
    }

    // Fungsi pembantu untuk membulatkan arah vektor ke 4 arah mata angin (Cardinal)
    private static Vector2 ToCardinal(Vector2 v)
    {
        return Mathf.Abs(v.x) > Mathf.Abs(v.y)
            ? new Vector2(Mathf.Sign(v.x), 0f)
            : new Vector2(0f, Mathf.Sign(v.y));
    }
}