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
            _distanceText.text = $"Distance:<br>{_distanceScore:N2}";
            _score = app.controller.GameController.ScoreController.ScoreCount;
            _scoreText.text = $"Score:<br>{_score}";
        }
    }
 
}
