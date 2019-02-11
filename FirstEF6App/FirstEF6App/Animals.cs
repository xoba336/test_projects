namespace FirstEF6App
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Animals : IEnumerable
    {
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public bool? Indoor { get; set; }

        [StringLength(256)]
        public string Nickname { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
