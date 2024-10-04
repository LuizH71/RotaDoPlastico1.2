using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public int Length;
    private LineRenderer lineRend;
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;

    public float Speed;

    [SerializeField]private Transform tailEnd;


    private void Start()
    {
        lineRend = this.GetComponent<LineRenderer>();
        lineRend.positionCount = Length;
        segmentPoses = new Vector3[Length];
        segmentV = new Vector3[Length];


    }

    private void Update()
    {
        segmentPoses[0] = targetDir.position;

        for(int i = 1; i<segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], Speed);
        }
        lineRend.SetPositions(segmentPoses);

        tailEnd.position = segmentPoses[segmentPoses.Length - 1];
    }
}
