
using UnityEngine;

namespace AppsuTest
{
    public class GameController : ApplicationElement
    {

        [SerializeField] public FiguresController FiguresController;
        public ScoreController ScoreController;
        void Awake()
        {
            ScoreController = new ScoreController(app.model.GameData.Player);
         
            FiguresController.FiguresData =  app.model.GameData.FiguresData;
        }

        private void Start()
        {

            app.model.GameData.Player.DestroyFigure += (figure) => FiguresController.DestroyFigure(figure);

        }
    }
}