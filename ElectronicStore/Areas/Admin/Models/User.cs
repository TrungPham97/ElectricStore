namespace ElectronicStore.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string taiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        public string matKhau { get; set; }
    }
}
