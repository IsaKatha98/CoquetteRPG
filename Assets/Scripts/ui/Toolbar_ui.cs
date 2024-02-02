using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_ui : MonoBehaviour
{
   [SerializeField] private List<Slot_ui> toolbarSlots = new List<Slot_ui>();

    private Slot_ui selectedSlot;

    private void Start()
    {
        SelectSlot(0);
    }

    private void Update()
    {
        CheckAlphaNumericKeys();
    }

    public void SelectSlot(int index)
    {
        if(toolbarSlots.Count == 9)
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighlight(false);
            }

            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHighlight(true);
        }
    }

    private void CheckAlphaNumericKeys()
    {
        //TODO: poner el codigo m�s bonito, seguro se puede hacer con un switch pero son las 5:27 de la ma�ana y 
        //el cerebro no me da pa m�s
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }

        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }

        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            SelectSlot(7);
        }

        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            SelectSlot(8);
        }
    }
}
