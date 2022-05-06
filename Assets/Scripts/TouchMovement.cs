using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchMovement : MonoBehaviour
{
    public static bool throwing = false;

    float prevScale = 0;

    private Camera cam;

    Vector3 offset;

    Touch touch;
    private Vector3 dragStartPos;
    Vector3 draggingPos;


    Vector3 rotationDirection;
    float scale;
    [SerializeField] float speedModifier = 1f;
    [SerializeField] float rotationSpeed = 1f;



    Vector3 originalSizeOfTheLoop;


    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        originalSizeOfTheLoop = transform.localScale;
    }
    // Update is called once per frame
    void Update()
    {

        float clampz = Mathf.Clamp(transform.localScale.z, 1, 23);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, clampz);

        if (detector.boomberangMoving)
        {
            StartCoroutine(ResetLoop());
        }

        if (Input.touchCount > 0 && projectilemovement.copyOfspeed == 0)
        {

            touch = Input.GetTouch(0);

            offset = new Vector3(touch.position.x, 0, touch.position.y);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                DragMoving();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                throwing = true;
                StartCoroutine(ThrowingAnimation());
            }


        }




    }

    IEnumerator ResetLoop()
    {
        yield return new WaitForSeconds(1.5f);
        transform.localScale = originalSizeOfTheLoop;
    }

    void DragStart()
    {
        dragStartPos = cam.ScreenToWorldPoint(offset);
        dragStartPos.y = 0;
    }
    void DragMoving()
    {
        //rotation and dragging

        draggingPos = cam.ScreenToWorldPoint(offset);
        draggingPos.y = 0;

        scale = Vector3.Distance(draggingPos, dragStartPos);

        if (prevScale < scale)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + (scale * speedModifier));
            prevScale = scale;
        }
        else if (prevScale > scale)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - (scale * speedModifier));
            prevScale = scale;
        }

        rotationDirection = draggingPos - dragStartPos;
        rotationDirection = rotationDirection.normalized;
        transform.forward = new Vector3(rotationDirection.x, 0, rotationDirection.z) * -1 * rotationSpeed;

    }


    IEnumerator ThrowingAnimation()
    {
        yield return new WaitForSeconds(3f);
        throwing = false;
    }
}
