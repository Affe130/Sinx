using Raylib_cs;
using Desmos;

List<Circle> circles = new();

float displacement = 0;

float speed = 10f;
float scale = 0.01f;

float deltaTime;
int windowHeight = 1000;
int windowWidth = 2000;

Raylib.InitWindow(windowWidth, windowHeight, "Desmos");

while (!Raylib.WindowShouldClose())
{
    for (int x = 0; x <= windowWidth; x++)
    {
        double y = 100 * Math.Cos(x * scale + displacement);

        circles.Add(new Circle()
        {
            X = x,
            Y = (int)(y * -1 + windowHeight / 2),
            Radius = 2f,
            Color = Color.GREEN
        });
    }

    circles.Add(new Circle()
    {
        X = windowWidth / 2,
        Y = (int)((100 * Math.Cos(windowWidth / 2 * scale + displacement)) * -1 + windowHeight / 2),
        Radius = 10f,
        Color = Color.GREEN
    });

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLACK);

    Raylib.DrawLine(0, windowHeight / 2, windowWidth, windowHeight / 2, Color.GRAY);

    int renders = 0;
    foreach (Circle circle in circles)
    {
        Raylib.DrawCircle(circle.X, circle.Y, circle.Radius, circle.Color);
        renders++;
    }
    circles.Clear();

    double high = (Math.Cos(windowWidth / 2 * scale + displacement));

    Raylib.DrawText(Raylib.GetFPS().ToString(), 10, 10, 20, Color.GREEN);
    Raylib.DrawText(string.Format("x = {0:0.000}", windowWidth / 2 * scale + displacement), 10, 40, 20, Color.GREEN);
    Raylib.DrawText(string.Format("y = {0:0.000}", high), 10, 70, 20, Color.GREEN);
    Raylib.DrawText(string.Format("renders = {0}", renders), 10, 100, 20, Color.GREEN);
    renders = 0;

    Raylib.EndDrawing();

    deltaTime = Raylib.GetFrameTime();
    displacement += speed * deltaTime;

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_D))
    {
        speed += 1f;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_A))
    {
        speed -= 1f;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_W))
    {
        scale += 0.001f;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.KEY_S))
    {
        scale -= 0.001f;
    }
}

Raylib.CloseWindow();