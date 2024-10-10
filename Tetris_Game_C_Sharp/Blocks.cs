namespace Tetris
{
    using System.Collections.Generic;
        public abstract class Blocks
    {
        private int state;
        private BlockPositions offset;
        protected abstract BlockPositions[][] Tiles { get; }
        protected abstract BlockPositions InitialOffset { get; }
        public abstract int Id { get; }

        public Blocks()
        {
            offset = new BlockPositions(InitialOffset.Rows, InitialOffset.Columns);
        }

        public IEnumerable<BlockPositions> TilePosition()
        {
            foreach (BlockPositions pos in Tiles[state])
            {
                yield return new BlockPositions(pos.Rows + offset.Rows, pos.Columns + offset.Columns);
            }
        }

        public void Rotate_90_Clkwise()
        {
            state = (state + 1) % Tiles.Length;
        }

        public void Rotate_90_CtrClkwise()
        {
            if (state == 0) { state = Tiles.Length; }
            else { state--; }
        }

        public void MoveBlock(int r, int c)
        {
            offset.Rows += r;
            offset.Columns += c;
        }

        public void ResetBlocks()
        {
            state = 0;
            offset.Rows = InitialOffset.Rows;
            offset.Columns = InitialOffset.Columns;
        }
    }
}