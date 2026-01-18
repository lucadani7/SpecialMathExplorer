using System;
using SpecialMathExplorer.Models;

namespace SpecialMathExplorer.Engine;

public class OperationalEngine {
    public CalculationResult GetLaplaceTransform(string key) => key.ToLower() switch {
        "1" or "unit" => new CalculationResult("Unit Step", "1", "1/s", "1/s", "s=0", "Marginally Stable", "Nr. 1 din tabel"),

        // 2. f(t) = t^n / n!
        "2" or "t^n/n!" => new CalculationResult("Power/Factorial", "t^n / n!", "1 / s^(n+1)", "1 / s^(n+1)", "s=0", "Unstable", "Nr. 2 din tabel"),

        // 3. f(t) = e^(lambda*t)
        "3" or "e^lt" or "exp" => new CalculationResult("Exponential", "e^(λt)", "1 / (s - λ)", "1 / (s - λ)", "s=λ", "Stable if λ < 0", "Nr. 3 din tabel"),

        // 4. f(t) = cos(wt)
        "4" or "cos" => new CalculationResult("Cosine", "cos(ωt)", "s / (s^2 + ω^2)", "s / (s^2 + ω^2)", "s=±jω", "Oscillatory", "Nr. 4 din tabel"),

        // 5. f(t) = sin(wt)
        "5" or "sin" => new CalculationResult("Sine", "sin(ωt)", "ω / (s^2 + ω^2)", "ω / (s^2 + ω^2)", "s=±jω", "Oscillatory", "Nr. 5 din tabel"),

        // 6. f(t) = cosh(wt)
        "6" or "cosh" or "ch" => new CalculationResult("Hyperbolic Cosine", "cosh(ωt)", "s / (s^2 - ω^2)", "s / (s^2 - ω^2)", "s=±ω", "Unstable", "Nr. 6 din tabel"),

        // 7. f(t) = sinh(wt)
        "7" or "sinh" or "sh" => new CalculationResult("Hyperbolic Sine", "sinh(ωt)", "ω / (s^2 - ω^2)", "ω / (s^2 - ω^2)", "s=±ω", "Unstable", "Nr. 7 din tabel"),

        // 8. f(t) = e^(at) * cos(wt)
        "8" or "e^at cos" => new CalculationResult("Damped Cosine", "e^(at)cos(ωt)", "(s-a) / ((s-a)^2 + ω^2)", "(s-a) / ((s-a)^2 + ω^2)", "s=a±jω", "Stable if a < 0", "Nr. 8 din tabel"),

        // 9. f(t) = e^(at) * sin(wt)
        "9" or "e^at sin" => new CalculationResult("Damped Sine", "e^(at)sin(ωt)", "a / ((s-a)^2 + ω^2)", "a / ((s-a)^2 + ω^2)", "s=a±jω", "Stable if a < 0", "Nr. 9 din tabel"),

        // 10. f(t) = (t^n / n!) * e^(at)
        "10" or "t^n/n! e^at" => new CalculationResult("Exponential Power", "(t^n/n!)e^(at)", "1 / (s-a)^(n+1)", "1 / (s-a)^(n+1)", "s=a", "Stable if a < 0", "Nr. 10 din tabel"),

        // 11. f(t) = t * cos(wt)
        "11" or "t cos" => new CalculationResult("T-Multiplied Cosine", "t*cos(ωt)", "(s^2-ω^2) / (s^2+ω^2)^2", "(s^2-ω^2) / (s^2+ω^2)^2", "s=±jω (double)", "Oscillatory", "Nr. 11 din tabel"),

        // 12. f(t) = t * sin(wt)
        "12" or "t sin" => new CalculationResult("T-Multiplied Sine", "t*sin(ωt)", "2sω / (s^2+ω^2)^2", "2sω / (s^2+ω^2)^2", "s=±jω (double)", "Oscillatory", "Nr. 12 din tabel"),
        _ => throw new ArgumentException("Unknown")
    };

    public CalculationResult GetZTransform(double a) => new CalculationResult("Z-Transform", $"{a}^n", "z/(z-a)", "z/(z-a)", $"|z| > {a}", a < 1 ? "Stable" : "Unstable", "Discrete geometric series.");
}