namespace Tetris
{
    public class BlockPositions
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public BlockPositions(int r, int c)
        {
            Rows = r;
            Columns = c;
        }
    }
}