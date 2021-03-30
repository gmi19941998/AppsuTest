using TMPro;
using UnityEngine;

namespace AppsuTest
{
    public class ScoreUI : ApplicationElement
    {
        [SerializeField] private TMP_Text _distanceText;
        [SerializeField] private TMP_Text _scoreText;
    
        private float _distanceScore;
        private float _score;
    

        private void LateUpdate()
        {
            _distanceScore = app.controller.GameController.ScoreController.DistanceCount;
            _distanceText.text = $"Distance:<br><color=red>{_distanceScore:N2}</color>";
            _score = app.controller.GameController.ScoreController.ScoreCount;
            _scoreText.text = $"Score:<br><color=red>{_score}</color>";
        }
    }
 
}
