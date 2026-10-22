// C# extension: fully custom parametric torus as an indexed triangle mesh.

double major = 2.5 + 0.18 * Math.Sin(ctx.Time * 0.9);
double minor = 0.95;

ctx.Scene.ParametricSurface3D(
    "C# Тор",
    (u, v) =>
    {
        double r = major + minor * Math.Cos(v);
        return (r * Math.Cos(u), r * Math.Sin(u), minor * Math.Sin(v) * 1.6);
    },
    uSteps: 120,
    vSteps: 56,
    color: "#FF8E6BFF",
    opacity: 0.93f);

ctx.Scene.Label2D("C# plugin: torus.csx", ctx.XMin + 0.35, ctx.YMax - 0.5, "#FF8E6BFF");
