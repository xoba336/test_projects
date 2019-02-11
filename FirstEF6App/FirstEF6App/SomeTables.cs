namespace FirstEF6App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SomeTables
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal? Count { get; set; }
    }
}
