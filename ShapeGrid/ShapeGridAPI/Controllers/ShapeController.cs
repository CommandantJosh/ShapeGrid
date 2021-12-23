using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShapeGridLibrary;

namespace ShapeGridAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShapeController : ControllerBase
    {
        private readonly ILogger<ShapeController> _logger;

        public ShapeController(ILogger<ShapeController> logger)
        {
            _logger = logger;
        }
        [HttpGet("{shapeName}/coordinates/{height}/{width}/{row}/{column}")]
        public IActionResult Get(string shapeName, int height, int width, string row, int column)
        {

            ShapeType shapeType;

            if (!Enum.TryParse(shapeName, true, out shapeType))
            {
                return BadRequest(new { message = "Product not found" });
            }
            ShapeHandler shape = new ShapeHandler(shapeType, height, width);

            return Ok(new ShapeResponse() { Coordinates = shape.GetShapeCoordinates(row, column) });

        }

        [HttpGet("{shapeName}/location/{height}/{width}/{coordinates}")]
        public IActionResult Get(string shapeName, int height, int width, string coordinates)
        {
            string[] coordinateArray = coordinates.Split(',');

            List<int[]> vertexCoordinates = new List<int[]>();

            for (int vertex = 0; vertex < coordinateArray.Length; vertex += 2)
            {
                if (!int.TryParse(coordinateArray[vertex], out int xValue))
                {
                    return BadRequest(new { message = "Invalid Vertex Coordinate" });
                }
                if (!int.TryParse(coordinateArray[vertex + 1], out int yValue))
                {
                    return BadRequest(new { message = "Invalid Vertex Coordinate" });
                }

                vertexCoordinates.Add(new int[] { xValue, yValue });
            }

            if (!Enum.TryParse(shapeName, true, out ShapeType shapeType))
            {
                return BadRequest(new { message = "Product not found" });
            }

            ShapeHandler shape = new ShapeHandler(shapeType, height, width);


            return Ok(new ShapeResponse() { Location = shape.GetShapeLocation(vertexCoordinates.ToArray()) });

            
        }
    }
}