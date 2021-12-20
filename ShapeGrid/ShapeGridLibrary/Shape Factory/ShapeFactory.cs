namespace ShapeGridLibrary
{
    public enum ShapeType
    {
        Triangle
    }

    public class ShapeFactory : IShapeFactory
    {
        private readonly int _height;
        private readonly int _width;
        private readonly ShapeType _shapeType;

        public ShapeFactory(ShapeType shapeType, int height, int width)
        {
            _shapeType = shapeType;
            _height = height;
            _width = width;
        }

        public IShape CreateShape()
        {
            return _shapeType switch
            {
                ShapeType.Triangle => new Triangle(_height, _width),
                _ => throw new InvalidDataException($"Shape Type {_shapeType} Not valid"),
            };
        }
    }
}
