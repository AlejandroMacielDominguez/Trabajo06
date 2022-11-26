using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class playerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;

    public float speed;
    public Text countText;
	public Text WinText;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
		SetCountText();
        WinText.text = "";
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
		}
    }

    void SetCountText()
    {
		countText.text = "Count: " + count.ToString();
        if (count > 10)
        {
            WinText.text = "You Win!!!";
        }
	}
}
