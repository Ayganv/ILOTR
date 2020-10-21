using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnits : MonoBehaviour
{
    public GoldProductionUnit[] goldProductionUnits;
    public Transform goldProductionUnitParent;
    public GameObject goldProductionUnitPrefab;

    void Start() {
        foreach (var productionUnit in this.goldProductionUnits) {
            var instance = Instantiate(this.goldProductionUnitPrefab, this.goldProductionUnitParent);
            instance.GetComponent<GoldProductionManager>().SetupUnit(productionUnit);
        }
    }
}
