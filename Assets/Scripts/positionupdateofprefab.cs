using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class positionupdateofprefab : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private int pointNo = 0;
    // Start is called before the first frame update

    private void OnEnable()
    {
        transform.position = pathCreator.path.GetPoint(pointNo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pathCreator.path.GetPoint(pointNo);
    }


}

