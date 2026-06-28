using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float x_axis;
    private bool isActive = false;
    [SerializeField] private float speed = 2;
    [SerializeField] private float jumpForce = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isActive)
            Jump();
    }

    private void FixedUpdate()
    {
        if (!isActive)
            return;
        Vector3 input = new Vector3 (Input.GetAxis("Horizontal"), 0, 0);
        rb.MovePosition(transform.position + input * speed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void SetActive(bool value)
    {
        isActive = value;
    }
}
