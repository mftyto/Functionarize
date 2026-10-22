// C# extension: animated Lissajous curve drawn on the 2D canvas.
// The script is recompiled on F5 and re-executed on every visual frame.

var points = new List<(double X, double Y)>();
const int samples = 1600;

for (int i = 0; i <= samples; i++)
{
    double t = i / (double)samples * Math.PI * 2.0;
    double x = Math.Sin(3.0 * t + 0.4);
    double y = Math.Sin(4.0 * t + ctx.Time * 0.3);
    points.Add((x * 4.1, y * 4.1));
}

ctx.Scene.Polyline2D("C# Лиссажу", points, "#FF52F2B3", 2.6f);
ctx.Scene.Label2D("C# plugin: lissajous.csx", ctx.XMin + 0.35, ctx.YMax - 0.5, "#FF52F2B3");
