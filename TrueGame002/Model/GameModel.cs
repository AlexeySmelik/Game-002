using TestGame002.Levels;

namespace TestGame002.Model
{
    public class GameModel
    {
        public GameMods CurrentMode = GameMods.PlayMode;
        public Level CurrentLevel = TestLevel.GetTestLevel0();
    }
}