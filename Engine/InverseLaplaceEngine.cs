using System;
using SpecialMathExplorer.Models;

namespace SpecialMathExplorer.Engine;

public class InverseLaplaceEngine {
    public InverseResult ComputeByResidues(string functionKey) => functionKey.ToLower() switch {
        // Example from your Notes: F(s) = 1 / [s(s+1)(s-2)]
        "example_note5" => new InverseResult(
            "1 / [s(s+1)(s-2)]",
            "Simple poles at: s = 0, s = -1, s = 2",
            "Res(G, 0) = -1/2 | Res(G, -1) = 1/3 * e^-t | Res(G, 2) = 1/6 * e^2t",
            "f(t) = -1/2 + 1/3*e^-t + 1/6*e^2t",
            "Calculated using Mellin-Fourier: f(t) = Σ Res(F(s)*e^st, sk)"
        ),

        // Standard case: F(s) = 1 / (s - a)
        "simple_pole" => new InverseResult(
            "1 / (s - a)",
            "s = a",
            "Res( [1/(s-a)]*e^st, a ) = e^at",
            "f(t) = e^at",
            "Theory: Pole of order 1 at s=a results in an exponential original."
        ),

        _ => throw new ArgumentException("Inverse transform pattern not yet in database.")
    };
}