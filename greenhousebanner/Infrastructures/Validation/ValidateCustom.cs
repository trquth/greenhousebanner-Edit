using System.ComponentModel.DataAnnotations;
using System.Linq;
using greenhousebanner.Infrastructures.Helper;
using greenhousebanner.Models;

namespace greenhousebanner.Infrastructures.Validation
{

    public class CheckPositonAttribute : ValidationAttribute
    {
        public string TableName { get; set; }

        public string ColumnName { get; set; }

        protected override ValidationResult IsValid
          (object value, ValidationContext validationContext)
        {
            using (var context = new GreenhouseBannerContext())
            {
                var listPostions = context.Database.SqlQuery<int>("Select " + ColumnName + " from " + TableName).ToList<int>();
                var maxpositions = context.Database.SqlQuery<int>("Select count(" + ColumnName + ") from " + TableName).FirstOrDefault<int>();
                if (listPostions.Any(item => int.Parse(value.ToString()) == item))
                {
                    maxpositions = maxpositions + 1;
                    return new ValidationResult(ConstantStrings.PositionExist + maxpositions);
                }

                return ValidationResult.Success;
            }
        }
    }

    //public class CheckSeoNameAttribute : ValidationAttribute
    //{
    //    public string ColumnName { get; set; }
    //    protected override ValidationResult IsValid
    //      (object value, ValidationContext validationContext)
    //    {

    //        if (value == null)
    //        {
    //            return new ValidationResult(ConstantStrings.ValueNotSupport);
    //        }

    //        try
    //        {
    //            using (var context = new GreenhouseBannerContext())
    //            {
    //                var metadata = ((IObjectContextAdapter) context).ObjectContext.MetadataWorkspace;
                    
    //                var tables = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>().Where(s => !s.MetadataProperties.Contains("Type") || s.MetadataProperties["Type"].ToString() == "Tables");
                    
    //                if (tables.Any())
    //                {
    //                    foreach (var table in tables)
    //                    {
    //                        var tableName = table.MetadataProperties.Contains("Table") && table.MetadataProperties["Table"].Value != null ? table.MetadataProperties["Table"].Value.ToString() : table.Name;
                            
    //                        var checkcolumnname = context.Database.SqlQuery<string>("Select Table_Name from Information_Schema.Columns where Table_Name = '" + tableName + "' and Column_Name = '" + ColumnName + "'").ToList<string>();
                            
    //                        if (checkcolumnname.IsNotNull())
    //                        {
    //                            var listSeoName = context.Database.SqlQuery<string>("Select " + ColumnName + " from " + tableName).ToList<string>();

    //                            if (listSeoName.Any(item => value.ToString() == item))
    //                            {
    //                                return new ValidationResult(ConstantStrings.SeoNameExist);
    //                            }
    //                        }
    //                    }

    //                    return ValidationResult.Success;
    //                }
    //                else
    //                {
    //                    return new ValidationResult(ConstantStrings.SeoNameExist);
    //                }
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return new ValidationResult(ConstantStrings.ValueNotSupport);
    //        }
    //    }
    //}

}