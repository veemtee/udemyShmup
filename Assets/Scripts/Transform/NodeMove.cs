﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    public float speed = 2f, rotateSpeed = 2f, bankingValue = 5f;
    public bool rotateObject, loopMove;
    public int loopToNode;
    public List<Vector3> nodes = new List<Vector3>();

    private const int CURVE_SEGMENT = 20;
    private int realLoopNode;
    private Transform parent;
    private float nextAngleGrab;

    private Quaternion rotation;

    private void OnEnable()
    {
        StartCoroutine(StartMove());

        if (transform.parent)
        {
            parent = transform.parent;
        }
        else
        {
            parent = transform;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator StartMove()
    {
        float oldAngle = 0f;
        int posID = 0;
        List<Vector3> path = GetCurveNodes();

        while (loopMove || posID < path.Count - 1)
        {
            //this handles the index of the path vectors, and decide the next target position
            if ((path[posID] - transform.localPosition).sqrMagnitude < 0.01f)
            {
                if (loopMove)
                {
                    if (posID < path.Count - 1)
                    {
                        posID += 1;
                    }
                    else
                    {
                        posID = realLoopNode;
                    }
                }
                else
                {
                    if (posID < path.Count - 1)
                    {
                        posID += 1;
                    }
                }
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, path[posID], speed * Time.deltaTime);

            if (rotateObject)
            {
                if (Time.time > nextAngleGrab)
                {
                    nextAngleGrab = Time.time + 0.5f;

                    Vector3 dir = path[posID] - transform.localPosition;

                    if (dir.sqrMagnitude > 0.01f)
                    {
                        rotation = Quaternion.LookRotation(dir, Vector3.up);
                    }

                    float zBank = Mathf.Clamp(rotation.eulerAngles.y - oldAngle, -10f, 10f);

                    Quaternion banking = Quaternion.Euler(0f, 0f, Mathf.Ceil(zBank) * -bankingValue);

                    rotation *= banking;

                    oldAngle = rotation.eulerAngles.y;
                }

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            }

            yield return null;
        }
    }

    List<Vector3> GetCurveNodes()
    {
        if (transform.parent)
        {
            parent = transform.parent;
        }
        else
        {
            parent = transform;
        }

        List<Vector3> curvedNodes = new List<Vector3>();
        curvedNodes.Add(parent.InverseTransformPoint(transform.position));

        for (int i = 0; i < nodes.Count - 3; i += 3)
        {
            Vector3 p0 = parent.InverseTransformPoint(nodes[i]);
            Vector3 p1 = parent.InverseTransformPoint(nodes[i + 1]);
            Vector3 p2 = parent.InverseTransformPoint(nodes[i + 2]);
            Vector3 p3 = parent.InverseTransformPoint(nodes[i + 3]);

            if (i == 0)
            {
                p0 = parent.InverseTransformPoint(transform.position);
                curvedNodes.Add(CalculateBezierPath(p0, p1, p2, p3, 0f));
            }

            for (int j = 0; j < CURVE_SEGMENT; j++)
            {
                float t = j / (float)CURVE_SEGMENT;
                curvedNodes.Add(CalculateBezierPath(p0, p1, p2, p3, t));
            }
        }

        realLoopNode = (int)(curvedNodes.Count * (loopToNode / (float)nodes.Count));

        print(curvedNodes.Count);

        return curvedNodes;
    }

    Vector3 CalculateBezierPath(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        // (1 - t)^3 * p0 + 3(1-t)^2 * t * p1 + 3(1-t) * t^2 * p2 + t^3 * p3

        float oneMinusT = 1f - t;

        Vector3 result = Mathf.Pow(oneMinusT, 3f) * p0 + 3f * Mathf.Pow(oneMinusT, 2f) * t * p1 
            + 3f * oneMinusT * (t * t) * p2 + Mathf.Pow(t, 3f) * p3;

        return result;
    }

    private void OnDrawGizmosSelected()
    {
        List<Vector3> curvePositions = GetCurveNodes();

        for (int i = 1; i < curvePositions.Count; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(parent.TransformPoint(curvePositions[i - 1]), parent.TransformPoint(curvePositions[i]));
        }

        for (int i = 1; i < nodes.Count; i++)
        {
            Color gizmoColor = Color.yellow;
            gizmoColor.a = 0.5f;
            Gizmos.color = gizmoColor;
            Gizmos.DrawLine(nodes[i - 1], nodes[i]);
        }
    }
}
