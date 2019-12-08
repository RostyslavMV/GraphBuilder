package Calc
{
    class Evaluator {
        public function Eval(expr: String): double {
            return eval(expr, "unsafe");
        }
        public function EvalFunc(expr: String, arg: double): double {
            return eval("var x=" + arg + ";" + expr, "unsafe");
        }
    }
}

// To compile:
// jsc /target:library Calc.js