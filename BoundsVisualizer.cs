using UnityEngine;
using UnityEngine.U2D;


[ExecuteAlways]
public class BoundsVisualizer : MonoBehaviour
{
    public bool showSpriteRendererBounds = true; // Toggle for SpriteRenderer bounds
    public bool showSpriteShapeRendererBounds = false; // Toggle for SpriteShapeRenderer bounds

    private SpriteRenderer _spriteRenderer;
    private SpriteShapeRenderer _spriteShapeRenderer;

    private void OnDrawGizmos()
    {
        if (showSpriteRendererBounds)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (_spriteRenderer != null)
            {
                DrawBounds(_spriteRenderer.bounds);
            }
        }

        if (showSpriteShapeRendererBounds)
        {
            _spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
            if (_spriteShapeRenderer != null)
            {
                DrawBounds(_spriteShapeRenderer.bounds);
            }
        }
    }

    private void DrawBounds(Bounds bounds)
    {
        Gizmos.color = Color.green; // Color of the bounds
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
