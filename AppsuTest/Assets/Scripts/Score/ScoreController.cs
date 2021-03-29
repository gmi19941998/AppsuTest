
namespace AppsuTest
{
    public  class ScoreController
    {
        private   ICounter<float> Distance;
        private   ICounter<int> Score;

        public float DistanceCount => Distance.Value;
        public float ScoreCount => Score.Value;


        public ScoreController(Player player)
        {
            Distance=new DistanceCount();
            Score=new ScoreCount();
            player.UpdateDistanceCount += UpdateDistanceCount;
            player.UpdateScoreCount +=  UpdateScoreCountCount;

        }


        void UpdateDistanceCount(float distance)
        {
            Distance.Value +=  distance;

        }
        void UpdateScoreCountCount(int score)
        {
            Score.Value +=  score;

        }

    }

}
