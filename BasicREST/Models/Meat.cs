using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicREST.Models
{
    public enum SourceAnimal
    {
        [Description("Pork")]
        Pig = 0,

        [Description("Beef")]
        Cow = 1,

        [Description("Poultry")]
        Chicken = 2
    }
    public class Meat
    {
        /// <summary>
        /// Weird, its not configured as PK or unique value, yet still it's uniqunes is handled somewhere
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Problematic
        /// TODO: In DB should be int, input (from API) should accept int or string, output should be string
        /// </summary>
        [Required]
        [EnumDataType(typeof(SourceAnimal))]
        public SourceAnimal SourceAnimal { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+.*$")]
        public string NameOfCut { get; set; }

        [Required]
        public uint Mass { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 100)]
        public string Notes { get; set; }
    }
}
