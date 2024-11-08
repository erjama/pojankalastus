using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPart : MonoBehaviour
{

    [SerializeField] float moveSpeed = 0.1f;
    Rigidbody rb;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = transform.forward;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    //todo despawn bodypart when it goes past the island
}
