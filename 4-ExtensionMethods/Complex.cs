namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real
        {
            get
            {
                return re;
            }
        }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary
        {
            get
            {
                return im;
            }
        }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus
        {
            get
            {
                return Math.Sqrt(im*im + re*re);
            }
        }

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase
        {
            get
            {
                return Math.Atan2(im, re);
            }
        }

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            // TODO improve
            return re +" + i" + im; 
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return re == other.Real ? im == other.Imaginary ? true : false : false;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            // TODO improve
            return Equals((IComplex)obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO improve
            return HashCode.Combine(re, im);
        }
    }
}
