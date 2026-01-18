# SpecialMath Explorer
SpecialMath Explorer is a cross-platform desktop application designed to solve complex engineering mathematics problems. It provides an intuitive interface for working with Operational Calculus, Complex Analysis, and Partial Differential Equations (PDEs).

Built with .NET 9 and Avalonia UI, this tool is fully portable and runs on Windows, macOS, and Linux.

---

## Tech Stack
- Language: .NET 9
- Framework: Avalonia UI
- IDE: JetBrains Rider
- Logic: Custom Mathematical Operational Engines

---

## Key Features
1. Operational Calculus (Laplace Transforms)
  - Comprehensive Library: Includes all 12 fundamental Laplace transforms from the official course tables.
  - Stability Analysis: Instantly identifies system stability based on pole locations (Stable, Unstable, or Oscillatory).
  - Advanced Forms: Supports damped signals ($e^{at} \sin \omega t$), power-multiplied functions ($t^n e^{at}$), and hyperbolic functions.
2. Complex Analysis (Residues)
  - Residue Calculator: Provides the mathematical limit formulas for poles of any order ($n$).
  - Singularity Identification: Helps in identifying isolated singular points and preparing for inverse Laplace calculations.
3. PDE Canonical Forms
  - Automatic Classification: Input coefficients ($a_{11}, a_{12}, a_{22}$) to classify equations as Hyperbolic, Parabolic, or Elliptic.
  - Transformation Logic: Displays the characteristic equations and the required coordinate transformations ($\alpha, \beta$) to reach the canonical form.

---

## How to Run (for non-developers)
The application is portable and does not require an installer or a pre-installed .NET framework:
1. Download the .zip archive for your operating system from the Releases section.
2. Extract the archive completely (do not run from inside the zip).

macOS users (Silicon & Intel)
- First Run: Right-click the SpecialMathExplorer executable and select Open. Click Open again in the security dialog.
- Troubleshooting: If the app is blocked, run this command in your terminal: xattr -cr SpecialMathExplorer

Windows users
- Run `SpecialMathExplorer.exe`
- If Windows SmartScreen appears, click "More info" and then "Run anyway".

Linux users
- Give execution permissions:
  ```bash
  chmod +x SpecialMathExplorer
  ```
- Run:
  ```bash
  ./SpecialMathExplorer
  ```
---

## Building from source (for developers)
If you wish to modify the code or build the binaries yourself, follow these steps:
1. Make sure you have .NET 9 SDK (or newer) installed locally. If you don't have it, you can install from here: https://dotnet.microsoft.com/en-us/download/dotnet/9.0
2. Windows users need Git Bash (if you have Git installed locally, you already have Git Bash. We recommend using it to run the build script, as it provides the necessary environment to execute .sh files and zip commands seamlessly.).
3. Linux / macOS users need a terminal supporting Bash.
4. Open your terminal in the project root.
5. Run the script:
   ```bash
   chmod +x build_all.sh
   ./build_all.sh
   ```
---

## License
This project is licensed under the Apache-2.0 License.
