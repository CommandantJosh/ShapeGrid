namespace ShapeGridLibrary
{
    public class ShapeHandler
    {
        private readonly Shape _shape;

        public ShapeHandler(ShapeType shapeType, int height, int width)
        {
            IShapeFactory shapeFactory = new ShapeFactory(shapeType, height, width);
            _shape = new Shape(shapeFactory);
        }

        public string[] GetShapeLocation(int[][] coordinates)
        {
            return _shape.GetLocationFromCoordinates(coordinates);
        }

        public int[][] GetShapeCoordinates(string row, int column)
        {
            int rowNumericalValue = GetCharInt(row);
            return _shape.GetCoordinatesFromLocation(rowNumericalValue, column);
        }
        
        private int GetCharInt(string row)
        {
            char[] chars = row.ToUpper().ToCharArray();
            
            return chars[0] - 64;
        }
    }
}
