using System.ComponentModel.DataAnnotations;
using System.Numerics;


namespace SecureComputing.Entites
{
    class Keys
    {
        [Required]
        public BigInteger KeyOne { get; set; }
        [Required]
        public BigInteger KeyTwo { get; set; }
    }
}
