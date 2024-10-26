using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixedXRGrabInterectable : XRGrabInteractable
{
    [SerializeField] private Transform LeftHandAttachTransform;
    [SerializeField] private Transform rightHandAttachTransform;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = LeftHandAttachTransform;
        }
        if(args.interactableObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightHandAttachTransform;
        }


        base.OnSelectEntered(args);
    }
}
