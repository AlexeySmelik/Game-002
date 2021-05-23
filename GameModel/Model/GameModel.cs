using GameModel.Levels;

namespace GameModel.Model
{
    public class GameModel
    {
        public Level CurrentLevel;

        public void GenerateCurrentLevel()
        {
            CurrentLevel = TestLevel.GetTestLevel0();
        }
    }
}