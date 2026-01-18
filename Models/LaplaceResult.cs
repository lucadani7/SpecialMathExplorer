namespace SpecialMathExplorer.Models;

public record LaplaceResult(
    string SignalName,
    string TimeDomain,      // f(t)
    string SpectralDomain,  // F(s)
    string Poles,
    string Stability,
    string Description
);