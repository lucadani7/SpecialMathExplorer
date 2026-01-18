using System;
using SpecialMathExplorer.Models;

namespace SpecialMathExplorer.Engine;

public class PdeEngine {
    public (PdeCategory Category, string Description) Classify(double a11, double a12, double a22) {
        var delta = a12 * a12 - a11 * a22;
        return delta switch {
            > 0 => (PdeCategory.Hyperbolic, "Wave Equation (Oscillations)"),
            0 => (PdeCategory.Parabolic, "Heat Equation (Diffusion)"),
            _ => (PdeCategory.Elliptic, "Laplace Equation (Equilibrium)")
        };
    }

    public CanonicalResult ReduceToCanonical(double a11, double a12, double a22) {
        var delta = a12 * a12 - a11 * a22;
        var charEq = $"{a11}(y')^2 - {2 * a12}y' + {a22} = 0";
        switch (delta) {
            case > 0: {
                var root1 = (a12 + Math.Sqrt(delta)) / a11;
                var root2 = (a12 - Math.Sqrt(delta)) / a11;
                return new CanonicalResult(
                    charEq,
                    $"α = y - ({root1})x",
                    $"β = y - ({root2})x",
                    "∂²u / ∂α∂β = 0",
                    "Two real characteristic families. Standard for Wave Equations."
                );
            }
            case 0: {
                var root = a12 / a11;
                return new CanonicalResult(
                    charEq,
                    $"α = y - ({root})x",
                    "β = x (Arbitrary choice)",
                    "∂²u / ∂β² = f(α, β, u, ...)",
                    "One family of characteristics. Standard for Heat Equations."
                );
            }
            default:
                return new CanonicalResult(
                    charEq,
                    "α = Re(y - ix)",
                    "β = Im(y - ix)",
                    "∂²u/∂α² + ∂²u/∂β² = 0",
                    "Complex conjugate characteristics. Standard for Laplace Equations."
                );
        }
    }
}