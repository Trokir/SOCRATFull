using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ShapeModifedParamConfiguration : EntityTypeConfiguration<ShapeModifedParam>
    {
        public ShapeModifedParamConfiguration()
        {
            ToTable("ShapeModifedParam");
            HasKey(p => p.Id);
          // 

            Property(p => p.L_param_t).HasColumnName("L_param_t").HasColumnType("float").IsOptional();
            Property(p => p.H_param_t).HasColumnName("H_param_t").HasColumnType("float").IsOptional();
            Property(p => p.L1_param_t).HasColumnName("L1_param_t").HasColumnType("float").IsOptional();
            Property(p => p.L2_param_t).HasColumnName("L2_param_t").HasColumnType("float").IsOptional();
            Property(p => p.H1_param_t).HasColumnName("H1_param_t").HasColumnType("float").IsOptional();
            Property(p => p.H2_param_t).HasColumnName("H2_param_t").HasColumnType("float").IsOptional();
            Property(p => p.R_param_t).HasColumnName("R_param_t").HasColumnType("float").IsOptional();
            Property(p => p.R1_param_t).HasColumnName("R1_param_t").HasColumnType("float").IsOptional();
            Property(p => p.R2_param_t).HasColumnName("R2_param_t").HasColumnType("float").IsOptional();
            Property(p => p.R3_param_t).HasColumnName("R3_param_t").HasColumnType("float").IsOptional();
            Property(p => p.R4_param_t).HasColumnName("R4_param_t").HasColumnType("float").IsOptional();
            Property(p => p.Chord_param_t).HasColumnName("Chord_param_t").HasColumnType("float").IsOptional();
            Property(p => p.TrueArea).HasColumnName("TrueArea").HasColumnType("float").IsOptional();
            Property(p => p.TruePerimeter).HasColumnName("TruePerimeter").HasColumnType("float").IsOptional();

            HasOptional(e => e.Shape)
                .WithRequired(e => e.ShapeModifedParam);
        }
    }
}
