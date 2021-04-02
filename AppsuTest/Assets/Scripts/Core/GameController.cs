
using System;
using UnityEngine;

namespace AppsuTest
{
    public class GameController : ApplicationElement
    {

        [SerializeField] public FiguresController FiguresController;
        public ScoreController ScoreController;
      protected override void  Awake()
        {
            base.Awake();
            ScoreController = new ScoreController(app.model.GameData.Player);
         
            FiguresController.FiguresData =  app.model.GameData.FiguresData;
        }

        private void OnDestroy()
        {
            app.model.GameData.Player.DestroyFigure -= OnPlayerOnDestroyFigure;
        }

        private void Start()
        {

            app.model.GameData.Player.DestroyFigure += OnPlayerOnDestroyFigure;

        }

        private void OnPlayerOnDestroyFigure(Figure figure)
        {
            FiguresController.DestroyFigure(figure);
        }
    }
}