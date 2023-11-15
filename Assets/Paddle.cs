using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPaddleController : XRGrabInteractable
{
    private int paddleHitForce = 10;
    public float minXPosition = -2f;
    public float maxXPosition = 2f;
    private Rigidbody rb;

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        rb.isKinematic = false; // Enable physics when grabbed
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        rb.isKinematic = true; // Disable physics when released
    }

    private void Update()
    {
        // You can add custom logic for updating the paddle, if needed
        // For example, you might want to limit the paddle's movement within a certain range
        // You can use transform.position or Rigidbody.MovePosition for movement

        // Example: Limiting paddle movement along the X-axis
        float newXPosition = Mathf.Clamp(transform.position.x, minXPosition, maxXPosition);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }

    // You can add collision handling if needed
    private void OnCollisionEnter(Collision collision)
    {
        // Example: Bounce off the puck
        if (collision.gameObject.CompareTag("Puck"))
        {
            // Add force to the puck based on the paddle's velocity
            Rigidbody puckRB = collision.gameObject.GetComponent<Rigidbody>();
            if (puckRB != null)
            {
                puckRB.AddForce(rb.velocity * paddleHitForce, ForceMode.Impulse);
            }
        }

        // Add more collision handling as needed
    }
}