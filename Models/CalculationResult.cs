namespace SpecialMathExplorer.Models;

// General result for transforms and calculations
public record CalculationResult(
    string Name,
    string Input,
    string Formula,
    string Result,
    string PolesOrRoc,
    string Stability,
    string Note
);