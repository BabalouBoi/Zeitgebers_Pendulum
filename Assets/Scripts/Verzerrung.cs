using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verzerrung : MonoBehaviour
{
    public Transform head;
    public float distance = 0;
    private float tempDistance = 0;
    private Vector2 prePosXZ;
    private Vector2 posXZ;


    public Transform Target1;
    public Transform Target2;
    public Pendulum Pendulum;

    private Vector3 orgPosTarget1;
    private Vector3 orgPosTarget2;


    [SerializeField, Range(1, 2f)]
    public float scale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        orgPosTarget1 = Target1.position;
        orgPosTarget2 = Target2.position;
    }

    // Update is called once per frame
    void Update()
    {
        scale = 1 + distance * 0.01f;

        Target1.position = orgPosTarget1 * (((scale - 1) / 2) + 1);
        Target2.position = orgPosTarget2 * (((scale - 1) / 2) + 1);
        Pendulum.scale = 1 / scale;


        posXZ = new Vector2(head.position.x, head.position.z);
        tempDistance = Vector2.Distance(prePosXZ, posXZ);


        if (tempDistance > 0.1f)
        {
            distance += tempDistance;
            prePosXZ = posXZ;
        }
    }
}
