using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;

    private void Start() {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e) {
        if (GameManager.Instance.IsGameOver()) {
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();

            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        transform.gameObject.SetActive(true);
    }

    private void Hide() {
        transform.gameObject.SetActive(false);
    }
}