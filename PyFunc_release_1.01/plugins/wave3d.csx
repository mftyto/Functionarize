// C# extension: animated 3D height field built by the SceneBuilder helper.

double t = ctx.Time;

ctx.Scene.Surface3D(
    "C# волна",
    (x, y) => Math.Sin(Math.Sqrt(x * x + y * y) * 1.9 - t * 1.8)
              * Math.Exp(-0.055 * (x * x + y * y)) * 1.7,
    resolution: 80,
    color: "#FFFF5FA2",
    opacity: 0.88f);

ctx.Log($"wave3d: t = {t:F2}");
