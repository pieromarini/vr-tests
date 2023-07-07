using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System;

public class FlowerPotTooltipManager : MonoBehaviour
{
    public Transform playerTransform;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI fertilizerText;
    public TextMeshProUGUI waterTimeText;
    public TextMeshProUGUI fertilizerTimeText;
    public Transform target;
    public GameObject UITransform;

    Flower flower = null;

    void Update()
    {
        if (flower != null)
        {
            // Always face the target (Player).
            transform.LookAt(target, Vector3.up);
            transform.rotation = Quaternion.LookRotation(transform.position - target.position);

            UpdateTimerText();
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        GameObject flowerPot = args.interactableObject.transform.gameObject;

        flower = flowerPot.GetComponent<Flower>();
        SetFlowerStats(flower);

        Vector3 center = (playerTransform.position + flowerPot.transform.position) * 0.5f;
        transform.GetComponent<RectTransform>().position = new Vector3(center.x, center.y + 0.5f, center.z - 0.4f);

        UITransform.SetActive(true);
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        UITransform.SetActive(false);
        flower = null;
    }

    void SetFlowerStats(Flower flower)
    {
        nameText.text = flower.getFlowerName();
        waterText.text = "Water: " + flower.getWaterNeeds().ToString();
        fertilizerText.text = "Fertilizer: " + flower.getFertilizerNeeds().ToString();
    }

    void UpdateTimerText()
    {
        TimeSpan waterTS = flower.remaningTimeWater();
        TimeSpan fertilizerTS = flower.remaningTimeFertilizer();

        waterTimeText.text = string.Format("{0}:{1:00}:{2:00}", waterTS.Hours, waterTS.Minutes, waterTS.Seconds);
        fertilizerTimeText.text = string.Format("{0}:{1:00}:{2:00}", fertilizerTS.Hours, fertilizerTS.Minutes, fertilizerTS.Seconds);

        if (waterTS.TotalMilliseconds < 0.0)
        {
            waterTimeText.color = Color.red;
        }

        if (fertilizerTS.TotalMilliseconds < 0.0)
        {
            fertilizerTimeText.color = Color.red;
        }
    }
}
