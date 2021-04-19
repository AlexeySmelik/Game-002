using Game002.Levels;

namespace GameModel.Model
{
    public class GameModel
    {
        public GameMods CurrentMode = GameMods.PlayMode;
        public Level CurrentLevel = TestLevel.GetTestLevel0();
    }
}