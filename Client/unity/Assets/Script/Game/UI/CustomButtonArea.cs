﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
public class CustomButtonArea : Image
{
       new PolygonCollider2D collider;
    protected override void  Awake()
    {
        collider = GetComponent<PolygonCollider2D>();
    }
    override public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return ContainsPoint(collider.points, sp);
    }
    bool ContainsPoint(Vector2[] polyPoints, Vector2 p)
    {
        var j = polyPoints.Length - 1;
        var inside = false;
        for (int i = 0; i < polyPoints.Length; j = i++)
        {
            polyPoints[i].x += transform.position.x;
            polyPoints[i].y += transform.position.y;
            if (((polyPoints[i].y <= p.y && p.y < polyPoints[j].y) || (polyPoints[j].y <= p.y && p.y < polyPoints[i].y)) &&
                (p.x < (polyPoints[j].x - polyPoints[i].x) * (p.y - polyPoints[i].y) / (polyPoints[j].y - polyPoints[i].y) + polyPoints[i].x))
                inside = !inside;
        }
        return inside;
    }
}
