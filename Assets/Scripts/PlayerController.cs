using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed;
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winTextObject;
    public int winNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

        }
    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= winNum)
        {
            winTextObject.enabled = true;
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision w/ " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose";
            winTextObject.enabled = true;
            gameObject.SetActive(false); 

        }
    }

}
