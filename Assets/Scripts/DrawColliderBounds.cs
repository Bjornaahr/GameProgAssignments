using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawColliderBounds : MonoBehaviour
{
    private PolygonCollider2D _collider;
    private LineRenderer _lineRenderer;
    private Vector3[] _pColPoints;

    public bool _hoverB, _selectedB;

    // Customisable colors for 3 color states should be done in the prefab
    [SerializeField]
    Color _standard, _hover, _selected;
    void Start()
    {
        _collider = GetComponent<PolygonCollider2D>();
        _lineRenderer = GetComponent<LineRenderer>();
        _pColPoints = new Vector3[_collider.points.Length];
        OutlineCollider(_standard, 0.1f);
    }
    // Change the color to one given
    void ChangeColor(Color color)
    {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }

    // Draws the outline of the MapZone
    void OutlineCollider(Color color, float hightlightSize = 0.2f)
    {
        float zPos = -0.5f;
        // Adds shader as ones needed to change the color
        _lineRenderer.material = new Material (Shader.Find("Sprites/Default"));
        ChangeColor(color);
        _lineRenderer.startWidth = hightlightSize;
        _lineRenderer.endWidth = hightlightSize;

        // Change the V2 points to V3
        for (int j = 0; j< _collider.points.Length; j++) {
            _pColPoints[j] = new Vector3(_collider.points[j].x, _collider.points[j].y, zPos);
            
        }
        // Transform collider points into world transform 
        for (int j = 0; j < _pColPoints.Length; j++)
        {
            _pColPoints[j] = _collider.transform.TransformPoint(_pColPoints[j]);
        }
        // Sets proper length of points and adds the points to the renderer
        _lineRenderer.positionCount = _pColPoints.Length;
        _lineRenderer.SetPositions(_pColPoints);
                
        
    }

    void Update()
    {   // Sets color to hover color
        if (_hoverB) {
            ChangeColor(_hover);
        // Sets color to selected color 
        } else if (_selectedB)
        {
            ChangeColor(_selected);
        // Sets color to standard color    
        } else
        {
            ChangeColor(_standard);
        }
    }
}
