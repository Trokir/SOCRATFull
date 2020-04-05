using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ShapeParamConfiguration : EntityTypeConfiguration<ShapeParam>
    {
        public ShapeParamConfiguration()
        {
            ToTable("ShapeParam");
            HasKey(p => p.Id);
           // 

            //Property(p => p.ShapeId).HasColumnName("Shape_Id").IsOptional();
            Property(p => p.IsCanCutGlass).HasColumnName("IsCanCutGlass").HasColumnType("bit").IsOptional();
            Property(p => p.IsCanBendDistanceFrame).HasColumnName("IsCanBendDistanceFrame").HasColumnType("bit").IsOptional();
            Property(p => p.IsCanFormSeal).HasColumnName("IsCanFormSeal").HasColumnType("bit").IsOptional();
            Property(p => p.IsCanGasFillForm).HasColumnName("IsCanGasFillForm").HasColumnType("bit").IsOptional();
            Property(p => p.IsCanVertBendMashineRobot).HasColumnName("IsCanVertBendMashineRobot").HasColumnType("bit").IsOptional();
            Property(p => p.IsCanVertMashineEdgeMake).HasColumnName("IsCanVertMashineEdgeMake").HasColumnType("bit").IsOptional();
            Property(p => p.IsToothVector).HasColumnName("IsToothVector").HasColumnType("bit").IsOptional();
            Property(p => p.L_param).HasColumnName("L_param").HasColumnType("float").IsOptional();
            Property(p => p.H_param).HasColumnName("H_param").HasColumnType("float").IsOptional();
            Property(p => p.L1_param).HasColumnName("L1_param").HasColumnType("float").IsOptional();
            Property(p => p.L2_param).HasColumnName("L2_param").HasColumnType("float").IsOptional();
            Property(p => p.H1_param).HasColumnName("H1_param").HasColumnType("float").IsOptional();
            Property(p => p.H2_param).HasColumnName("H2_param").HasColumnType("float").IsOptional();
            Property(p => p.R_param).HasColumnName("R_param").HasColumnType("float").IsOptional();
            Property(p => p.R1_param).HasColumnName("R1_param").HasColumnType("float").IsOptional();
            Property(p => p.R2_param).HasColumnName("R2_param").HasColumnType("float").IsOptional();
            Property(p => p.R3_param).HasColumnName("R3_param").HasColumnType("float").IsOptional();
            Property(p => p.R4_param).HasColumnName("R4_param").HasColumnType("float").IsOptional();
            Property(p => p.Chord_param).HasColumnName("Chord_param").HasColumnType("float").IsOptional();
            Property(p => p.B1_param).HasColumnName("B1_param").HasColumnType("float").IsOptional();
            Property(p => p.B2_param).HasColumnName("B2_param").HasColumnType("float").IsOptional();
            Property(p => p.B3_param).HasColumnName("B3_param").HasColumnType("float").IsOptional();
            Property(p => p.B4_param).HasColumnName("B4_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut1_param).HasColumnName("CheckCut1_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut2_param).HasColumnName("CheckCut2_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut3_param).HasColumnName("CheckCut3_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut4_param).HasColumnName("CheckCut4_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut5_param).HasColumnName("CheckCut5_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut6_param).HasColumnName("CheckCut6_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut7_param).HasColumnName("CheckCut7_param").HasColumnType("float").IsOptional();
            Property(p => p.CheckCut8_param).HasColumnName("CheckCut8_param").HasColumnType("float").IsOptional();
            Property(p => p.BaseArea).HasColumnName("BaseArea").HasColumnType("float").IsOptional();
            Property(p => p.Area).HasColumnName("Area").HasColumnType("float").IsOptional();
            Property(p => p.Perimeter).HasColumnName("Perimeter").HasColumnType("float").IsOptional();
            Property(p => p.ShapeKisPersent).HasColumnName("ShapeKisPersent").HasMaxLength(10).IsOptional();
            Property(p => p.ShapeKis).HasColumnName("ShapeKis").HasColumnType("float").IsOptional();
            Property(p => p.ShapeHeight).HasColumnName("ShapeHeight").HasColumnType("float").IsOptional();
            Property(p => p.ShapeWidth).HasColumnName("ShapeWidth").HasColumnType("float").IsOptional();
        }
    }
}
