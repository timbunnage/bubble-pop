using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Sprite forwardSprite;
    public Sprite rightSprite;
    public Sprite backSprite;
    public Sprite leftSprite;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    
    private Vector2 _movementVector;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * new Vector3(_movementVector.x, _movementVector.y, 0);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementVector = inputValue.Get<Vector2>().normalized;

        if (_movementVector.magnitude > 0)
        {
            // Get movement direction
            float angle = Vector2.SignedAngle(_movementVector, Vector2.up);
        
            // Change sprites based on movement direction
            if (angle > -45 && angle < 45) // N
            {
                _spriteRenderer.sprite = forwardSprite;
            }
            else if (angle >= 45 && angle <= 135) // E
            {
                _spriteRenderer.sprite = rightSprite;
            }
            else if (angle > 135 || angle < -135) // S
            {
                _spriteRenderer.sprite = backSprite;
            }
            else if (angle >= -135 && angle <= -45) // W
            {
                _spriteRenderer.sprite = leftSprite;
            }
        }
    }

    private void OnInteract(InputValue inputValue)
    {
        var filter = new ContactFilter2D().NoFilter();
        var colliderList = new List<Collider2D>();
        _collider.OverlapCollider(filter, colliderList);

        foreach (Collider2D overlappingCollider in colliderList)
        {
            overlappingCollider.gameObject.GetComponent<Item>().Collect();
        }
    }
}
