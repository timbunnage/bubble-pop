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

    public ContactFilter2D movementFilter;

    private DialogueManager _dialogueManager; 
    
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    
    private Vector2 _movementVector;
    
    private readonly List<RaycastHit2D> _castCollisions = new();

    // Start is called before the first frame update
    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<Collider2D>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position += moveSpeed * Time.deltaTime * new Vector3(_movementVector.x, _movementVector.y, 0);
    }

    private void FixedUpdate()
    {
        if (_dialogueManager.active) return;
        
        var count = _rigidbody.Cast(
            _movementVector.normalized,
            movementFilter,
            _castCollisions,
            moveSpeed * Time.fixedDeltaTime
        );
        
        if (count > 0)
        {
            foreach (var hit in _castCollisions)
            {
                print(hit.ToString());
            }

            return;
        }
        
        _rigidbody.MovePosition(_rigidbody.position + moveSpeed * Time.fixedDeltaTime * _movementVector);
    }

    private void OnMove(InputValue inputValue)
    {
        _movementVector = inputValue.Get<Vector2>().normalized;

        // Get movement direction
        var angle = Vector2.SignedAngle(_movementVector, Vector2.up);
        switch (angle)
        {
            // Change sprites based on movement direction
            case > -45 and < 45: // N
                _spriteRenderer.sprite = forwardSprite;
                break;
            case >= 45 and <= 135: // E
                _spriteRenderer.sprite = rightSprite;
                break;
            case > 135:
            case < -135: // S
                _spriteRenderer.sprite = backSprite;
                break;
            case >= -135 and <= -45:// W
                _spriteRenderer.sprite = leftSprite;
                break;
        }
    }

    private void OnInteract(InputValue inputValue)
    {
        if (_dialogueManager.active)
        {
            _dialogueManager.ProgressDialogue();
            return;
        }
        
        var filter = new ContactFilter2D().NoFilter();
        var colliderList = new List<Collider2D>();
        _collider.OverlapCollider(filter, colliderList);

        foreach (var overlappingCollider in colliderList)
        {
            overlappingCollider.gameObject.GetComponent<Item>().Collect();
        }
    }
}
