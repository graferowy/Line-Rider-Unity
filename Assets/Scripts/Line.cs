using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer _renderer;
    private EdgeCollider2D _collider;
    private List<Vector2> _positions;

    private void Awake()
    {
        _renderer = GetComponent<LineRenderer>();
        _collider = GetComponent<EdgeCollider2D>();
        _positions = new List<Vector2>();
    }

    public void AddPosition(Vector2 position)
    {
        if (position == _positions.LastOrDefault()) return;

        _positions.Add(position);
        UpdateLine();
    }

    private void UpdateLine()
    {
        UpdateRenderer();
        UpdateCollider();
    }

    private void UpdateRenderer()
    {
        _renderer.positionCount = _positions.Count;
        _renderer.SetPosition(_positions.Count - 1, _positions.Last());
    }

    private void UpdateCollider()
    {
        if (_positions.Count > 1)
        {
            _collider.SetPoints(_positions);
        }
    }
}
