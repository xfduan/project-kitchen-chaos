using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour {
    [Serializable]
    public struct KitchenObjectSO_GameObject {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSOGameObjectList;

    private void Start() {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (var kitchenObjectSoGameObject in kitchenObjectSOGameObjectList) {
            kitchenObjectSoGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        foreach (
            var kitchenObjectSoGameObject in kitchenObjectSOGameObjectList.Where(
                kitchenObjectSoGameObject => kitchenObjectSoGameObject.kitchenObjectSO == e.kitchenObjectSO
            )
        ) {
            kitchenObjectSoGameObject.gameObject.SetActive(true);
        }
    }
}