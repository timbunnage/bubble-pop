using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float timeToPop = 0.2f;

    [SerializeField]
    private bool popped = false;

    private Renderer _renderer;
    private float _pressureProgress = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (popped) { return; }

        //TODO: ensure mouse is on bubble
        if (Input.GetMouseButton(0)) {
            _pressureProgress += Time.deltaTime;
            Debug.Log(_pressureProgress);
        }
        else {
            _pressureProgress = Mathf.Max(0, _pressureProgress - Time.deltaTime);
        }

        updatePressure();
    }

    // void OnMouseDown(){
    //     Debug.Log("Sprite Clicked");
    //     _renderer.material.color = Color.red;
    // }

    void updatePressure() {
        Color c = _renderer.material.color;
        c.r = _pressureProgress;
        _renderer.material.color = c;

        if (_pressureProgress > timeToPop) {
            popped = true;
            _renderer.material.color = Color.red;
        }
    }


}
