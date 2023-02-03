using RusMProject.Domain.Common;
using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Statics
{
    public static class ModelToEntityFill
    {
        public static T FillModelToEntity<T>(this T model,T entity) where T:BaseEntity,IEntity
        {
            var entityProperties = typeof(T).GetProperties();

            foreach (var property in entityProperties)
            {
                var value = property.GetValue(model);
                var type = property.PropertyType;
                var result = CheckDefaultValue(type, value);
                if (result ==true)
                    property.SetValue(entity, value);
            }

            return entity;
        }

        private static bool CheckDefaultValue(Type type,object value)
        {
            var defaultValue =Activator.CreateInstance(type);
            if (defaultValue.Equals(value) || value==null)
                return false;
            return true;
        }
    }
}
