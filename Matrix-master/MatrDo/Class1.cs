using System;
using System.Text;


namespace MatrDo
{
    public class CoolMatrix
    {
        private readonly int[,] arr;
        public Size Size { get; }
        public bool IsSquare => Size.IsSquare;

        public int this[int x, int y]
        {
            get
            { 
                return arr[x, y]; }
            set { arr[x, y] = value; }
        }
        public CoolMatrix(int[,] arr)
        {
            this.arr = arr;
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            this.Size = new Size(arr.GetLength(1),arr.GetLength(0));    
        }

        public static implicit operator CoolMatrix(int [,] arr)
        { 
            return new CoolMatrix(arr);
        }

        public static implicit operator int [,] (CoolMatrix d)  // implicit digit to byte conversion operator
        {
           // System.Console.WriteLine("conversion occurred");
            return (int[,])d.arr.Clone(); // implicit conversion
        }

        public override string ToString()
        {
            var stmatrix = new StringBuilder();
            for (int i = 0; i < Size.Wight; i++)
            {
                stmatrix.Append("[");
                for (int j = 0; j < Size.Height - 1; j++)
                {
                    stmatrix.Append(arr[i, j] + ", ");
                }
                stmatrix.Append(arr[i, Size.Height - 1] + "]");
                if (i != Size.Wight - 1)
                    stmatrix.Append(Environment.NewLine);
            }
            return stmatrix.ToString();
        }
        public override bool Equals(Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            if (!(obj is CoolMatrix))
                return false;

            CoolMatrix matx = (CoolMatrix)obj;

            return this.Equals(matx);
        }
        public static bool operator ==(CoolMatrix a, CoolMatrix b)
        {
            if ((object)a == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(CoolMatrix a, CoolMatrix b)
        {
            return !(a == b);
        }
        public bool Equals(CoolMatrix coolMatrix)
        {
            if ((object)coolMatrix == null)
            {
                return false;
            }

            if (ReferenceEquals(this, coolMatrix))
                return true;

            for (int i = 0; i < Size.Wight; i++)
            {
                for (int j = 0; j < Size.Height; j++)
                {
                    if (this[i, j] != coolMatrix[i, j])
                        return false;
                }
            }
            return true;
        }

        // Overloading '+' operator:
        public static CoolMatrix operator +(CoolMatrix one, CoolMatrix two)
        {
            CoolMatrix rez = new CoolMatrix(one.arr);
            if ((one.Size.Wight != two.Size.Wight) || (one.Size.Height != two.Size.Height))
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < one.Size.Height; i++)
                for (int j = 0; j < one.Size.Wight; j++)
                    rez[i, j] = one[i, j] + two[i, j];
            return rez;
        }
        public static CoolMatrix operator *(CoolMatrix a, int b)
        {
            int[,] result = new int[a.Size.Wight, a.Size.Height];
            for (int i = 0; i < a.Size.Wight; i++)
            {
                for (int j = 0; j < a.Size.Height; j++)
                {
                    result[i, j] = a[i, j] * b;
                }
            }
            return new CoolMatrix(result);
        }

        public CoolMatrix Transpose()
        {

            var matrix = new int[Size.Wight, Size.Height];

            for (var i = 0; i < Size.Height; i++)
            {
                for (var j = 0; j < Size.Wight; j++)
                {
                    matrix[j,i] = this[i, j];
                }
            }
            return new CoolMatrix(matrix);
        }


    }
    public struct Size
    {

        public int Wight;
        public int Height;
        public Size(int width, int height)
        {
            Wight = width;
            Height = height;
        }
        public bool IsSquare => Height == Wight;
        public static bool operator ==(Size a, Size b)
        {
            if ((object)a == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Size a, Size b)
        {
            return !(a == b);
        }
    }

}
