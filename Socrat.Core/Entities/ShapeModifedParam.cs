using System;

namespace Socrat.Core.Entities
{
   public class ShapeModifedParam : Entity
    {
        public Nullable<double> L_param_t  {get; set; }
        public Nullable<double> H_param_t  {get; set; }
        public Nullable<double> L1_param_t {get; set;}
        public Nullable<double> L2_param_t {get; set;}
        public Nullable<double> H1_param_t {get; set;}
        public Nullable<double> H2_param_t {get; set;}
        public Nullable<double> R_param_t { get; set; }
        public Nullable<double> R1_param_t {get; set;}
        public Nullable<double> R2_param_t {get; set;}
        public Nullable<double> R3_param_t {get; set;}
        public Nullable<double> R4_param_t {get; set;}
        public Nullable<double> Chord_param_t { get; set; }

        
        public Nullable<double> TrueArea   {get; set;  }
     public Nullable<double> TruePerimeter { get; set; }
     public virtual Shape Shape { get; set; }
    }
}
