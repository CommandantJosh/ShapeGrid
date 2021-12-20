namespace ShapeGridLibrary
{
    public class Triangle : IShape
    {
        private readonly int _height;
        private readonly int _width;
        private readonly int _numberOfSides;

        private readonly int _xValue = 0;
        private readonly int _yValue = 1;

        public Triangle(int height, int width)
        {
            _height = height;
            _width = width;
            _numberOfSides = 3;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;    
        }

        public int GetNumberOfSides()
        {
            return _numberOfSides;
        }

        public int[][] GetCoordinatesFromLocation(int row, int column)
        {
            bool invertedTriangle = (column % 2).Equals(0);

            int[][] coordinates = new int[_numberOfSides][];

            if (invertedTriangle)
            {
                for(int vertex = 0; vertex < _numberOfSides; vertex++)
                {
                    coordinates[vertex] = GetVertexValue(row - 1, column, vertex, invertedTriangle);
                }
            }
            else
            {
                for (int vertex = 0; vertex < _numberOfSides; vertex++)
                {
                    coordinates[vertex] = GetVertexValue(row, column - 1, vertex, invertedTriangle);
                }
            }

            return coordinates;
        }

        public string GetLocationFromCoordinates(int[][] vertexCoordinates)
        {
            int[] vertex1 = vertexCoordinates[0];
            int[] vertex2 = vertexCoordinates[1];
            int[] vertex3 = vertexCoordinates[2];

            int row;
            int column;

            if (vertex1[_xValue].Equals(vertex2[_xValue]))
            {
                column = ((vertex3[_xValue] / _width) * 2) -1;
                row = vertex3[_yValue] / _height;
            }
            else if (vertex1[_yValue].Equals(vertex2[_yValue]))
            {
                column = (vertex3[_xValue] / _width) * 2;
                row = vertex3[_yValue] / _height;
            }
            else
            {
                throw new InvalidDataException("Invalid vertex Coordinates for a triangle");
            }

            char rowIdentifier = (char)(((row % 26) - 1) + 65);
            return $"{rowIdentifier}{column}";
        }

        public int[] GetVertexValue(int row, int column, int vertex, bool invertedTriangle)
        {
            int x;
            int y;

            if (vertex.Equals(0))
            {
                x = (column.Equals(0)) ? 0 : ((column * _width) / 2);
                y = row * _height;
            }
            else if (vertex.Equals(1))
            {
                x = (column.Equals(0)) ? 0 : ((column * _width) / 2);
                y = (row * _height);

                if (invertedTriangle)
                {
                    x -= _width;
                }
                else
                {
                    y -= _height;
                }
            }
            else
            {
                x = (column.Equals(0)) ? 0 : ((column * _width) / 2);
                y = row * _height;

                if (invertedTriangle)
                {
                    y += _height;
                }
                else
                {
                    x += _width;
                }
            }
            return new int[] { x, y };
        }
    }
}
