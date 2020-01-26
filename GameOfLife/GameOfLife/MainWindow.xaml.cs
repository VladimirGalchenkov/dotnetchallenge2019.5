using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Brush _gridBrush = Brushes.CornflowerBlue;


        private readonly int _step;

        private const int Size = 40;

        private Cell[,] _field;

        private Random _rnd = new Random();

        public MainWindow()
        {
            Loaded += (sender, args) => StartGame();

            InitializeComponent();

            _step = (int)canvas.Height / Size;

            _field = new Cell[Size, Size];

            InitializeGame();
        }

        private void StartGame()
        {
            while (true)
            {
                MakeMove();
                Delay();
            }
        }

        private void MakeMove()
        {
        }

        private void DrawGrid()
        {
            for (int i = 0; i <= canvas.Width; i += _step)
            {
                DrawLine(0, i, (int)canvas.Width, i);
                DrawLine(i, 0, i, (int)canvas.Height);
            }
        }

        private void InitializeGame()
        {
            InitializeCells();
            DrawGrid();
        }

        private void InitializeCells()
        {
        }

        private Cell CreateCell(int x, int y, bool alive)
        {
            var rect = new Rectangle
            {
                Height = _step, 
                Width = _step
            };

            Canvas.SetLeft(rect, x * _step);
            Canvas.SetTop(rect, y * _step);

            canvas.Children.Add(rect);

            return new Cell(rect, alive);
        }

        private void DrawLine(int x , int y, int x2, int y2)
        {
            var line = new Line
            {
                Stroke = _gridBrush,
                StrokeThickness = 1,
                X1 = x,
                Y1 = y,
                X2 = x2,
                Y2 = y2
            };

            canvas.Children.Add(line);
        }

        private void Delay(int ms = 100)
        {
            Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => Thread.Sleep(ms)));
        }
    }
}
