using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AppsuTest.Utils
{
    public class FiguresGenerator : MonoBehaviour, IGeneratorObjects<Figure>
    {

        private int failureLimit = 100;

        public IEnumerator GenerateFigures(Figure Object, List<Figure> ObjectsList, int RequiredNumberOfObjects,
            float DelayOnStart, float Delay, LayerMask Mask)
        {
            yield return new WaitForSeconds(DelayOnStart);
            while (true)
            {
          
                if (ObjectsList.Count >= RequiredNumberOfObjects) yield break;
                Vector3 randomSpawnPosition = CheckValidPosition(Object);

                if (randomSpawnPosition == Vector3.zero)
                {
                    yield break;
                }
                else
                {
                    var newObject = Instantiate(Object, randomSpawnPosition, Quaternion.identity);
                    ObjectsList.Add(newObject);
                }

                yield return new WaitForSeconds(Delay);
            }

            Vector3 CheckValidPosition(Figure figure)
            {
        
                Vector3 newPosition = Vector3.zero;
                bool validPosition = false;
                int fails = 0;
                Vector2 screenMin = Camera.main.ViewportToWorldPoint(Vector3.zero);
                Vector2 screenMax = Camera.main.ViewportToWorldPoint(Vector3.one);

                do
                {
                    newPosition.x = Random.Range(screenMin.x*0.9f, screenMax.x*0.9f);
                    newPosition.y = Random.Range(screenMin.y*0.9f, screenMax.y*0.75f);

                    Vector2 min = newPosition - (Vector3)figure.Scale/2;
                    Vector2 max = newPosition + (Vector3)figure.Scale/2;

                    Collider2D[] overlapObjects = Physics2D.OverlapAreaAll(min, max, Mask);

                    if (overlapObjects.Length == 0)
                    {
                        validPosition = true;
                        fails = 0;
                    }
                    else
                    {
                   
                        fails++;
                    }
                } while (!validPosition && fails < failureLimit);

                return fails == failureLimit ? Vector3.zero : newPosition;
            }
        }
    }
}