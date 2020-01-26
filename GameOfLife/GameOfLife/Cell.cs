using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    public class Cell
    {
        private readonly Brush _aliveCellBrush = Brushes.LimeGreen;
        private readonly Brush _deadCellBrush = Brushes.Crimson;

        private readonly Rectangle _rectangle;

        public Cell(Rectangle rectangle, bool alive)
        {
            _rectangle = rectangle;
            if(alive)
                Live();
            else
            {
                Die();
            }
        }

        public bool Alive { get; private set; }

        public void Die()
        {
            Alive = false;
            _rectangle.Fill = _deadCellBrush;
        }

        public void Live()
        {
            Alive = true;
            _rectangle.Fill = _aliveCellBrush;
        }
    }
}