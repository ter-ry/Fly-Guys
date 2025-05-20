using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControllers : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = 10.0f;
    public Rigidbody rb;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI resultText;
    public Button button;
    public GameObject panel;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject starempty;
    public int Star1time = 10;
    public int Star2time = 10;
    public int Star3time = 10;

    private float distToGround;
    private float playTime;
    private bool isGrounded = true;
    private bool canMove = false;
    private FinishLine finishLine;
    private float pushForce;
    private bool isStuned = false;
    private bool wasStuned = false;
    private bool slide = false;
    private Vector3 pushDir;
    [SerializeField] private AudioSource jumpsound;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        button.gameObject.SetActive(false);
        panel.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        starempty.SetActive(false);
        finishLine = Object.FindFirstObjectByType<FinishLine>();
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        canMove = true;

    }

    void FixedUpdate()
    {

        if (CanMove() && finishLine.FinishLineReached() == false)
        {
            playTime += Time.deltaTime;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //moveHorizontal = 1f;
                transform.Rotate(Vector3.up, moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //moveHorizontal = -1f;
                transform.Rotate(Vector3.up, -moveSpeed * Time.deltaTime);
            }

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (IsGrounded() && Input.GetButton("Jump"))
            {
                jumpsound.Play();
                Vector3 velocity = rb.velocity;
                rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }

        if (finishLine.FinishLineReached())
        {
            starempty.SetActive(true);
            int stars = 0;
            if (playTime < Star3time)
            {
                star3.SetActive(true);
            }
            else if (playTime < Star2time)
            {
                star2.SetActive(true);
            }
            else if (playTime < Star1time)
            {
                star1.SetActive(true);
            }

            button.gameObject.SetActive(true);
            panel.SetActive(true);
            resultText.text = "Time: " + playTime.ToString("F2") + "s\n";

        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    public bool CanMove()
    {
        return canMove;
    }

    float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(2 * jumpForce * gravity);
    }

    public void HitPlayer(Vector3 velocityF, float time)
    {
        rb.velocity = velocityF;

        pushForce = velocityF.magnitude;
        pushDir = Vector3.Normalize(velocityF);
    }
}