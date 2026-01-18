namespace SpecialMathExplorer.Models;

// Specific result for Taylor, Laurent, and Fourier series
public record SeriesResult(
    string SeriesType,
    string GeneralTerm,
    string ExpansionTerms,
    string ConvergenceRegion
);