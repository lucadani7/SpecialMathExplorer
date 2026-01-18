using System;
using SpecialMathExplorer.Models;

namespace SpecialMathExplorer.Engine;

public class ComplexEngine {
    public string GetResidueFormula(int n) {
        return n == 1 ? "Res(f, z0) = lim_{z->z0} (z-z0)f(z)" : $"Res(f, z0) = 1/({n}-1)! * lim_{{z->z0}} [ d^{n - 1}/dz^{n - 1} ((z-z0)^{n}f(z)) ]";
    }

    public SeriesResult GetTaylorExpansion(string function) {
        return function.ToLower() switch {
            "exp" => new SeriesResult("Taylor (e^z)", "z^n / n!", "1 + z + z^2/2 + ...", "Entire Plane"),
            "geo" => new SeriesResult("Geometric", "z^n", "1 + z + z^2 + ...", "|z| < 1"),
            _ => throw new ArgumentException("Series not supported.")
        };
    }
}