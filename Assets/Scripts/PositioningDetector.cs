using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PositioningDetector : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    // Start is called before the first frame update


    private void Start()
    {
        transform.position = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1);
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1);
    }
}

