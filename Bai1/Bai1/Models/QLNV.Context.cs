﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bai1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLNVEntities : DbContext
    {
        public QLNVEntities()
            : base("name=QLNVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tb_ChucVu> tb_ChucVu { get; set; }
        public virtual DbSet<tb_HopDong> tb_HopDong { get; set; }
        public virtual DbSet<tb_NhanVien> tb_NhanVien { get; set; }
        public virtual DbSet<tb_PhongBan> tb_PhongBan { get; set; }
    }
}