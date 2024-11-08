using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2.0f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    bool moving;

    //IPAD / Order Log
    public Image OrderLogImage;
    private RectTransform orderLogRect;
    [SerializeField] float orderLogMoveSpeedAmount = 200.0f;
    private Vector2 _IPadEndPosition = new Vector2(300, 1);
    private bool _IPadMoving = false;
    private bool _IPaidGoingDown = false;
    private Vector2 _IPadOriginalPosition;
    [SerializeField] AudioClip onOpenAudio;
    [SerializeField] AudioClip onCloseAudio;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        orderLogRect = OrderLogImage.GetComponent<RectTransform>();
        _IPadOriginalPosition = orderLogRect.anchoredPosition;
    }

    void Update()
    {
        if (PauseMenu.IsPaused)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L pressed");
            _IPadMoving = true;
            _IPaidGoingDown = !_IPaidGoingDown;

            if (_IPaidGoingDown)
            {
                AudioManager.instance.Play(onOpenAudio);
            }
            else
            {
                AudioManager.instance.Play(onCloseAudio);
            }
        }

        if (_IPadMoving)
        {
            if (_IPaidGoingDown)
            {
                ShowIPad();
            }
            else
            {
                CloseIPad();
            }
        }


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(
            horizontal,
            vertical
        );
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        if (moving)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    private void ShowIPad()
    {
        //Debug.Log("Opening IPad");

        var speed = orderLogMoveSpeedAmount * Time.deltaTime;
        orderLogRect.anchoredPosition = Vector3.MoveTowards(orderLogRect.anchoredPosition, _IPadEndPosition, speed);

        if (orderLogRect.anchoredPosition == _IPadEndPosition)
        {
            //Debug.Log("Opened");
            _IPadMoving = false;
        }
    }

    private void CloseIPad()
    {
        //Debug.Log("Closing IPad");

        var speed = orderLogMoveSpeedAmount * Time.deltaTime;
        orderLogRect.anchoredPosition = Vector3.MoveTowards(orderLogRect.anchoredPosition, _IPadOriginalPosition, speed);

        if (orderLogRect.anchoredPosition == _IPadOriginalPosition)
        {
            //Debug.Log("Closed");
            _IPadMoving = false;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.velocity = motionVector * speed;
    }
}
