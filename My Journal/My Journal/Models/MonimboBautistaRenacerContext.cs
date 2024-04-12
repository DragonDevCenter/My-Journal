using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace My_Journal.Models;

public partial class MonimboBautistaRenacerContext : DbContext
{
    public MonimboBautistaRenacerContext()
    {
    }

    public MonimboBautistaRenacerContext(DbContextOptions<MonimboBautistaRenacerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaOfrenda> CategoriaOfrendas { get; set; }

    public virtual DbSet<CategoriaPago> CategoriaPagos { get; set; }

    public virtual DbSet<DetOfrendaCategorium> DetOfrendaCategoria { get; set; }

    public virtual DbSet<DetPagocategorium> DetPagocategoria { get; set; }

    public virtual DbSet<DetUsuarioPermiso> DetUsuarioPermisos { get; set; }

    public virtual DbSet<Diezmo> Diezmos { get; set; }

    public virtual DbSet<EgresosVario> EgresosVarios { get; set; }

    public virtual DbSet<IngresosVario> IngresosVarios { get; set; }

    public virtual DbSet<Ofrenda> Ofrendas { get; set; }

    public virtual DbSet<OfrendaPastoral> OfrendaPastorals { get; set; }

    public virtual DbSet<PagosBasico> PagosBasicos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Total> Totals { get; set; }

    public virtual DbSet<TotalEgreso> TotalEgresos { get; set; }

    public virtual DbSet<TotalIngreso> TotalIngresos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("server=localhost; database=Monimbo_Bautista_Renacer;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true;");

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaOfrenda>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CB887ED4D");

            entity.ToTable("Categoria_ofrendas");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<CategoriaPago>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C270FB3CE");

            entity.ToTable("Categoria_pagos");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<DetOfrendaCategorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Det_ofrendaCategoria");

            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdOfrendas).HasColumnName("Id_Ofrendas");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany()
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Det_ofren__Id_Ca__46E78A0C");

            entity.HasOne(d => d.IdOfrendasNavigation).WithMany()
                .HasForeignKey(d => d.IdOfrendas)
                .HasConstraintName("FK__Det_ofren__Id_Of__47DBAE45");
        });

        modelBuilder.Entity<DetPagocategorium>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Det_pagocategoria");

            entity.Property(e => e.IdCategoria).HasColumnName("Id_categoria");
            entity.Property(e => e.IdPago).HasColumnName("Id_pago");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany()
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Det_pagoc__Id_ca__48CFD27E");

            entity.HasOne(d => d.IdPagoNavigation).WithMany()
                .HasForeignKey(d => d.IdPago)
                .HasConstraintName("FK__Det_pagoc__Id_pa__49C3F6B7");
        });

        modelBuilder.Entity<DetUsuarioPermiso>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Det_usuarioPermiso");

            entity.Property(e => e.IdPermiso).HasColumnName("ID_Permiso");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany()
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Det_usuar__ID_Pe__4AB81AF0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany()
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Det_usuar__ID_Us__4BAC3F29");
        });

        modelBuilder.Entity<Diezmo>(entity =>
        {
            entity.HasKey(e => e.IdDiezmo).HasName("PK__Diezmos__F62CFCFF57D3332E");

            entity.Property(e => e.IdDiezmo).HasColumnName("Id_diezmo");
            entity.Property(e => e.FechaDiezmo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_diezmo");
            entity.Property(e => e.NombrePersonaDiezmo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Persona_diezmo");
        });

        modelBuilder.Entity<EgresosVario>(entity =>
        {
            entity.HasKey(e => e.IdEgresosvarios).HasName("PK__egresos___38C2DF46D635D904");

            entity.ToTable("egresos_varios");

            entity.Property(e => e.IdEgresosvarios).HasColumnName("Id_egresosvarios");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaEgreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_egreso");
        });

        modelBuilder.Entity<IngresosVario>(entity =>
        {
            entity.HasKey(e => e.IdVarios).HasName("PK__ingresos__83F474481FA2022C");

            entity.ToTable("ingresos_Varios");

            entity.Property(e => e.IdVarios).HasColumnName("Id_varios");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaVarios)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_varios");
        });

        modelBuilder.Entity<Ofrenda>(entity =>
        {
            entity.HasKey(e => e.IdOfrendas).HasName("PK__ofrendas__95AA381A644F8EB5");

            entity.ToTable("ofrendas");

            entity.Property(e => e.IdOfrendas).HasColumnName("Id_ofrendas");
            entity.Property(e => e.FechaOfrenda)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Fecha_ofrenda");
        });

        modelBuilder.Entity<OfrendaPastoral>(entity =>
        {
            entity.HasKey(e => e.IdOfrendaPastoral).HasName("PK__ofrenda___C90F1F2208ABD6CB");

            entity.ToTable("ofrenda_pastoral");

            entity.Property(e => e.IdOfrendaPastoral).HasColumnName("id_ofrenda_pastoral");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaOfrendaPastoral)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_ofrenda_pastoral");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PagosBasico>(entity =>
        {
            entity.HasKey(e => e.IdPagos).HasName("PK__pagos_ba__58B89D679961A449");

            entity.ToTable("pagos_basicos");

            entity.Property(e => e.IdPagos).HasColumnName("Id_pagos");
            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_pago");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permisos__A5D405E803D9E9FE");

            entity.Property(e => e.IdPermiso).HasColumnName("Id_permiso");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.NombrePermiso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nombre_permiso");
        });

        modelBuilder.Entity<Total>(entity =>
        {
            entity.HasKey(e => e.IdTotal).HasName("PK__Total__41073A4E95235193");

            entity.ToTable("Total");

            entity.Property(e => e.IdTotal).HasColumnName("Id_Total");
            entity.Property(e => e.IdTotalEgresos).HasColumnName("IdTotal_egresos");
            entity.Property(e => e.IdTotalIngresos).HasColumnName("IdTotal_ingresos");
            entity.Property(e => e.MesTotal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mes_total");
            entity.Property(e => e.Total1).HasColumnName("Total");

            entity.HasOne(d => d.IdTotalEgresosNavigation).WithMany(p => p.Totals)
                .HasForeignKey(d => d.IdTotalEgresos)
                .HasConstraintName("FK__Total__IdTotal_e__4CA06362");

            entity.HasOne(d => d.IdTotalIngresosNavigation).WithMany(p => p.Totals)
                .HasForeignKey(d => d.IdTotalIngresos)
                .HasConstraintName("FK__Total__IdTotal_i__4D94879B");
        });

        modelBuilder.Entity<TotalEgreso>(entity =>
        {
            entity.HasKey(e => e.IdTotalEgresos).HasName("PK__Total_Eg__D4C6107872CEDD5E");

            entity.ToTable("Total_Egresos");

            entity.Property(e => e.IdTotalEgresos).HasColumnName("IdTotal_egresos");
            entity.Property(e => e.IdEgresosvarios).HasColumnName("Id_egresosvarios");
            entity.Property(e => e.IdOfrendaPastoral).HasColumnName("Id_ofrenda_pastoral");
            entity.Property(e => e.IdPagos).HasColumnName("Id_pagos");
            entity.Property(e => e.MesEgreso)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mes_egreso");
            entity.Property(e => e.TotalEgreso1).HasColumnName("total_egreso");

            entity.HasOne(d => d.IdEgresosvariosNavigation).WithMany(p => p.TotalEgresos)
                .HasForeignKey(d => d.IdEgresosvarios)
                .HasConstraintName("FK__Total_Egr__Id_eg__4E88ABD4");

            entity.HasOne(d => d.IdOfrendaPastoralNavigation).WithMany(p => p.TotalEgresos)
                .HasForeignKey(d => d.IdOfrendaPastoral)
                .HasConstraintName("FK__Total_Egr__Id_of__4F7CD00D");

            entity.HasOne(d => d.IdPagosNavigation).WithMany(p => p.TotalEgresos)
                .HasForeignKey(d => d.IdPagos)
                .HasConstraintName("FK__Total_Egr__Id_pa__5070F446");
        });

        modelBuilder.Entity<TotalIngreso>(entity =>
        {
            entity.HasKey(e => e.IdTotalIngresos).HasName("PK__Total_in__9D7AA9C206BB4659");

            entity.ToTable("Total_ingresos");

            entity.Property(e => e.IdTotalIngresos).HasColumnName("Id_Total_ingresos");
            entity.Property(e => e.IdDiezmo).HasColumnName("Id_diezmo");
            entity.Property(e => e.IdOfrendas).HasColumnName("Id_ofrendas");
            entity.Property(e => e.IdVarios).HasColumnName("Id_varios");
            entity.Property(e => e.MesIngresos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mes_ingresos");
            entity.Property(e => e.TotalIngreso1).HasColumnName("total_ingreso");

            entity.HasOne(d => d.IdDiezmoNavigation).WithMany(p => p.TotalIngresos)
                .HasForeignKey(d => d.IdDiezmo)
                .HasConstraintName("FK__Total_ing__Id_di__5165187F");

            entity.HasOne(d => d.IdOfrendasNavigation).WithMany(p => p.TotalIngresos)
                .HasForeignKey(d => d.IdOfrendas)
                .HasConstraintName("FK__Total_ing__Id_of__52593CB8");

            entity.HasOne(d => d.IdVariosNavigation).WithMany(p => p.TotalIngresos)
                .HasForeignKey(d => d.IdVarios)
                .HasConstraintName("FK__Total_ing__Id_va__534D60F1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__63C76BE2F06511DB");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Clave)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
