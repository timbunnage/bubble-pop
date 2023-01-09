using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private bool goLeft;
    private SpriteRenderer _spriteRenderer;

    private Vector2 startPosition;
    private Vector2 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        endPosition = new Vector2(startPosition.x -30, startPosition.y);
        goLeft = true;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (goLeft)
        {
            if (transform.localPosition.x > endPosition.x)
            {
                transform.position = new Vector2(transform.position.x - 0.02f, transform.position.y);
            }
            else
            {
                goLeft = false;
                _spriteRenderer.flipX = true;
            }
        }


        if (!goLeft)
            {
                if (transform.localPosition.x < startPosition.x)
                {
                    transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
                }
                else
                {
                 goLeft = true;
                 _spriteRenderer.flipX = false;

                }

        }


    }
}
