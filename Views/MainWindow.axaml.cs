using Avalonia.Controls;
using Avalonia.Interactivity;
using SpecialMathExplorer.Engine;

namespace SpecialMathExplorer.Views;

public partial class MainWindow : Window {
    // Initialize our Math Brains
    private readonly OperationalEngine _opEngine = new();
    private readonly ComplexEngine _complexEngine = new();
    private readonly PdeEngine _pdeEngine = new();
    
    public MainWindow() => InitializeComponent();

    public void OnCalculateTransform(object sender, RoutedEventArgs e) {
        try {
            var result = _opEngine.GetLaplaceTransform(TransformInput.Text ?? "unit");
            TransformResultText.Text = $"Result: {result.Formula}\nPoles: {result.PolesOrRoc}\nStability: {result.Stability}";
        } catch {
            TransformResultText.Text = "Error: Signal not found.";
        }
    }

    public void OnShowResidue(object sender, RoutedEventArgs e) {
        var order = (int)(PoleOrderInput.Value ?? 1);
        ResidueResultText.Text = _complexEngine.GetResidueFormula(order);
    }

    public void OnPdeAction(object sender, RoutedEventArgs e) {
        var a11 = double.Parse(A11.Text ?? "1");
        var a12 = double.Parse(A12.Text ?? "0");
        var a22 = double.Parse(A22.Text ?? "1");
        var reduction = _pdeEngine.ReduceToCanonical(a11, a12, a22);
        PdeResultText.Text = $"Type: {reduction.Type}\nRoots: {reduction.Alpha}, {reduction.Beta}\nCanonical Form: {reduction.FinalForm}";
    }
}