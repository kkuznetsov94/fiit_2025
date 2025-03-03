namespace BaseExamples.TestCaseSourceAttributeExamples.RectangleCalculation;

public static class RectangleCalculator
{
    public static int GetIntersectionSquare(Rectangle a, Rectangle b)
    {
        var x1 = Math.Max(a.TopLeft.X, b.TopLeft.X);
        var x2 = Math.Min(a.BottomRight.X, b.BottomRight.X);
        var y1 = Math.Max(a.TopLeft.Y, b.TopLeft.Y);
        var y2 = Math.Min(a.BottomRight.Y, b.BottomRight.Y);
        
        if (x1 >= x2 || y1 >= y2)
            return 0;
        
        var width = x2 - x1;
        var height = y2 - y1;
        return width * height;
    }
}