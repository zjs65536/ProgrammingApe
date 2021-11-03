
namespace Sprint5
{
    public class EnemyData
    {
        public SpriteType Type;
        public int xPosition;
        public int yPosition;
    }

    public class BlockData
    {
        public SpriteType Type;
        public int xPosition;
        public int yPosition;
        public int xCount;
        public int yCount;
    }

    public enum SpriteType
    {
        Stone, Wood,
        Soldier, Bunker, Captain, Boss
    }
}
