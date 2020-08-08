using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var dx = Input.GetAxis("Horizontal"); 
        var dz = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(dx, 0, dz) * 5, ForceMode.Force);
    }
}
