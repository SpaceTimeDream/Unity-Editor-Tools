using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCollider : MonoBehaviour
{
    new public bool enabled = true;
    public Vector3 colliderCenter = Vector3.zero;
    public Vector3 colliderSize = Vector3.one;

    public BoxCollider2D[] boxCollider2DArray;
    public CircleCollider2D[] circleCollider2DArray;
    public PolygonCollider2D[] polygonCollider2DArray;
    public EdgeCollider2D[] edgeCollider2DArray;

    void OnDrawGizmos()
    {
        if (!enabled) return;

        boxCollider2DArray = GetComponents<BoxCollider2D>();
        circleCollider2DArray = GetComponents<CircleCollider2D>();
        polygonCollider2DArray = GetComponents<PolygonCollider2D>();
        edgeCollider2DArray = GetComponents<EdgeCollider2D>();

        Gizmos.color = Color.yellow;

        foreach (BoxCollider2D collider in boxCollider2DArray)
        {
            if (collider.enabled)
            {
                colliderCenter.x = collider.offset.x;
                colliderCenter.y = collider.offset.y;
                Gizmos.DrawWireCube(transform.position + transform.rotation * colliderCenter, collider.size);
            }
        }

        foreach (CircleCollider2D collider in circleCollider2DArray)
        {
            if (collider.enabled)
            {
                Gizmos.DrawWireSphere(transform.position + (Vector3)collider.offset, collider.radius);
            }
        }

        foreach (PolygonCollider2D collider in polygonCollider2DArray)
        {
            if (collider.enabled)
            {
                Vector2[] points = collider.points;
                Vector3[] vertices = new Vector3[points.Length];

                for (int i = 0; i < points.Length; i++)
                {
                    vertices[i] = transform.TransformPoint(points[i] + (Vector2)collider.offset);
                }

                Gizmos.DrawLine(vertices[vertices.Length - 1], vertices[0]);

                for (int i = 0; i < vertices.Length - 1; i++)
                {
                    Gizmos.DrawLine(vertices[i], vertices[i + 1]);
                }
            }
        }

        foreach (EdgeCollider2D collider in edgeCollider2DArray)
        {
            if (collider.enabled)
            {
                Vector2[] points = collider.points;
                Vector3[] vertices = new Vector3[points.Length];

                for (int i = 0; i < points.Length; i++)
                {
                    vertices[i] = transform.TransformPoint(points[i] + (Vector2)collider.offset);
                }

                for (int i = 0; i < vertices.Length - 1; i++)
                {
                    Gizmos.DrawLine(vertices[i], vertices[i + 1]);
                }
            }
        }
    }
}
