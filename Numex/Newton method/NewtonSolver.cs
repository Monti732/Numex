using System.Windows;
using Numex.Utilities.Base;
using Numex.Utilities.Services;

namespace Numex.Newton_method;

 public class NewtonSolver(double x0, double epsilon, double h, string formula) : Solver(epsilon, formula) {
   public async override Task<string> Solve() {
     if (!InputValidator.IsValidFormula(x0, Formula, Context)) {
       MessageBox.Show("Неверное значение уравнения");
       return "";
     }

     var x = x0;
     var maxIter = 1/Epsilon;
     var nextX = 0d;
     
     for (int i = 0; i < maxIter; i++) {
       var fx =  Evaluate(x);
       var dfx = (Evaluate(x + h) - Evaluate(x - h)) / (2 * h);

       nextX = x - fx / dfx;
       
       x = nextX;
     }

     if (nextX is double.NaN) return "Корней нет";
     
     return nextX.ToString();
   }
}