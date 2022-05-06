using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;

public class projectilemovement : MonoBehaviour
{

    [SerializeField] Animator animator;

    Vector3 currentPosition;

    GameObject[] gameObjectArray;

    public static Vector3 positionOFPoints;



    bool moving;

    public PathCreator pathCreator;
    public float speed = 0;
    float distanceTraveled;
    public EndOfPathInstruction end;


    public static float copyOfspeed;


    private void Start()
    {

        gameObjectArray = GameObject.FindGameObjectsWithTag("pathpoints");
        moving = false;
        copyOfspeed = speed;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, currentPosition.x, currentPosition.x), Mathf.Clamp(transform.position.y, currentPosition.y, currentPosition.y), Mathf.Clamp(transform.position.z, currentPosition.z, currentPosition.z));
        transform.rotation = Quaternion.identity;


        if (pathCreator != null)
        {


            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(ReEnable());
            }

            if (Input.GetMouseButtonUp(0))
            {

                moving = true;
                copyOfspeed = speed;

                end = EndOfPathInstruction.Loop;

                foreach (GameObject go in gameObjectArray)
                {
                    go.SetActive(false);
                }
            }

            if (moving)
            {
                distanceTraveled += copyOfspeed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled, end);

            }
            animator.SetFloat("speed", copyOfspeed);

        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "detector")
        {
            end = EndOfPathInstruction.Stop;
            StartCoroutine(ReduceSpeed());
            
        }
        
    }

    IEnumerator ReduceSpeed()
    {
        yield return new WaitForSeconds(0.2f);
        copyOfspeed = 0;
        moving = false;
    }

    IEnumerator ReEnable()
    {
        yield return new WaitForSeconds(.3f);
        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(true);
        }
    }

}
