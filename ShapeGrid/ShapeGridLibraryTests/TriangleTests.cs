using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeGridLibrary;

namespace ShapeGridLibraryTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void GetLocationFromCoordinates_FirstTriangle_A1Returned()
        {
            int[] vertex1 = { 0, 10 };
            int[] vertex2 = { 0, 0 };
            int[] vertex3 = { 10, 10 };
            string expected = "A1";

            int[][] vertexCoordinates = { vertex1, vertex2, vertex3 };
            Triangle triangle = new Triangle(10, 10);

            string actual = triangle.GetLocationFromCoordinates(vertexCoordinates);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLocationFromCoordinates_SecondTriangle_A2Returned()
        {
            int[] vertex1 = { 10, 0 };
            int[] vertex2 = { 0, 0 };
            int[] vertex3 = { 10, 10 };
            string expected = "A2";

            int[][] vertexCoordinates = { vertex1, vertex2, vertex3 };
            Triangle triangle = new Triangle(10, 10);

            string actual = triangle.GetLocationFromCoordinates(vertexCoordinates);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLocationFromCoordinates_Row3Column7Triangle_C7Returned()
        {
            int[] vertex1 = { 30, 30 };
            int[] vertex2 = { 30, 20 };
            int[] vertex3 = { 40, 30 };
            string expected = "C7";

            int[][] vertexCoordinates = { vertex1, vertex2, vertex3 };
            Triangle triangle = new Triangle(10, 10);

            string actual = triangle.GetLocationFromCoordinates(vertexCoordinates);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetLocationFromCoordinates_RowEColumn12Triangle_E12Returned()
        {
            int[] vertex1 = { 60, 40 };
            int[] vertex2 = { 50, 40 };
            int[] vertex3 = { 60, 50 };
            string expected = "E12";

            int[][] vertexCoordinates = { vertex1, vertex2, vertex3 };
            Triangle triangle = new Triangle(10, 10);

            string actual = triangle.GetLocationFromCoordinates(vertexCoordinates);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCoordinatesFromLocation_RowEColumn12Triangle_CorrectedCooordinatesReturned()
        {
            int[] vertex1 = { 60, 40 };
            int[] vertex2 = { 50, 40 };
            int[] vertex3 = { 60, 50 };
            int[][] expected = new int[][] { vertex1 , vertex2, vertex3};
            

            Triangle triangle = new Triangle(10, 10);
            //location E12
            int[][] actual = triangle.GetCoordinatesFromLocation(5, 12);

            Assert.AreEqual(expected.Length, actual.Length);

            for (int vertex = 0; vertex < actual.Length; vertex++ )
            {
                Assert.AreEqual(expected[vertex][0], actual[vertex][0]);
                Assert.AreEqual(expected[vertex][1], actual[vertex][1]);
            }
        }
        [TestMethod]
        public void GetCoordinatesFromLocation_RowCColumn7Triangle_CorrectedCooordinatesReturned()
        {
            int[] vertex1 = { 30, 30 };
            int[] vertex2 = { 30, 20 };
            int[] vertex3 = { 40, 30 };
            int[][] expected = new int[][] { vertex1, vertex2, vertex3 };


            Triangle triangle = new Triangle(10, 10);
            //location C7
            int[][] actual = triangle.GetCoordinatesFromLocation(3, 7);

            Assert.AreEqual(expected.Length, actual.Length);

            for (int vertex = 0; vertex < actual.Length; vertex++)
            {
                Assert.AreEqual(expected[vertex][0], actual[vertex][0]);
                Assert.AreEqual(expected[vertex][1], actual[vertex][1]);
            }
        }
        [TestMethod]
        public void GetCoordinatesFromLocation_RowAColumn1Triangle_CorrectedCooordinatesReturned()
        {
            int[] vertex1 = { 0, 10 };
            int[] vertex2 = { 0, 0 };
            int[] vertex3 = { 10, 10 };
            int[][] expected = new int[][] { vertex1, vertex2, vertex3 };


            Triangle triangle = new Triangle(10, 10);
            //location A1
            int[][] actual = triangle.GetCoordinatesFromLocation(1, 1);

            Assert.AreEqual(expected.Length, actual.Length);

            for (int vertex = 0; vertex < actual.Length; vertex++)
            {
                Assert.AreEqual(expected[vertex][0], actual[vertex][0]);
                Assert.AreEqual(expected[vertex][1], actual[vertex][1]);
            }
        }
        [TestMethod]
        public void GetCoordinatesFromLocation_RowAColumn2Triangle_CorrectedCooordinatesReturned()
        {
            int[] vertex1 = { 10, 0 };
            int[] vertex2 = { 0, 0 };
            int[] vertex3 = { 10, 10 };
            int[][] expected = new int[][] { vertex1, vertex2, vertex3 };


            Triangle triangle = new Triangle(10, 10);
            //location A2
            int[][] actual = triangle.GetCoordinatesFromLocation(1, 2);

            Assert.AreEqual(expected.Length, actual.Length);

            for (int vertex = 0; vertex < actual.Length; vertex++)
            {
                Assert.AreEqual(expected[vertex][0], actual[vertex][0]);
                Assert.AreEqual(expected[vertex][1], actual[vertex][1]);
            }
        }

    }
}