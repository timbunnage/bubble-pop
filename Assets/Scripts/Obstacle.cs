using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle : Item
{
    public bool solid;
    
    private bool _collectable;

    private Collider2D _collider;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override bool Collect()
    {
        return _collectable && base.Collect();
    }

    public void Clear()
    {
        _collectable = true;
        if (!solid)
        {
            _collider.isTrigger = true;
        }

        if (solid)
        {
            StoryManager.Inventory[Flower.FlowerType.TentKey] = 1;
        }
        Collect();
    }
}
