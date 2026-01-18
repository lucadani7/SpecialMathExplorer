namespace SpecialMathExplorer.Models;

public record InverseResult(
    string ImageS,          // F(s)
    string PolesFound,      // s1, s2, ...
    string ResidueSteps,    // Step-by-step residue calculations
    string OriginalTime,    // f(t)
    string TheoryReference 
);