using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SecureComputing.Entites
{
    class PublicKeys
    {
        [Required]
        public BigInteger Prime { get; set; }
        [Required]
        public BigInteger SecondKey { get;set; }
    }
}
