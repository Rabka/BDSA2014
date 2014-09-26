namespace Assignment38_ReversePolishCalculator
{
    public interface IOperation
    {
        double Execute(double arg1, params double[] argn);
    }
}
