using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int _score;

    private void OnEnable() => Coin.Collected += OnCoinCollected;
    private void OnDisable() => Coin.Collected -= OnCoinCollected;

    private void Start() => UpdateText();

    private void OnCoinCollected(Vector3 position)
    {
        _score++;
        UpdateText();
    }

    private void UpdateText() => scoreText.text = "Coins: " +  _score;
}
