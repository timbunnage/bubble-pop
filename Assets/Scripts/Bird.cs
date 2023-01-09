using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float travelDistance = 300; // Units to travel
    public float travelSpeed = 4; // Units per second

    [Serializable]
    public enum TravelDirection
    {
        Left,
        Right
    }

    public TravelDirection travelDirection = TravelDirection.Left;

    public Sprite[] spriteList;

    private SpriteRenderer _spriteRenderer;

    private float _travelledDistance = 0f;
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch (travelDirection)
        {
            case TravelDirection.Left:
                _spriteRenderer.sprite = spriteList[0];
                break;
            case TravelDirection.Right:
                _spriteRenderer.sprite = spriteList[1];
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float travelStep;
        
        switch (travelDirection)
        {
            case TravelDirection.Left:
                if (_travelledDistance >= travelDistance)
                {
                    // Switch direction
                    travelDirection = TravelDirection.Right;
                    _travelledDistance = 0f;
                    _spriteRenderer.sprite = spriteList[1];
                    break;
                }
                
                // Move left
                travelStep = Time.deltaTime * travelSpeed;
                transform.position -= new Vector3(travelStep, 0, 0);
                _travelledDistance += travelStep;
                break;
            case TravelDirection.Right:
                if (_travelledDistance >= travelDistance)
                {
                    // Switch direction
                    travelDirection = TravelDirection.Left;
                    _travelledDistance = 0f;
                    _spriteRenderer.sprite = spriteList[0];
                    break;
                }
                
                // Move right
                travelStep = Time.deltaTime * travelSpeed;
                transform.position += new Vector3(travelStep, 0, 0);
                _travelledDistance += travelStep;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
