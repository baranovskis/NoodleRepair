using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixManager : MonoBehaviour
{
    [SerializeField]
    private GameObject NoodleModel;
    [SerializeField]
    private GameObject GlueModel;
    [SerializeField]
    private GameObject FlexTapeModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void FixArea(FixableArea fixableArea)
    {
        switch(fixableArea.FixableObjectStage)
        {
            case FixableObjectStage.Damaged:
                {
                    FixWithNoodles(fixableArea);
                    break;
                }
            case FixableObjectStage.FilledWithNoodles:
                {
                    FixWithGlue(fixableArea);
                    break;
                }
            case FixableObjectStage.FilledWithGlue:
                {
                    FixWithGrinding(fixableArea);
                    break;
                }
            case FixableObjectStage.Grinded:
                {
                    FixWithPainting(fixableArea);
                    break;
                }
            case FixableObjectStage.Leaking:
                {
                    FixWithFlexTape(fixableArea);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void FixWithFlexTape(FixableArea fixableArea)
    {
        throw new NotImplementedException();
    }

    internal void FixPart(FixablePart fixablePart)
    {
        throw new NotImplementedException();
    }

    private void FixWithPainting(FixableArea fixableArea)
    {
        throw new NotImplementedException();
    }

    private void FixWithGrinding(FixableArea fixableArea)
    {
        throw new NotImplementedException();
    }

    private void FixWithGlue(FixableArea fixableObject)
    {
        throw new NotImplementedException();
    }

    private void FixWithNoodles(FixableArea fixableArea)
    {
        var player = GetComponent<Player>();
        if (player != null)
        {
            var noodle = player.InventoryUI.GetItem(Item.ItemType.Noodle);

            if (noodle != null && noodle.Amount > 0)
            {
                fixableArea.FixWithNoodles();
                player.InventoryUI.UseInventoryItem(noodle);
            }
            else
            {
               // show noodle warning
            }
        }
    }
}
