using System;
using SpecialMathExplorer.Models;

namespace SpecialMathExplorer.Engine;

public class LaplaceEngine {
    public LaplaceResult GetTransform(string input) => input.ToLower().Trim() switch {
        // Unit Step / Heaviside
        "unit" or "1" or "step" => new LaplaceResult(
            "Unit Step",
            "f(t) = 1",
            "F(s) = 1 / s",
            "s = 0",
            "Marginally Stable",
            "The basic Heaviside step function. Integral converges for Re(s) > 0."
        ),

        // Polynomial
        "poly" or "t^n" => new LaplaceResult(
            "Polynomial",
            "f(t) = t^n",
            "F(s) = n! / s^(n+1)",
            "s = 0 (multiple pole)",
            "Unstable",
            "Power functions grow over time. Results in a multiple pole at the origin."
        ),

        // Exponential
        "exp" or "e^at" => new LaplaceResult(
            "Exponential",
            "f(t) = e^(at)",
            "F(s) = 1 / (s - a)",
            "s = a",
            "Stable if a < 0",
            "The core of linear system analysis. Stability depends on the sign of 'a'."
        ),

        // Sinusoidal
        "sin" or "sin(wt)" => new LaplaceResult(
            "Sine",
            "f(t) = sin(wt)",
            "F(s) = w / (s^2 + w^2)",
            "s = ±jw",
            "Marginally Stable (Oscillatory)",
            "Pure oscillation. Poles are on the imaginary axis."
        ),

        "cos" or "cos(wt)" => new LaplaceResult(
            "Cosine",
            "f(t) = cos(wt)",
            "F(s) = s / (s^2 + w^2)",
            "s = ±jw",
            "Marginally Stable (Oscillatory)",
            "Starts at 1 at t=0. Spectral representation includes a zero at s=0."
        ),

        // Hyperbolic
        "sinh" or "sh(at)" => new LaplaceResult(
            "Hyperbolic Sine",
            "f(t) = sinh(at)",
            "F(s) = a / (s^2 - a^2)",
            "s = ±a",
            "Unstable",
            "Represented as (e^at - e^-at)/2. Poles at +a and -a."
        ),

        "cosh" or "ch(at)" => new LaplaceResult(
            "Hyperbolic Cosine",
            "f(t) = cosh(at)",
            "F(s) = s / (s^2 - a^2)",
            "s = ±a",
            "Unstable",
            "Poles are real. One pole always has a positive real part (a)."
        ),

        _ => throw new ArgumentException($"Signal '{input}' not found in the Laplace database.")
    };
}