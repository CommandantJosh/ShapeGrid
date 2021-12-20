namespace ShapeGridLibrary
{
    public interface IShape
    {
        public int GetHeight();
        public int GetWidth();
        public int GetNumberOfSides();

        public string GetLocationFromCoordinates(int[][] vertexCoordinates);
        public int[][] GetCoordinatesFromLocation(int row, int column);
    }
}