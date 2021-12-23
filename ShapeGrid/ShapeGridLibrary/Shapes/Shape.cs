namespace ShapeGridLibrary
{
    public class Shape : IShape
    {
        private readonly IShape _shape;

        public Shape(IShapeFactory shapeFactory)
        {
            _shape = shapeFactory.CreateShape();
        }

        public int[][] GetCoordinatesFromLocation(int row, int column)
        {
            return _shape.GetCoordinatesFromLocation(row, column);

        }

        public string[] GetLocationFromCoordinates(int[][] vertexCoordinates)
        {
            return _shape.GetLocationFromCoordinates(vertexCoordinates);
        }

        public int GetHeight()
        {
            return _shape.GetHeight();
        }

        public int GetNumberOfSides()
        {
            return _shape.GetNumberOfSides();
        }

        public int GetWidth()
        {
            return _shape.GetWidth();
        }
    }
}
