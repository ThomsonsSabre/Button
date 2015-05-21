using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SabreSwitch.Models
{
    public class ButtonClick
    {
        [Key]
        public string UID { get; set; }
        public DateTime ClickDateTime { get; set; }
    }

    public class ButtonClickContext : DbContext
    {
        public DbSet<ButtonClick> Clicks { get; set; }
    }
}