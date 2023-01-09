using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle : Item
{
    [NonSerialized]
    public bool Collectable;
    
    public string[] clearDialogueList =
    {
        "I can get through now!"
    };
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override bool Collect()
    {
        if (!Collectable) return false;
        
        DialogueManager.CallDialogue(clearDialogueList.ToList());
        
        return base.Collect();
    }

    public void Clear()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        
        Collectable = true;
    }
}
