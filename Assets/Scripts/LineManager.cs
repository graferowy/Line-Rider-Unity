using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private GameObject _line;
    private Transform _lineContainer;
    private Line _currentLine;
    private Camera _mainCamera;

    private void Awake()
    {
        _lineContainer = GameObject.Find("Line Container").transform;
        _currentLine = null;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0) && _currentLine != null)
        {
            UpdateLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentLine = null;
        }
    }

    private void CreateLine()
    {
        _currentLine = Instantiate(_line, _lineContainer).GetComponent<Line>();
    }

    private void UpdateLine()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _currentLine.AddPosition(mousePosition);
    }
}
