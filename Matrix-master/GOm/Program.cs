using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrDo;

namespace GOm
{
    class Program
    {
        static void Main(string[] args)
        {

            CoolMatrix matrix = new[,]
            {
                { 1, 2 }
            };
            var expectedSize = new Size(width: 3, height: 2);
            matrix.Transpose();
            Console.WriteLine(expectedSize);
            Console.WriteLine(matrix.Size);
            Console.ReadLine();
        }
    }
}
