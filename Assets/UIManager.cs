using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreLeft;
    [SerializeField] private TextMeshProUGUI ScoreRight;
    int scoreLeft;
    int scoreRight;

    public void UpdateScoreLeft()
    {
        scoreLeft += 1;
        ScoreLeft.text = $"{scoreLeft}";
    }

    public void UpdateScoreRight() {
        scoreRight += 1;
        ScoreRight.text = $"{scoreRight}";
    }


}
