using AppsuTest.Utils;
using UnityEngine;

namespace AppsuTest
{
    public class FiguresController : ApplicationElement
    {
         internal FiguresData FiguresData;
        [SerializeField] private LayerMask Mask;
        [SerializeField] private int RequiredNumberOfObjects;
        [SerializeField] private Figures Figure;
        [SerializeField] private FiguresGenerator figuresGenerator;
        [SerializeField] private float DelayOnStart;
        [SerializeField] private float Delay;
        private Coroutine _generate;

        private void Start()
        {
            GenerateFigure(0);

        }

        public void DestroyFigure(Figure figure)
        {
            StopCoroutine(_generate);
            FiguresData.FiguresInstantiated.Remove(figure);
            GenerateFigure(DelayOnStart);
        }

        void GenerateFigure(float delayOnStart)
        {
            foreach (var figure in FiguresData.FiguresList)
            {
                if (figure.FigureType == Figure)
                {
                    _generate=StartCoroutine(figuresGenerator.GenerateFigures(figure, FiguresData.FiguresInstantiated, RequiredNumberOfObjects,
                        delayOnStart, Delay,Mask));
                }   
            }

        }
    }
}