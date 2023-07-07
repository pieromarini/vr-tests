using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WateringCan : MonoBehaviour
{
    public Transform interactorTransform;
    public ParticleSystem waterParticles;
    public float multiplier = 1;

    private void Start()
    {
        XRGrabInteractable interactble = GetComponent<XRGrabInteractable>();
        interactble.selectEntered.AddListener(Selected);
        interactble.selectExited.AddListener(Deselected);
    }

    private void FixedUpdate()
    {
        if (interactorTransform != null)
        {
            if (transform.rotation.eulerAngles.z >= 25 && interactorTransform.rotation.eulerAngles.z <= 90) {
                if (!waterParticles.isPlaying)
                {
                    waterParticles.Play();
                }
            }
            else if (waterParticles.isPlaying)
            {
                waterParticles.Stop();
            }
        }
    }

    public void Selected(SelectEnterEventArgs arguments)
    {
        interactorTransform = arguments.interactorObject.transform;
    }

    public void Deselected(SelectExitEventArgs arguments)
    {
        interactorTransform = null;
    }

}
