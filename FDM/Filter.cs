namespace FDM
{
     /// First order, (low pass / lag) filter
    public class Filter 
    {
        double prev_in;
        double prev_out;
        double ca;
        double cb;
        Filter() {}
        Filter(double coeff, double dt) 
        {
            prev_in = prev_out = 0.0;
            double denom = 2.0 + coeff*dt;
            ca = coeff*dt/denom;
            cb = (2.0 - coeff*dt)/denom;
        }

        public double Execute(double input) 
        {
            double output = (input + prev_in)*ca + prev_out*cb;
            prev_in = input;
            prev_out = output;
            return output;
        }
  };
}