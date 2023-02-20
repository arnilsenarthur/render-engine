using Engine;

//Canvas
Canvas canvas = new Canvas(200, 200);
canvas.Fill(Color.White);

//Brushes
IBrush contour = new SolidBrush(Color.Black);
IBrush fill = new SolidBrush(Color.Yellow);
IBrush outFill = new ChequeredBrush(Color.Red, Color.Green, 10);

//Polygons
Polygon rect = new Polygon(
    new Vector2i(50, 50),
    new Vector2i(150, 50),
    new Vector2i(150, 150),
    new Vector2i(50, 150)
);

Polygon outside = Polygon.FromRegularPolygon(100, 100, 6, 80);

//Draw
canvas.Fill(outside, outFill);
canvas.Fill(rect, fill);
canvas.Draw(rect, contour);
canvas.Draw(outside, contour);

//Triforce
Triangle triangle = new Triangle(
    new Vector2i(50, 150),
    new Vector2i(150, 150),
    new Vector2i(100, 50));

canvas.Draw(triangle, contour);

canvas.Draw(new Triangle(
    new Vector2i(75, 100),
    new Vector2i(125, 100),
    new Vector2i(100, 150)), contour);

canvas.Save("output/1.png");
