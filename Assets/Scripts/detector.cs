using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class detector : MonoBehaviour
{
    [SerializeField] Transform projectilePos;
    public PathCreator pathCreator;
    public static bool boomberangMoving;

    private void Start()
    {
        boomberangMoving = false;
    }
    private void Update()
    {
        transform.position = pathCreator.path.GetPoint(20);
        if (projectilePos.position == pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1))
        {
            boomberangMoving = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "projectile")
        {
            boomberangMoving = true;
        }

    }

}
