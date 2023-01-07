using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float deathTime = 20f;
    public float deathProgress= 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onDeath();
    }

    void onDeath()
    {
        if(deathTime > deathProgress)
        {
            Transform t = transform;
            t.localScale = new Vector3(t.localScale.x + 0.05f, t.localScale.y + 0.05f, t.localScale.z);
            deathProgress += 1;
        } else
        {
            Destroy(gameObject);
        }
    }
}
