using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    private RaycastHit hit;

    [SerializeField] private bool isActive = false;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private LayerMask layerGround;

    [SerializeField] private float speed = 2;
    [SerializeField] private float jumpForce = 3;
    [SerializeField] private float m_MaxDistance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckBox(
            collider.bounds.center - Vector3.up * 0.55f,
            new Vector3(
                collider.bounds.extents.x * 0.9f,
                0.05f,
                collider.bounds.extents.z * 0.9f
            ),
            Quaternion.identity,
            layerGround
        );

        if (!isActive)
            return;
        if (Input.GetButtonDown("Jump"))
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
        if (isGrounded)
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void SetActive(bool value)
    {
        isActive = value;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (isGrounded)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, (-transform.up) * hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + (-transform.up) * hit.distance, transform.localScale);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, (-transform.up) * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + (-transform.up) * m_MaxDistance, transform.localScale);
        }
    }
}
