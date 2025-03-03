namespace BaseExamples.TestCaseSourceAttributeExamples.RectangleCalculation;

public class Rectangle
{
    public Rectangle(int x1,  int y1,int x2, int y2)
    {
        TopLeft = new Point { X = x1, Y = y1 };
        BottomRight = new Point { X = x2, Y = y2 };
    }
    public Point TopLeft;
    public Point BottomRight;
    
}