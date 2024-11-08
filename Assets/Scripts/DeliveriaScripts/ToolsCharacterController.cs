using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{

    CharacterController2D character;
    Rigidbody2D rigidbody2D;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rigidbody2D.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
