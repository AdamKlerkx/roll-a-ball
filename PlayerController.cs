using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public Transform respauwnTrigger;
    public Transform respauwnTrigger1;
    public Transform respauwnTrigger2;
    public Transform checkPoint;
    public Transform respauwnPoint1;
    public Transform respauwnPoint2;
    public Text countText;
    public Text boosterText;
    public Text winText;
    public Camera FirstPersonCam, ThirdPersonCam, CameraTop;
    public KeyCode TKey;
    public bool camSwitch = false;

    private Rigidbody rb;
    private int count;
    private bool jump;
    private bool isGrounded;
    private Transform PlayerTransform;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        // PlayerTransform = PlayerTransform.Find("Player").transform;
        count = 1; 
        // SetCountText ();
        winText.text = "";
        jumpPower = 2.4f;
        speed = 10;
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        jump = Input.GetButton("Jump");
        Jump();

        rb.AddForce (movement * speed);
        if (Input.GetKeyDown(TKey))
            {
                camSwitch = !camSwitch;
                ThirdPersonCam.gameObject.SetActive(camSwitch);
                CameraTop.gameObject.SetActive(!camSwitch);
            }
    }

    void Jump(){

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);

        if(jump && isGrounded){
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other){
        countText.text = "count: " + count.ToString ();
        if (other.gameObject.CompareTag ("pick up")){
            other.gameObject.SetActive (false);
            count = count + 1;
            // SetCountText ();
        }
        if (other.gameObject.CompareTag ("boostJump")){
            jumpPower = 3.4f;
            boosterText.text = "Jump";
        }
        if (other.gameObject.CompareTag ("boostSpeed")){
            speed = 50f;
            boosterText.text = "Speed";
        }
         if (other.gameObject.CompareTag ("clearBoost")){
            speed = 10;
            jumpPower = 2.4f;
            boosterText.text = "booster: ";
        }
        if (other.gameObject.CompareTag ("respauwnTrigger")){
            PlayerTransform.position = checkPoint.position;
        }
        if (other.gameObject.CompareTag ("respauwnTrigger1")){
            PlayerTransform.position = respauwnPoint1.position;
        }
        if (other.gameObject.CompareTag ("Win")){
            if (count >= 26)
            {
                winText.text = "You Win!";
            }
        }
    }
}
