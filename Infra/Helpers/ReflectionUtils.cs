using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Helpers
{
    public class Model
    {
        public Type Type { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }

    public static class ReflectionUtils
    {
        /// <summary>
        /// Retorna um objeto contendo o tipo, nome e valor das propriedades distintas entre duas instâncias de mesmo tipo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="OldModel">Objeto origem da comparação</param>
        /// <param name="NewModel">Objeto destino da comparação</param>
        /// <returns></returns>
        public static List<Model> DistinctProperty<T>(this T OldModel, T NewModel) where T : class, new()
        {
            if (OldModel is null | NewModel is null)
                return default;

            List<Model> relations = new ();

            var oldProperties = OldModel.GetType().GetProperties();
            var newProperties = NewModel.GetType().GetProperties();

            foreach (var oldProperty in oldProperties)
            {
                if (!oldProperty.Name.Equals("Id"))
                {
                    var newProperty = newProperties.Where(prop => prop.Name.Equals(oldProperty.Name)).FirstOrDefault();

                    if (newProperty != null)
                    {
                        var newPropertyValue = newProperty.GetValue(NewModel);
                        var oldPropertyValue = oldProperty.GetValue(OldModel);

                        if (!oldPropertyValue.Equals(newPropertyValue))
                        {
                            bool isString = newProperty.PropertyType.Equals(typeof(string));

                            relations.Add(new Model
                            {
                                Type = newProperty.PropertyType,
                                PropertyName = newProperty.Name,
                                PropertyValue = isString ? $"'{newPropertyValue}'" : $"{newPropertyValue}"
                            });
                        }
                    }
                }                
            }

            return relations;
        }

        /// <summary>
        /// Retorna uma query de INSERT com todos os campos e valores de acordo com as propriedades da entidade
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static string GetInsertQuery<T>(this T Model) where T : class, new()
        {
            if (Model != null)
            {
                StringBuilder sb = new StringBuilder();

                var model = Model.GetType();
                var properties = model.GetProperties().Where(x => x.Name != "Id");

                sb.Append("INSERT INTO ");
                sb.Append($"{model.Name}(");                
                sb.Append($"{string.Join(",", properties.Select(x => x.Name))}) VALUES(");                

                foreach (var property in properties)
                {
                    bool isString = property.PropertyType.Equals(typeof(string));

                    sb.Append($@"{(isString ? $"'{property.GetValue(Model)}'" : $"{property.GetValue(Model)}")}, ");
                }                

                sb.Remove(sb.ToString().LastIndexOf(","), 2);
                sb.Append(");");

                return sb.ToString();
            }

            return default;
        } 

        /// <summary>
        /// Retorna uma query de UPDATE dando SET em todas as propriedades divergentes entre os parâmetros das duas entidades. Retorna UPDATE sem WHERE.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="OldModel"></param>
        /// <param name="NewModel"></param>
        /// <returns></returns>
        public static string GetUpdateQuery<T>(this T OldModel, T NewModel) where T : class, new()
        {            
            var distinctProperties = DistinctProperty(OldModel, NewModel);

            if (distinctProperties != default)
            {
                StringBuilder sb = new StringBuilder();
                var model = OldModel.GetType();

                sb.Append($"UPDATE {model.Name} SET ");

                foreach (var property in distinctProperties)
                {
                    sb.Append($"{property.PropertyName}={property.PropertyValue}, ");
                }

                sb.Remove(sb.ToString().LastIndexOf(","), 2);
            }            

            return default;
        }                
        public static T Clone<T>(this T original)
        {
            T newObject = (T)Activator.CreateInstance(original.GetType());

            foreach (var originalProp in original.GetType().GetProperties())
            {
                originalProp.SetValue(newObject, originalProp.GetValue(original));
            }

            return newObject;
        }
        public static List<T> CreateList<T>(params T[] elements) => new List<T>(elements);
        
        public static T GetRequiredService<T>(this IServiceProvider _services) => (T)_services.GetService(typeof(T));
    }
}
