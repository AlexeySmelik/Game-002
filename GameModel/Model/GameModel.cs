using Game002.Levels;
using TestGame002;

namespace Game002.Model
{
    public class GameModel
    {
        public GameMods CurrentMode = GameMods.PlayMode;
        public Level CurrentLevel = TestLevel.GetTestLevel0();
    }
}