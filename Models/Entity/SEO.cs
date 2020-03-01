﻿namespace Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEO")]
    public partial class SEO
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string SeoKeyWord { get; set; }

        [StringLength(500)]
        public string SeoDescription { get; set; }
    }
}