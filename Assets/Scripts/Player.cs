using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Sprite forwardSprite;
    public Sprite rightSprite;
    public Sprite backSprite;
    public Sprite leftSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player around the screen
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f).normalized;
        transform.position += moveSpeed * Time.deltaTime * move;

        float angle = Vector2.SignedAngle(new Vector2(move.x, move.y), Vector2.up);
        print(angle);

        if (move.normalized.magnitude > 0)
        {
            if (angle > -45 && angle < 45)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = forwardSprite;
            }
            else if (angle >= 45 && angle <= 135)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            }
            else if (angle > 135 || angle < -135)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = backSprite;
            }
            else if (angle >= -135 && angle <= -45)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            }
        }
    }
}
