using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FlowerPotTooltipManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI fertilizerText;
    public Transform target;

    void Update()
    {
        // Always face the target (Player).
        transform.LookAt(target, Vector3.up);
    }

    public void OnHoverEntered(HoverEnterEventArgs args) {
        GameObject flowerPot = args.interactableObject.transform.gameObject;
        Flower flower = flowerPot.GetComponent<Flower>();
        setFlowerStats(flower);
        transform.gameObject.SetActive(true);
    }

    public void OnHoverExited(HoverExitEventArgs args) {
        transform.gameObject.SetActive(false);
    }

    void setFlowerStats(Flower flower) { 
        string name = flower.getFlowerName();
        float water = flower.getWaterNeeds();
        float fertilizer = flower.getFertilizerNeeds();

        nameText.text = name;
        waterText.text = "Water: " + water.ToString();
        fertilizerText.text = "Fertilizer: " + fertilizer.ToString();
    }
}
