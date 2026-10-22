// C# extension: a 3D height field z = f(x, y) moves vertically through the
// z = 0 plane. The 2D canvas shows exactly the part of the 3D surface that
// crosses the 2D plane: the intersection curves f(x, y) = 0. When the whole
// surface is above or below the plane, the 2D trace disappears.
// Settings are rendered in the application's "C# РАСШИРЕНИЯ" panel.

double amplitude = ctx.Settings.Number("amplitude", 1.7, "Амплитуда 3D-функции", 0.1, 4.0, 0.05, "%.2f");
double frequency = ctx.Settings.Number("frequency", 1.8, "Частота", 0.1, 5.0, 0.05, "%.2f");
double speed = ctx.Settings.Number("speed", 0.9, "Скорость прохода", 0.05, 3.0, 0.05, "%.2f");

// Vertical translation of the surface: it passes through z = 0 and leaves it.
double offset = amplitude * 1.55 * Math.Sin(ctx.Time * speed - 1.0);

double Surface(double x, double y)
{
    double r = Math.Sqrt(x * x + y * y);
    return amplitude * Math.Exp(-0.035 * r * r) * Math.Cos(frequency * r) + offset;
}

// The 3D function itself (visible in the 3D view).
ctx.Scene.Surface3D("3D-функция z = f(x, y)", Surface, resolution: 112,
                    color: "#B35FD0FF", opacity: 0.62f);

// Intersection of the surface with the plane z = 0. The field is F = f(x, y) - z;
// marching squares turns F = 0 into the curves shown on the 2D canvas.
ctx.Scene.SliceImplicit3D("След 3D-функции на 2D-полотне",
                          (x, y, z) => Surface(x, y) - z, 0.0,
                          ctx.DomainX0, ctx.DomainX1, ctx.DomainY0, ctx.DomainY1,
                          190, "#FFFF5FA2", 3.0f, showIn3D: false);

bool visible = Math.Abs(offset) < amplitude;
string state = visible ? "поверхность пересекает полотно" : "поверхность вне полотна";
ctx.Scene.Label2D($"3D-функция → сечение z = 0   сдвиг = {offset:F2}   {state}",
                  ctx.XMin + 0.35, ctx.YMax - 0.5, "#FFFF8E6B");
