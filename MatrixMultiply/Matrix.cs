using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiply
{
    public class Matrix
    {
        private static readonly Random Random = new Random();

        private readonly int[,] _matrix;
        public readonly int Rows;
        public readonly int Columns;


        public int this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }


        public Matrix(int rows, int columns, bool fill = false)
        {
            Rows = rows;
            Columns = columns;
            _matrix = new int[rows, columns];

            if (!fill)
                return;

            for (var row = 0; row < rows; row++)
                for (var col = 0; col < columns; col++)
                    _matrix[row, col] = Random.Next(0, 11);
        }

        public static Matrix MultiplySequental(Matrix m1, Matrix m2)
        {
            var m = new Matrix(m1.Rows, m2.Columns);

            for (var row = 0; row < m1.Rows; row++)
                for (var col = 0; col < m2.Columns; col++)
                    m[row, col] = Enumerable.Range(0, m1.Columns).Select(r => m1[row, r] * m2[r, col]).Sum();

            return m;
        }

        public static Matrix MultiplyParallel(Matrix m1, Matrix m2)
        {
            var m = new Matrix(m1.Rows, m2.Columns);

            Parallel.For(0, m1.Rows, row => Parallel.For(0, m2.Columns, col =>
            {
                var sum = 0;
                Parallel.For(0, m1.Columns, r => sum += m1[row, r] * m2[r, col]);
                m[row, col] = sum;
            }));

            return m;
        }

        public static Matrix operator *(Matrix m1, Matrix m2) => MultiplySequental(m1, m2);

        public static bool operator ==(Matrix m1, Matrix m2)
        {
            if (m1 is null && m2 is null) return true;
            if (m1 is null || m2 is null) return false;

            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns)
                return false;

            for (var row = 0; row < m1.Rows; row++)
                for (var col = 0; col < m1.Columns; col++)
                    if (m1[row, col] != m2[row, col])
                        return false;

            return true;
        }

        public static bool operator !=(Matrix m1, Matrix m2) => !(m1 == m2);

        public static Matrix FromArray(int rowCount, int columnCount, params int[] values)
        {
            if (rowCount * columnCount != values.Length)
                throw new ArgumentException("Количество элементов не совпадает с размерностью матрицы");

            var m = new Matrix(rowCount, columnCount);
            Parallel.For(0, values.Length, i => m[i / columnCount, i % columnCount] = values[i]);
            return m;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(Rows * Columns * 6);

            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                    sb.AppendFormat("{0,-6} ", _matrix[row, col]);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

