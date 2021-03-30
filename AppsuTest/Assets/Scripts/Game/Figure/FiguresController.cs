
using AppsuTest.Utils;
using UnityEngine;

namespace AppsuTest
{
    public class FiguresController : ApplicationElement
    {
         internal FiguresData FiguresData;
        [SerializeField] private LayerMask Mask;
        [SerializeField] private int RequiredNumberOfObjects;
        [SerializeField] private Figures Figure=Figures.Square;
        [SerializeField] private FiguresGenerator figuresGenerator;
        [SerializeField] private float DelayOnStart;
        [SerializeField] private float Delay;




        private Coroutine _generate;

        private void Start()
        {
            _generate=StartCoroutine(figuresGenerator.GenerateFigures(FiguresData.FiguresList[(int)Figure], FiguresData.FiguresInstantiated, RequiredNumberOfObjects, 0,
                Delay,Mask));

        }

        public void DestroyFigure(Figure figure)
        {
            StopCoroutine(_generate);
            FiguresData.FiguresInstantiated.Remove(figure);
            GenerateFigure();
        }

        void GenerateFigure()
        {
            _generate=StartCoroutine(figuresGenerator.GenerateFigures(FiguresData.FiguresList[(int)Figure], FiguresData.FiguresInstantiated, RequiredNumberOfObjects,
                DelayOnStart, Delay,Mask));
        }
    }
}